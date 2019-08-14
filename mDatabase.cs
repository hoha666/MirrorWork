using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;

namespace MirrorWork
{
    public class mDataBase
    {
        public static DataSet ToDataSet(string[,] input)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = dataSet.Tables.Add();
            for (int i = 0; i < input.GetLength(0); i++)
            {
                //dataTable.Rows.Add(new DataRow());
                for (int j = 0; j < input.GetLength(1); j++)
                {
                    dataTable.Columns.Add();
                    if (j == 0) dataTable.Rows.Add()[j] = input[i, j];
                    else
                        dataTable.Rows[i][j] = input[i, j];
                }
            }
            return dataSet;
        }

        public static DataSet SQLquery(string SqlQuery, NameValueCollection NameValues)
        {

            string connectionInfo = mDecoder.decode(mConfig.GetKey("ConnectionInfo"));
            if (connectionInfo == null) return null;
            SqlConnection connection = new SqlConnection(connectionInfo);
            SqlCommand command = new SqlCommand();
            command.CommandText = SqlQuery;
            for (int i = 0; i < NameValues.Keys.Count; i++)
            {
                command.Parameters.AddWithValue(NameValues.GetKey(i), NameValues.Get(i));
            }
            command.Connection = connection;
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(command);
            sda.Fill(ds);
            return ds;
        }
        public static SqlDataAdapter getAdapter(string SqlQuery, NameValueCollection NameValues)
        {
            string connectionInfo = mDecoder.decode(mConfig.GetKey("ConnectionInfo"));
            if (connectionInfo == null) return null;
            SqlConnection connection = new SqlConnection(connectionInfo);
            SqlCommand command = new SqlCommand();
            command.CommandText = SqlQuery;
            for (int i = 0; i < NameValues.Keys.Count; i++)
            {
                command.Parameters.AddWithValue(NameValues.GetKey(i), NameValues.Get(i));

            }
            command.Connection = connection;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            return sda;
        }
        public static DataTable SQLquery(string SqlQuery)
        {
            string connectionInfo = mDecoder.decode(mConfig.GetKey("ConnectionInfo"));
            SqlConnection connection = new SqlConnection(connectionInfo);
            SqlCommand command = new SqlCommand();
            command.CommandText = SqlQuery;
            command.Connection = connection;
            DataTable dt = new DataTable();
            SqlDataAdapter mysqlAdapter = new SqlDataAdapter(command);
            mysqlAdapter.SelectCommand = command;
            mysqlAdapter.Fill(dt);
            return dt;
            /***********************************************/

        }
        public static bool SQLNonquery(string query)
        {
            string connectionInfo = mDecoder.decode(mConfig.GetKey("ConnectionInfo"));
            SqlConnection connection = new SqlConnection(connectionInfo);
            SqlCommand command = new SqlCommand();
            command.CommandText = query;
            command.Connection = connection;
            connection.Open();
            int rows = command.ExecuteNonQuery();
            connection.Close();
            if (rows > 0) return true;
            else return false;
        }
        public static bool SQLNonquery(string SqlQuery, NameValueCollection NameValues)
        {
            string connectionInfo = mDecoder.decode(mConfig.GetKey("ConnectionInfo"));
            SqlConnection connection = new SqlConnection(connectionInfo);
            SqlCommand command = new SqlCommand();
            command.CommandText = SqlQuery;
            for (int i = 0; i < NameValues.Keys.Count; i++)
            {
                command.Parameters.AddWithValue(NameValues.GetKey(i), NameValues.Get(i));

            }
            command.Connection = connection;
            connection.Open();
            int rows = command.ExecuteNonQuery();
            connection.Close();
            if (rows > 0) return true;
            else return false;
        }

        public static DataTable SQLqueryWithPaging(string table_name, int page, int pageSize, string orderbycolname)
        {
            NameValueCollection nv = new NameValueCollection();
            nv.Add("@table_name", table_name);
            nv.Add("@PageSize2", pageSize.ToString());
            nv.Add("@Page_number", page.ToString());
            nv.Add("@orderitem", orderbycolname);
            string query = "use @table_name DECLARE @PageSize INT,@Page INT SELECT  @PageSize = @pagesize2 , @Page = @page_number ; WITH PageNumbers AS(SELECT *,  ROW_NUMBER() OVER(ORDER BY @orderitem) IDs FROM Games)SELECT * FROM PageNumbers WHERE   IDs  BETWEEN ((@Page - 1) * @PageSize + 1)AND (@Page * @PageSize)";
            DataSet ds = SQLquery(query, nv);
            return ds.Tables[0];
        }
    }
}
