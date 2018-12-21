using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    class SqlUtil
    {
        static public DataTable Datas(string sql)
           {
            //String connsql = @"Data Source=LAUTIM\LTSQL;Initial Catalog=Trade;Integrated Security=True;";
            string connsql = "server=.;database=Trade;integrated security=SSPI";
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = connsql;
                conn.Open();                    
                SqlDataAdapter myda = new SqlDataAdapter(sql, conn);                
                DataTable dt = new DataTable(); 
                myda.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        public static  int sqlcmd(string sql,byte[] imageBytes)
        {
            //string connStr = @"Data Source=LAUTIM\LTSQL;Initial Catalog=Trade;Integrated Security=True;";
            string connStr = "server=.;database=Trade;integrated security=SSPI";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlParameter sqlParameter = new SqlParameter("@image", SqlDbType.Image);
                        sqlParameter.Value = imageBytes;
                        cmd.Parameters.Add(sqlParameter);
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                        return rows;
                    }
                    catch (Exception e)
                    {                      
                        return 0;
                    }
                }               
            }
        }
        public static int sqlins(string sql)
        {
            //string connStr = @"Data Source=LAUTIM\LTSQL;Initial Catalog=Trade;Integrated Security=True;";
            string connStr = "server=.;database=Trade;integrated security=SSPI";

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                        conn.Open();                     
                        int rows = cmd.ExecuteNonQuery();
                        conn.Close();
                        return rows;
                    }
                    catch (Exception e)
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
