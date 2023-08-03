using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace smarthr_pay
{
    public class MySQLuse
    {
        MySqlConnection conn;
        String connectionString = "server=127.0.0.1;port=3306;user id=root;password=Vancodocton.2402;database=payroll";
        public MySQLuse()
        {
           
           
            using (MySqlConnection conn = new MySqlConnection(connectionString)) ;
          }
        public int CreUpdDel(string sql)
        {
            using (MySqlCommand comm = new MySqlCommand(sql, conn))
            {
                conn.Open();
                int kq = comm.ExecuteNonQuery();
                conn.Close();
                return kq;
            }
        }
        public object Scalar(string sql)
        {
            using (MySqlCommand comm = new MySqlCommand(sql, conn))
            {
                conn.Open();
                object kq = comm.ExecuteScalar();
                conn.Close();
                return kq;
            }
        }
        public DataTable LoadDL(string sql)
        {

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
                
           
        }
    }
}
