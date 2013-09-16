using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Server
{
    public class _SQL
    {
        SqlConnection Conn = new SqlConnection();
       
        ServerDLG m_pMain;

        public _SQL(string dbName,ServerDLG pMain)
        {
            Conn.ConnectionString = @"Server=.;Database="+dbName+";Integrated Security=True;Asynchronous Processing=True;";            
            m_pMain = pMain;
        }

        public bool checkConnect()
        {
            try
            {
                Conn.Open();
            }
            catch
            {
                return false;
            }
            finally
            {
                Conn.Close();
            }
            return true;
        }

        public SqlConnection GetSqlConnet()
        {
           return Conn;
        }
    }
}
