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
        ServerDLG m_pMain = null;

        public _SQL_Command(SqlConnection Conn,ServerDLG main)
        {
            main_Conn = Conn;
            command.Connection = Conn;
            m_pMain = main;
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


        /** 
         * Program starts to read the tables.
         */

        public List<Lesson> LessonList()
        {
            List<Lesson> Lessons = new List<Lesson>();

            main_Conn.Open();
            command.CommandText = "SELECT id,lesson_name FROM Lesson";

            D_reader = command.ExecuteReader();

            while (D_reader.Read())
            {
                Lesson less = new Lesson();

                int i = -1;
                less.LessonID = Convert.ToInt32(D_reader.GetValue(++i));
                less.LessonName = D_reader.GetValue(++i).ToString();

                Lessons.Add(less);

            }
            main_Conn.Close();
            return Lessons;
        }

        public List<Teacher> TeacherList()
        {
            List<Teacher> t_list = new List<Teacher>();

            main_Conn.Open();

            command.CommandText = "SELECT id,teacher_name,teacher_surn FROM Teacher ";

            D_reader = command.ExecuteReader();

            while (D_reader.Read())
            {
                Teacher tch = new Teacher();

                int i = -1;
                tch.TeacherID = Convert.ToInt16(D_reader.GetValue(++i));
                tch.TeacherName = D_reader.GetValue(++i).ToString();
                tch.TeacherSurn = D_reader.GetValue(++i).ToString();

                t_list.Add(tch);
            }

            main_Conn.Close();

            return t_list;
        }

        public List<Lesson_Program> LessonProgram()
        {
            List<Lesson_Program> L_list = new List<Lesson_Program>();

            main_Conn.Open();

            command.CommandText = "SELECT lesson_id,teacher_id,dates,times,grade,branch FROM Lesson_Program";

            D_reader = command.ExecuteReader();

            while (D_reader.Read())
            {
                Lesson_Program prg = new Lesson_Program();
                int i = -1;

                prg.LessonID = Convert.ToInt32(D_reader.GetValue(++i));
                prg.LessonName = m_pMain.LessonPtr(prg.LessonID).LessonName;
                prg.TeacherID = Convert.ToInt32(D_reader.GetValue(++i));
                prg.TeacherNane = m_pMain.TeacherPtr(prg.TeacherID).TeacherFullName;
                prg.isDate = D_reader.GetValue(++i).ToString();
                prg.Grade = Convert.ToInt32(D_reader.GetValue(++i));
                prg.Branch = D_reader.GetValue(++i).ToString();

                L_list.Add(prg);
            }

            main_Conn.Close();

            return L_list;
        }
    }
}
