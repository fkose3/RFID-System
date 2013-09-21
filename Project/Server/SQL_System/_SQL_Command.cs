using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

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
        public UserData Login(string acc, string pwd)
        {
            UserData uData = new UserData();
            
                byte nResult = Check_Account(acc, pwd);
                Console.WriteLine(nResult.ToString());
                if (nResult == Define.LOGIN_LOGIN)
                {
                    main_Conn.Open();

                    command.CommandText = "SELECT name,surname,Authorty FROM Account where acc='" + acc + "' AND pwd='" + pwd + "'";

                    D_reader = command.ExecuteReader();

                    if (D_reader.Read())
                    {
                        uData.Account = acc;
                        uData.Mail = null;
                        int i = -1;
                        uData.Name = D_reader.GetValue(++i).ToString();
                        uData.Surname = D_reader.GetValue(++i).ToString();
                        uData.Authorty = byte.Parse(D_reader.GetValue(++i).ToString());
                    }
                    else
                    {
                        uData.Authorty = Define.LOGIN_NOT_LOGIN;
                    }

                    main_Conn.Close();
                }
                else
                {
                    switch (nResult)
                    {
                        case Define.LOGIN_BANNET:
                            uData.Authorty = Define.ACCOUNT_BANNET;
                            break;
                        case Define.LOGIN_INCORRENT:
                            uData.Authorty = Define.LOGIN_INCORRENT;
                            break;
                        default:
                            uData.Authorty = Define.LOGIN_NOT_LOGIN;
                            break;
                    }
                }
            
            
            return uData;
        }

        private byte Check_Account(string acc, string pwd)
        {

            byte nRet = 0;
            main_Conn.Open();
            command.CommandText = "Account_Login";
                       

            command.CommandType = CommandType.StoredProcedure; 

            command.Parameters.Clear();
            SqlParameter outputParam = new SqlParameter()
            {
                ParameterName = "@nRet",
                DbType = DbType.Int16,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(outputParam);
            command.Parameters.Add(new SqlParameter("@acc", acc));
            command.Parameters.Add(new SqlParameter("@pwd", pwd));
            command.ExecuteNonQuery();

            nRet = byte.Parse(outputParam.Value.ToString());

            main_Conn.Close();

            return nRet;
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

        public List<Student> StudensList()
        {
            List<Student> sts_list = new List<Student>();

            main_Conn.Open();

            command.CommandText = "SELECT student_name,student_surn,number,adres,tel1,tel2,birthday,savedate,card_number FROM Student";

            D_reader = command.ExecuteReader();

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

            main_Conn.Close();

            return sts_list;
        }

        /** 
         * Program  to insert the tables.
         */

        public int InsertStudent(string name,string surn, int num,string card,string birth_day,string tel1,string tel2,string adress)
        {
            int nRet = 0 ;
            main_Conn.Open();

            command.CommandText = "exec NewStudent @nRet,'"+name+"','"+surn+"',"+num+",'"+adress+"','"+tel1+"','"+tel2+"','"+birth_day+"','"+card+"'";

            command.CommandType = System.Data.CommandType.StoredProcedure;

            command.Parameters.Clear();

            SqlParameter outputParam = new SqlParameter("@nRet", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(outputParam);

            command.ExecuteNonQuery();

            nRet = int.Parse(outputParam.Value.ToString());

            main_Conn.Close();

            return nRet;
        }

    }
}
