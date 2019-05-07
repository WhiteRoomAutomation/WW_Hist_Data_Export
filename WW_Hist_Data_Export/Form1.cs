using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WW_Hist_Data_Export
{

	public partial class Form1 : Form
	{
        Thread thrProcessing;
        public static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
		public Form1()
		{
			InitializeComponent();
		}

		private void Button1_Click(object sender, EventArgs e)
		{
            thrProcessing = new Thread(() => ProcessData());
            thrProcessing.IsBackground = true;
            thrProcessing.Start();
        }

        private void ProcessData()
        {
            SetProcessing(true);
            SqlConnection sql_connection;

            SqlCommand sql_command;
            int iCount;
            int iIndex = 0;
            DataTable dt = new DataTable();
            try
            {
                string szSQLConnectionInfo;
                string szTagQuery;
                szSQLConnectionInfo = "Data Source=localhost;Initial Catalog=Runtime;Trusted_Connection=true";
                sql_connection = new SqlConnection(szSQLConnectionInfo);
                if (chkSystemTags.Checked)
                {
                    szTagQuery = "SELECT [TagName] FROM[dbo].[Tag] where TagType <> 5";
                }
                else
                {
                    szTagQuery = "SELECT [TagName] FROM[dbo].[Tag] where TagType <> 5 and [TagName] not like 'sys%'";
                }
                sql_command = new SqlCommand(szTagQuery, sql_connection);
                sql_command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(sql_command);
                da.Fill(dt);
                iCount = dt.Rows.Count;
                sql_connection.Close();
            }
            catch (Exception exDb)
            {
                logger.Error(exDb, "Error retreiving tags");

            }


            List<string> szTagLists = new List<string>();
            string szTagList = "";
            logger.Info("test");

            try
            {


                foreach (DataRow row in dt.Rows)
                {
                    szTagList = szTagList + "[" + row[0].ToString() + "],";
                    iIndex = iIndex + 1;
                    if (iIndex == nmBatchSize.Value)
                    {
                        szTagList = szTagList.TrimEnd(',');
                        szTagLists.Add(szTagList);

                        szTagList = "";
                        iIndex = 0;
                    }


                }
            }
            catch (Exception exList)
            {

                logger.Error(exList, "Error retreiving tags");
            }

            if (szTagList != "")
            {
                szTagList = szTagList.TrimEnd(',');
                szTagLists.Add(szTagList);

                szTagList = "";
            }

            iIndex = 0;
            foreach (string szList in szTagLists)
            {
                iIndex = iIndex + 1;
                SetIndex(iIndex.ToString("D5"));

                SqlConnection sql_connection_results;
                string szSQLConnectionInfo_results;
                szSQLConnectionInfo_results = "Data Source=localhost;Initial Catalog=Runtime;Trusted_Connection=true";
                sql_connection_results = new SqlConnection(szSQLConnectionInfo_results);
                SqlCommand sql_command_results;

                DateTime dtNow = DateTime.Now;
                for (DateTime dtStart = dtpStart.Value.AddSeconds(dtpStart.Value.Second * -1).AddMinutes(dtpStart.Value.Minute * -1).
                    AddHours(dtpStart.Value.Hour * -1).AddDays(dtpStart.Value.Day * -1 +1); dtStart < dtpEnd.Value; dtStart = dtStart.AddMonths(1))
                {
                    SetDate(dtStart.ToString("yyyy-MM-dd HH:mm:ss"));

                    string szQuery = "";
                    DataTable dt_Results = new DataTable();
                    try
                    {
                        szQuery = "SET QUOTED_IDENTIFIER OFF SELECT DateTime," + szList;
                        szQuery = szQuery + " FROM OPENQUERY(INSQL, \"SELECT DateTime = convert(nvarchar, DateTime, 21), ";
                        szQuery = szQuery + szList + " FROM WideHistory WHERE wwRetrievalMode = 'Cyclic' AND wwResolution = 60000 AND wwQualityRule = 'Extended' AND wwVersion = 'Latest' AND DateTime >= ";
                        

                        DateTime dtEnd;
                        dtEnd = dtStart.AddMonths(1).AddSeconds(-1);
                        if (dtEnd > dtpEnd.Value)
                        {
                            dtEnd = dtpEnd.Value;
                        }



                        szQuery = szQuery + "'" + dtStart.ToString() + "'";
                        szQuery = szQuery + " AND DateTime <= ";
                        szQuery = szQuery + "'" + dtEnd.ToString() + "'" + "\")";
                        Debug.Write(szQuery);
                        sql_command_results = new SqlCommand(szQuery, sql_connection_results);
                        sql_command_results.CommandType = CommandType.Text;
                        sql_command_results.CommandTimeout = 120;
                        SqlDataAdapter da_results = new SqlDataAdapter(sql_command_results);
                        logger.Info(szQuery);
                        da_results.Fill(dt_Results);


                        iCount = dt_Results.Rows.Count;
                        logger.Info("Completed query for taglist Number: {0} Month: {1} Year: {2}", iIndex, dtStart.Month, dtStart.Year);
                        logger.Info("{0} Rows Returned", iCount);


                    }
                    catch (Exception exHistory)
                    {
                        logger.Error(exHistory, "Error retreiving history");
                    }

                    StreamWriter csv;

                    try
                    {
                        csv = new StreamWriter(this.txtDirectory.Text + "\\" + iIndex.ToString("D5") + dtStart.Year.ToString() + dtStart.Month.ToString("D2") + ".csv", false);


                        csv.WriteLine("DateTime," + szList);
                        int iLineCount = 0;
                        foreach (DataRow ResultRow in dt_Results.Rows)
                        {
                            try
                            {
                                string szLine = "";
                                foreach (object cell in ResultRow.ItemArray)
                                {
                                    string szData = cell.ToString();
                                    if (szData == "")
                                    {
                                        szData = "NULL";
                                    }
                                    szLine = szLine + szData + ",";
                                }
                                szLine = szLine.TrimEnd(',');
                                csv.WriteLine(szLine);
                                iLineCount = iLineCount + 1;


                            }
                            catch (Exception exCSVWrite)
                            {

                                logger.Error(exCSVWrite, "Error writing CSV line");
                            }

                        }
                        logger.Info("Wrote {0} results for Taglist: {1} Year: {2} Month: {3}", iLineCount, iIndex, dtStart.Year, dtStart.Month);
                        csv.Close();
                    }
                    catch (Exception exCSV)
                    {

                        logger.Error(exCSV, "Error opening CSV");
                    }


                }
                sql_connection_results.Close();
            }
            SetProcessing(false);
        }

		private void BtnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
			if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
			{
			   this.txtDirectory.Text = folderBrowserDialog1.SelectedPath;
			}
		}

		private void NmBatchSize_ValueChanged(object sender, EventArgs e)
		{

		}

        delegate void SetProcesingCallBack(bool bProc);
        private void SetProcessing(bool bProc)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblProcessing.InvokeRequired)
            {
                SetProcesingCallBack d = new SetProcesingCallBack(SetProcessing);
                this.Invoke(d, new object[] { bProc });
            }
            else
            {
                this.lblProcessing.Visible = bProc;
            }
        }

        delegate void SetIndexCallback(string text);
        private void SetIndex(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblIndex.InvokeRequired)
            {
                SetIndexCallback d = new SetIndexCallback(SetIndex);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblIndex.Text = text;
            }
        }
        delegate void SetDateCallback(string text);
        private void SetDate(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.lblIndex.InvokeRequired)
            {
                SetDateCallback d = new SetDateCallback(SetDate);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.lblDate.Text = text;
            }
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thrProcessing.ThreadState== System.Threading.ThreadState.Running)
            {
                thrProcessing.Abort();
            }
            
        }

    }
}
