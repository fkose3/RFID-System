using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace Server.SQL_System
{
    public class _ODBC_Connection 
    {

        private string DSN, UID, PWD;
        private OdbcConnection connection = null;

        public _ODBC_Connection(string DSN = "", string UID = "", string PWD = "")
        {
            this.DSN = DSN; this.UID = UID; this.PWD = PWD;
            Configuration();
        }

        private void Configuration()
        {
            connection = new OdbcConnection("DSN="+DSN+";UID"+UID+";PWD="+PWD+";");
        }

        public OdbcConnection GetConnection() { return connection; }

      


    }
}
