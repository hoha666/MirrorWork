using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.ComponentModel;
using System.Data.OleDb;
using ExcelLibrary;




namespace MirrorWork
{
    public class mExcel
    {
        public static DataTable getfromxls(string filename, int sheet_number)
        {
            OleDbConnection conn;
            OleDbDataAdapter adapter;
            DataTable dt = new DataTable();
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';");
            conn.Open();
            dt = conn.GetSchema("Tables");
            if (dt == null || dt.Rows.Count == 0 || dt.Rows[sheet_number - 1] == null) return null;
            string tempular = "select * from [" + dt.Rows[sheet_number - 1]["TABLE_NAME"].ToString() + "]";
            adapter = new OleDbDataAdapter(tempular, conn);//+ dt.Rows[0]["TABLE_NAME"].ToString()
            new OleDbCommandBuilder(adapter);
            dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        public static DataTable XLSgetschema(string filename)
        {
            OleDbConnection conn;
            DataTable dt = new DataTable();
            conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1';");
            conn.Open();
            dt = conn.GetSchema("Tables");
            conn.Close();
            return dt;
        }
        public static void saveExcel(DataSet myds, string save_address)
        {
            myds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            ExcelLibrary.DataSetHelper.CreateWorkbook(save_address, myds);
        }
        public static void saveExcel(DataTable mydata, string save_address)
        {

            //Create the data set and table
            DataSet ds = new DataSet("New_DataSet");
            //DataTable dt = new DataTable("New_DataTable");

            //Set the locale for each
            ds.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;
            mydata.Locale = System.Threading.Thread.CurrentThread.CurrentCulture;

            //Open a DB connection (in this example with OleDB)
            //OleDbConnection con = new OleDbConnection(dbConnectionString);
            //con.Open();

            ////Create a query and fill the data table with the data from the DB
            //string sql = "SELECT Whatever FROM MyDBTable;";
            //OleDbCommand cmd = new OleDbCommand(sql, con);
            //OleDbDataAdapter adptr = new OleDbDataAdapter();

            //adptr.SelectCommand = cmd;
            //adptr.Fill(dt);
            //con.Close();

            //Add the table to the data set
            ds.Tables.Add(mydata);

            //Here's the easy part. Create the Excel worksheet from the data set
            ExcelLibrary.DataSetHelper.CreateWorkbook(save_address, ds);
            //return save_address;
        }

        
    }

}
