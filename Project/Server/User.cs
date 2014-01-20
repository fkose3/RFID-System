using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    public class User
    {
       
        public short m_sSid;
        private float OnlineRemain = 0;
        private string _IP;
        private bool _isOnline;
        public UserData m_pUserData;

        public ServerDLG m_pMain; 

        public User(short Sid)
        {
            m_sSid = Sid;
        }

        public void Parsing(byte[] pBuf, int index = 0)
        {
            byte command = 0;
            Tampon.GetByte(pBuf, ref command, ref index);

            switch (command)
            {
                case Define.WIZ_CLIENT_ONLINE:
                    OnlineProcess(pBuf, index);
                    break;
                case Define.WIZ_STUDENT_PROCESS:
                    StudentProcess(pBuf, index);
                    break;
            }
        }

        public void StudentProcess(byte[] pBuf, int index)
        {
            byte command = Tampon.GetByte(pBuf, ref index);

            switch (command)
            {
                case Define.WIZ_STUDENT_ABSENTEEISM:
                    AbsenteeismSend();
                    break;
                case Define.WIZ_STUDENT_LESSON_LIST:
                    break;
            }

        }

        public void AbsenteeismSend()
        {
            List<Absenteeism> Abs_List = m_pMain.m_MainDb.GetAbsenteeism(0);

            byte[] send_buff = new byte[1024];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_STUDENT_PROCESS, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_STUDENT_ABSENTEEISM, ref send_index);

            Tampon.SetDWORD(ref send_buff, Abs_List.Count, ref send_index);

            foreach (Absenteeism abs in Abs_List)
            {
                Tampon.SetShort(ref send_buff, abs.isLesson, ref send_index);
                Tampon.SetByte(ref send_buff, abs.isYear, ref send_index);
                Tampon.SetByte(ref send_buff, abs.isMount, ref send_index);
                Tampon.SetByte(ref send_buff, abs.isDay, ref send_index);
            }

            Send(send_buff, send_index);

        }

        

        public void Send_Bannet()
        {
            byte[] send_buff = new byte[256];
            int index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_ACC_LOGIN, ref index);
            Tampon.SetShort(ref send_buff, m_sSid, ref index);
            Tampon.SetByte(ref send_buff, Define.ACCOUNT_BANNET, ref index);

            Send(send_buff, index);
        }

        public void Send_NotLogin()
        {
            byte[] send_buff = new byte[256];
            int index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_ACC_LOGIN, ref index);
            Tampon.SetShort(ref send_buff, m_sSid, ref index);
            Tampon.SetByte(ref send_buff, Define.LOGIN_NOT_LOGIN, ref index);

            Send(send_buff, index);
        }

        public void Send_Login()
        {
            byte[] send_buff = new byte[256];
            int index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_ACC_LOGIN, ref index);
            Tampon.SetShort(ref send_buff, m_sSid, ref index);
            Tampon.SetByte(ref send_buff, Define.LOGIN_LOGIN, ref index);

            Send(send_buff, index);
        }

        public void OnlineProcess(byte[] pBuf = null  , int index = -1 )
        {
            float Current = Define.TimeGet();
            if (OnlineRemain == 0)
            {
                OnlineRemain = Current + 30;
                return;
            }

            if (Current > OnlineRemain)
                Disconnet();
           

            byte isdisconnet = 0;

            if (pBuf != null && index != -1)
            {
                Tampon.GetByte(pBuf, ref isdisconnet, ref index);

                if (isdisconnet == Define.WIZ_TRUE)
                    Disconnet();
                else
                    OnlineRemain = Current + 30;
            }

        }

        public void Disconnet()
        {
            byte[] send_buff = new byte[5000];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_CLOSE, ref send_index);
            Tampon.SetShort(ref send_buff, this.m_sSid, ref send_index);

            this.Send(send_buff, send_index);

            m_pMain.m_UserArray.Remove(this);
        }

        public void Send(byte[] pBuf , int index)
        {
            try
            {
                TcpClient Client = new TcpClient(IP, 15002);

                NetworkStream Stream = Client.GetStream();

                if (Stream.CanRead)
                    Stream.Write(pBuf, 0, index + 1);
            }
            catch
            {
               // ErrorSend.Parsing(ErrorSend.ErrorType.NotConnect, m_pMain);
            }
        }

        /* sEtter and Getter 
         * Kullanıcı bilgileri 
         */

        public string IP // Client Ip  si
        {
            set { _IP = value; }
            get { return _IP; }
        } 

        public bool isOnline // İs Online Client 
        {
            set { _isOnline = value; }
            get { return _isOnline; }
        }
    }
}
