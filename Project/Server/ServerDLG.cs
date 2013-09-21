using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public class ServerDLG
    {

        bool isForm = false;
        public List<User> m_UserArray = new List<User>();
        public List<Lesson> m_LessonArray = new List<Lesson>();
        public List<Teacher> m_TeacherArray = new List<Teacher>();
        public List<Lesson_Program> m_LessonProgram = new List<Lesson_Program>();
        public List<Student> m_StudentArray = new List<Student>();

        Packet pkt;

        private _SQL m_db;

        public _SQL_Command m_SqlCommand;

        public ServerDLG()
        {
             
            // Başlangic mesaji

            Print("****************************************", 2);
            Print("*****    Server Program Started    *****", 2);
            Print("****************************************", 2);
            try
            {
                Print("-> Dinleyici Başlatiliyor...", 4);

                if (!CreatePacket())
                {
                    Print("\t[  FAIL  ]", 1);
                    FailingProgram();
                }

                Print("\t[  OK  ]", 2);

                m_db = new _SQL("RFID_SYSTEM", this);

                Print("-> SQL Bağlantiti gerceklestiriliyor...", 4);
                if (!m_db.checkConnect())
                {
                    Print("\t[  FAIL  ]", 1);
                    FailingProgram();
                }

                Print("\t[  OK  ]", 2);

                Print("-> SQL Command Baslatiliyor...", 4);

                m_SqlCommand = new _SQL_Command(m_db.GetSqlConnet(),this);
                Print("\t[ OK ]", 2);


                Print("-> Ders Listesi Okunuyor...", 4);

                m_LessonArray = m_SqlCommand.LessonList();

                if (m_LessonArray.Count > 0)
                    Print("\t[ OK ]\t[ Count : " + m_LessonArray.Count + " ]", 2);
                else
                    Print("\t[ Emty ]", 5);


                Print("-> Ogretmen Listesi Okunuyor...", 4);

                m_TeacherArray = m_SqlCommand.TeacherList();

                if (m_TeacherArray.Count > 0)
                    Print("\t[ OK ]\t[ Count : " + m_TeacherArray.Count + " ]", 2);
                else
                    Print("\t[ Emty ]", 5);

                Print("-> Ders Programı Listesi Okunuyor...", 4);

                m_LessonProgram = m_SqlCommand.LessonProgram();

                if (m_LessonProgram.Count > 0)
                    Print("\t[ OK ]\t[ Count : " + m_LessonProgram.Count + " ]", 2);
                else
                    Print("\t[ Emty ]", 5);


                Print("-> Ogrenci Listesi Okunuyor...", 4);

                m_StudentArray = m_SqlCommand.StudensList();

                if (m_StudentArray.Count > 0)
                    Print("\t[ OK ]\t[ Count : " + m_StudentArray.Count + " ]", 2);
                else
                    Print("\t[ Emty ]", 5);


                if (!isForm)
                {
                    isForm = !isForm;
                    try
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new windowsPane(this));
                    }
                    catch { }
                }
            }
            catch
            {
                Print("\t[ FAIL ]", 1);
                FailingProgram();
            }


        }

        public void Parsing(byte[] data, Socket soc) // Handle Function 
        {
            int index = -1;
            byte command = 0x00 ;
            short sid = -1;
            Tampon.GetByte( data , ref command , ref  index );
            User pUser = null;

            switch (command)
            {
                case Define.WIZ_LOGIN:
                    newUser(soc,data);
                    break;
                case Define.WIZ_ACC_LOGIN:
                    pUser = UserPtr(Tampon.GetShort(data, ref index));

                    break;
                case Define.WIZ_CLIENT_PROCESS:                    
                    Tampon.GetShort(data,ref sid, ref index);
                    pUser = UserPtr(sid);
                    pUser.Parsing( data , index );
                    break;
                default:
                    Print("#Unknow Packet : [ "+ command.ToString() + " ] ", 1 );
                    break;
            }
            
        }

        public User UserPtr(short sSid)  // Getter User 
        {
            foreach(User pCurrent in m_UserArray )
            {
                if (pCurrent.m_sSid != sSid) continue;

                return pCurrent;
            }

            return new User( -1 );
        }

        public Lesson LessonPtr(int lesson_id) // Getter Lesson
        {
            Lesson lesson = null;

            foreach (Lesson ls in m_LessonArray)
            {
                if (ls.LessonID == lesson_id)
                {
                    lesson = ls;
                    break;
                }
            }

            return lesson;
        }

        public Teacher TeacherPtr(int teacher_id) // Getter Tacher
        {
            Teacher tch = null;

            foreach (Teacher tc in m_TeacherArray)
            {
                if (tc.TeacherID == teacher_id)
                {
                    tch = tc;
                    break;
                }
            }

            return tch;
        }

        public Student StudentPtr(string key, bool number = false /* if the number of students*/)// Get Student
        {
            Student std = null;
            try
            {
                foreach (Student st in m_StudentArray)
                {
                    if (number)
                    {
                        if (st.StudentNum != int.Parse(key)) continue;

                        std = st;
                        break;
                    }
                    else
                    {
                        if (st.StudentCartCode != key) continue;

                        std = st;
                    }
                }
            }
            catch
            {
                Print("Unknown type : StudentPrt", 1);
                std = null;
            }
            return std;
        }

        public void newUser(Socket soc , byte[] data)  // New User 
        {
            User MyUser = null;
            for (int i = 0; i < 1500000000; i++)
            {
                bool Okay = false;
                foreach (User my in m_UserArray)
                {
                    if (my.m_sSid == i ) Okay = true;
                }
                if (!Okay)
                {
                    MyUser = new User((short)i);
                    break;
                }
            }
            MyUser.IP = soc.RemoteEndPoint.ToString().Split(':')[0];

            m_UserArray.Add(MyUser);

            byte[] send_buff = new byte[32];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_SEND_SID, ref send_index);
            Tampon.SetShort(ref send_buff, MyUser.m_sSid, ref send_index);

            MyUser.m_pMain = this;

            MyUser.Send(send_buff, send_index);

        }

        public void TimerFunction()
        {
            CheckAllOnline();
        }

        private void CheckAllOnline()
        {
            reRun:
            try
            {
                foreach (User my in m_UserArray)
                {
                    my.m_pMain = this;
                    my.OnlineProcess();
                }
            }
            catch
            {
                goto reRun;
            }
        }

        private bool CreatePacket()  /// Packet Create
        {
            try
            {
                pkt = new Packet(this);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string Print(string Text, byte type) // Print Console
        {
            switch (type)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case 4:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 5:
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
            }

            Console.WriteLine(Text);
            return Text;
        }

        private void FailingProgram()
        {
            Print("Devametmek için Enter a basın", 3);
            Console.ReadLine();
            Environment.Exit(0);
        }

    }
}
