using System;
using System.Collections.Generic;
using System.Text;
using MirrorWork;
using System.Data.SqlClient;
using System.Data;

namespace MirrorWork
{
    public class Mtable
    {
        public static string readTable(Array cols, string table_name, int paging, int page, int sort_col, string table_title_text, Array col_titles)
        {
            string output = "";
            int min = (page * paging) - paging + 1;
            int max = (page * paging);
            DataTable table_cols = mDataBase.SQLquery("SELECT column_name FROM information_schema.columns WHERE table_name = '" + table_name + "'");
            string col_names = "id ,";
            for (int i = 0; i < cols.Length; i++)
            {
                if (i == cols.Length - 1)
                {
                    int y = int.Parse(cols.GetValue(i).ToString());
                    col_names += table_cols.Rows[y][0].ToString() + " ";
                }
                else
                {
                    int y = int.Parse(cols.GetValue(i).ToString());
                    col_names += table_cols.Rows[y][0].ToString() + ", ";
                }
            }
            DataTable dt = mDataBase.SQLquery("SELECT " + col_names + "FROM (SELECT " + col_names + ", ROW_NUMBER() OVER (ORDER BY " + table_cols.Rows[sort_col][0].ToString() + ") AS RowNum FROM " + table_name + ") AS MyDerivedTable WHERE MyDerivedTable.RowNum BETWEEN " + min + " AND " + max + "");
            output += "<table class='table_header'><tr><td class='td_title'><img src=\"../images/td_title_star.png\" width=\"18px\" />&nbsp;" + table_title_text + "</td></tr></table>";
            output += "<table class='table_input'><tr>";
            for (int i = 0; i < col_titles.Length; i++)
            {
                output += "<td>" + col_titles.GetValue(i).ToString() + "</td>";
            }
            output += "<td>ویرایش</td>";
            output += "<td>حذف</td>";
            output += "</tr>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                output += "<tr>";
                for (int j = 0; j < cols.Length; j++)
                {
                    output += "<td class='td_lable'>" + dt.Rows[i][j].ToString() + "</td>";
                }
                output += "<td class='td_lable'><a href=\"Javascript:edit_item(" + dt.Rows[i]["id"].ToString() + ")\"><img src=\"../images/edit.png\" width=\"18px\" /></a></td>";
                output += "<td class='td_lable'><a href=\"Javascript:delete_item(" + dt.Rows[i]["id"].ToString() + ")\"><img src=\"../images/delete.png\" width=\"18px\" /></a></td>";
                output += "</tr> ";
            }
            output += "</table>";



            return output;
        }
    }
}
