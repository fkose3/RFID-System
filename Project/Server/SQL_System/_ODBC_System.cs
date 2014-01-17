using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Text;

namespace Server.SQL_System
{
    public class _ODBC_System
    {
        ServerDLG m_pMain = null;

        #region Odbc System

        // Parameters
        private string DSN, UID, PWD;
        private _ODBC_Connection Connect = null;
        private OdbcCommand Command = new OdbcCommand();
        private OdbcDataReader Dataread ;

        
        // Construct 
        public _ODBC_System( string DSN = "", string UID = "", string PWD = "", ServerDLG pMain = null)
        {
            this.DSN = DSN; this.UID = UID; this.PWD = PWD;
            this.m_pMain = pMain;
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
        
        public List<Lesson> LessonList()
        {
            List<Lesson> Lessons = new List<Lesson>();
            OdbcDataReader D_reader = ExecutableScript("SELECT id,lesson_name FROM Lesson");

            while (D_reader.Read())
            {
                Lesson less = new Lesson();

                int i = -1;
                less.LessonID = Convert.ToInt32(D_reader.GetValue(++i));
                less.LessonName = D_reader.GetValue(++i).ToString();

                Lessons.Add(less);

            }

            return Lessons;
        }

        public List<Teacher> TeacherList()
        {
            List<Teacher> t_list = new List<Teacher>();
            OdbcDataReader D_reader = ExecutableScript("SELECT id,student_name,student_surn FROM Student Where Type = 1");
           
            while (D_reader.Read())
            {
                Teacher tch = new Teacher();

                int i = -1;
                tch.TeacherID = Convert.ToInt16(D_reader.GetValue(++i));
                tch.TeacherName = D_reader.GetValue(++i).ToString();
                tch.TeacherSurn = D_reader.GetValue(++i).ToString();

                t_list.Add(tch);
            }

            return t_list;
        }

        public List<Lesson_Program> LessonProgram()
        {
            List<Lesson_Program> L_list = new List<Lesson_Program>();
            OdbcDataReader D_reader = ExecutableScript("SELECT lesson_id,teacher_id,dates,times,grade,branch FROM Lesson_Program");

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

            return L_list;
        }

        public List<Student> StudensList()
        {
            List<Student> sts_list = new List<Student>();
            OdbcDataReader D_reader = ExecutableScript("SELECT student_name,student_surn,number,adres,tel1,tel2,birthday,savedate,card_number FROM Student");

            while (D_reader.Read())
            {
                Student sts = new Student();
                int i = -1;

                sts.StudentName = D_reader.GetValue(++i).ToString();
                sts.StudentSurn = D_reader.GetValue(++i).ToString();
                sts.StudentNum = Convert.ToInt32(D_reader.GetValue(++i));
                sts.Adress = D_reader.GetValue(++i).ToString();
                sts.Tel1 = D_reader.GetValue(++i).ToString();
                sts.Tel2 = D_reader.GetValue(++i).ToString();
                sts.BirthDay = D_reader.GetValue(++i).ToString();
                sts.SaveDate = D_reader.GetValue(++i).ToString();
                sts.StudentCartCode = D_reader.GetValue(++i).ToString();

                sts_list.Add(sts);
            }

            return sts_list;
        }

        internal byte Login(string AccUid, string AccPwd)
        {
            return 0x00;
        }
    }
}
