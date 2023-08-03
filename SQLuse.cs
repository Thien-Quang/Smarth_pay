using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace smarthr_pay
{
    public class SQLuse
    {
        SqlConnection conn;
        public SQLuse()
        {
            conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-M12R4KO;Initial Catalog=HR;Integrated Security=True";
        }

        public int CreUpdDel(string sql)
        {
            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            int kq = comm.ExecuteNonQuery();
            conn.Close();
            return kq;

        }
        public object Scalar(string sql)
        {

            SqlCommand comm = new SqlCommand(sql, conn);
            conn.Open();
            object kq = comm.ExecuteScalar();
            conn.Close();
            return kq;
        }
        public DataTable LoadDL(String sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}