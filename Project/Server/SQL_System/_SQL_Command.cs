using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Server
{
    public class _SQL_Command
    {
        SqlConnection main_Conn = null;
        SqlCommand command = new SqlCommand();
        SqlDataReader D_reader = null;

        public _SQL_Command(SqlConnection Conn)
        {
            main_Conn = Conn;
            command.Connection = Conn;
        }

        /**
         * Absenteeism Get SQL Server 
         * And Send System 
         */

        public List<Absenteeism> GetAbsenteeism(int StudentNumber)
        {
            List<Absenteeism> Ab_List = new List<Absenteeism>();

            command.CommandText = "SELECT lesson_id,tar FROM Absenteeism where student_id = " + StudentNumber;

            D_reader = command.ExecuteReader();

            while (D_reader.Read())
            {
                int i=0;
                Absenteeism abs = new Absenteeism();
                abs.isLesson = (short)D_reader.GetValue(i);
                // Splitting Date
                string[] Date = D_reader.GetValue(++i).ToString().Split('-');
                i=-1;
                abs.isYear = byte.Parse(Date[++i]);
                abs.isMount = byte.Parse(Date[++i]);
                abs.isDay = byte.Parse(Date[++i]);

                Ab_List.Add(abs);
            }

            return Ab_List;
        }
    }
}
