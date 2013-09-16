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
        Packet pkt;

        _SQL m_db;

        public _SQL_Command m_SqlCommand;

        public ServerDLG()
        {
             
            // Başlangic mesaji

            Print("****************************************", 2);
            Print("*****    Server Program Started    *****", 2);
            Print("****************************************", 2);

            Print("-> Dinleyici Başlatiliyor...", 4);

            if (!CreatePacket())
            {
                Print("\t[  FAIL  ]", 1);
                return;
            }

            Print("\t[  OK  ]", 2);

            m_db = new _SQL("Kn_online", this);

            Print("-> SQL Bağlantiti gerceklestiriliyor...", 4);
            if (!m_db.checkConnect())
            {
                Print("\t[  FAIL  ]", 1);
                return;
            }

            Print("\t[  OK  ]", 2);

            Print("-> SQL Command Baslatiliyor...", 4);
            try
            {
                m_SqlCommand = new _SQL_Command(m_db.GetSqlConnet());
                Print("\t[ OK ]", 2);
            }
            catch
            {
                Print("\t[ FAIL ]", 1);
            }

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

        public void Parsing(byte[] data, Socket soc) // Handle Function 
        {
            int index = -1;
            byte command = 0x00 ;

            Tampon.GetByte( data , ref command , ref  index );

            switch (command)
            {
                case Define.WIZ_LOGIN:
                    newUser(soc,data);
                    break;
                case Define.WIZ_CLIENT_PROCESS:
                    short sid = -1;
                    Tampon.GetShort(data,ref sid, ref index);
                    User pUser = UserPtr(sid);
                    pUser.m_pMain = this;
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
            }

            Console.WriteLine(Text);
            return Text;
        }

    }
}
