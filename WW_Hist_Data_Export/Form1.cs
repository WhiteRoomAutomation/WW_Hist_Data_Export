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
            sql_command = new SqlCommand("SELECT [TagName] FROM[dbo].[Tag] where[TagName] not like 'sys%'", sql_connection);
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
                if (iIndex == 100)
                {
                    szTagLists.Add(szTagList);
                    szTagList = "";
                    iIndex = 0;
                }


            }
        }
       
    }
}
