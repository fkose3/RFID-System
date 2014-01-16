using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace Server.SQL_System
{
    public class _ODBC_System
    {

        #region Odbc System

        // Parameters
        private string DSN, UID, PWD;
        private _ODBC_Connection Connect = null;
        private OdbcCommand Command = new OdbcCommand();
        private OdbcDataReader Dataread ;


        // Construct 
        public _ODBC_System(string DSN = "", string UID = "", string PWD = "")
        {
            this.DSN = DSN; this.UID = UID; this.PWD = PWD;
            Connect = new _ODBC_Connection(this.DSN, this.UID, this.PWD);
        }

        private OdbcDataReader ExecutableScript(string T_SQL)
        {

            try
            {
                Dataread.Close();
                Connect.GetConnection().Close();
            }
            catch { }

            Command = new OdbcCommand(T_SQL, Connect.GetConnection());

            Connect.GetConnection().Open();

            Dataread = Command.ExecuteReader();

            return Dataread;
        }

        // Connection
        public bool TestConnection()
        {
            try
            {
                Connect.GetConnection().Open();
            }
            catch (Exception ex)
            {
                Connect.GetConnection().Close();
                return false;
            }
            finally
            {
                Connect.GetConnection().Close();
            }

            return true;
        }
        #endregion

        public List<Absenteeism> GetAbsenteeism(int StudentNumber)
        {
            List<Absenteeism> Ab_List = new List<Absenteeism>();
            OdbcDataReader D_reader = ExecutableScript("SELECT lesson_id,tar FROM Absenteeism where student_id = " + StudentNumber);

            while (D_reader.Read())
            {
                int i = 0;
                Absenteeism abs = new Absenteeism();
                abs.isLesson = (short)D_reader.GetValue(i);
                // Splitting Date
                string[] Date = D_reader.GetValue(++i).ToString().Split('-');
                i = -1;
                abs.isYear = byte.Parse(Date[++i]);
                abs.isMount = byte.Parse(Date[++i]);
                abs.isDay = byte.Parse(Date[++i]);

                Ab_List.Add(abs);
            }

            return Ab_List;
        }
    }
}
