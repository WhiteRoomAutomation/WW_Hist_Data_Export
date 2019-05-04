using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Data.SqlClient;

namespace WW_Hist_Data_Export
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection sql_connection;

            SqlCommand sql_command;
            int iCount;
            int iIndex = 0;


            DataTable dt = new DataTable();
            string szSQLConnectionInfo;
            szSQLConnectionInfo = "Data Source=localhost;Initial Catalog=Runtime;Trusted_Connection=true";
            sql_connection = new SqlConnection(szSQLConnectionInfo);
            sql_command = new SqlCommand("SELECT [TagName] FROM[dbo].[Tag] where TagType <> 5", sql_connection);
            sql_command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(sql_command);
            da.Fill(dt);
            iCount = dt.Rows.Count;


            List<string> szTagLists = new List<string>();
            string szTagList = "";


            foreach (DataRow row in dt.Rows)
            {
                szTagList = szTagList +  "[" + row[0].ToString() + "],";
                iIndex = iIndex + 1;
                if (iIndex == nmBatchSize.Value)
                {
                    szTagList = szTagList.TrimEnd(',');
                    szTagLists.Add(szTagList);

                    szTagList = "";
                    iIndex = 0;
                }


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

                SqlConnection sql_connection_results;
                string szSQLConnectionInfo_results;
                szSQLConnectionInfo_results = "Data Source=localhost;Initial Catalog=Runtime;Trusted_Connection=true";
                sql_connection_results = new SqlConnection(szSQLConnectionInfo_results);
               

                for (int iYear = 2017; iYear <= 2019; iYear ++)
                {
                    for(int  iMonth = 1; iMonth <=12; iMonth ++)
                    {
                        string szQuery = "";
                        

                        SqlCommand sql_command_results;
                        DataTable dt_Results = new DataTable();
                        szQuery = "SET QUOTED_IDENTIFIER OFF SELECT DateTime," + szList;
                        szQuery = szQuery + " FROM OPENQUERY(INSQL, \"SELECT DateTime = convert(nvarchar, DateTime, 21), ";
                        szQuery = szQuery + szList + " FROM WideHistory WHERE wwRetrievalMode = 'Cyclic' AND wwResolution = 60000 AND wwQualityRule = 'Extended' AND wwVersion = 'Latest' AND DateTime >= ";
                        iIndex = 1;
                        DateTime dtStart = new DateTime(iYear,iMonth,1);
                        DateTime dtEnd;
                        dtEnd = dtStart.AddMonths(1).AddSeconds(-1);


                        szQuery = szQuery + "'" + dtStart.ToString() + "'";
                        szQuery = szQuery + " AND DateTime <= ";
                        szQuery = szQuery + "'" + dtEnd.ToString() + "'" + "\")";
                        Debug.Write(szQuery);
                        sql_command_results = new SqlCommand(szQuery, sql_connection_results);
                        sql_command_results.CommandType = CommandType.Text;
                        SqlDataAdapter da_results = new SqlDataAdapter(sql_command_results);
                        da_results.Fill(dt_Results);
                        iCount = dt_Results.Rows.Count;

                        StreamWriter csv = new StreamWriter(this.txtDirectory.Text + "\\"+ iIndex.ToString("X5") + iYear.ToString() + iMonth.ToString("X2") + ".csv",false);

                        csv.WriteLine("DateTime," + szList);
                         foreach (DataRow ResultRow in dt_Results.Rows)
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

                        }
                        csv.Close();

                    }
                }
                
                
                
              


                
            }
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
    }
}
