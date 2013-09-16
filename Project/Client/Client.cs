using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public class ClientPC 
    {

        static cMainForm m_pMain = null;
        short _m_Sid = 0;

        public ClientPC(cMainForm main)
        {
            m_pMain = main;
        }

        public void Parsing(ref byte[] pBuf,ref int index)
        {
            byte Command = 0x00;

            Tampon.GetByte(pBuf, ref Command, ref index);
    
            switch (Command)
            {
                case Define.WIZ_CLIENT_CLOSE:
                    ErrorSend.Parsing(ErrorSend.ErrorType.Disconnect, m_pMain);
                    m_pMain.pkt.Channel.Abort();
                    Application.Exit();
                    break;
                case Define.WIZ_CLIENT_MESSAGE:
                    MessageEvent(pBuf, index);
                    break;
                default:
                    MessageBox.Show("Unknow Packet[  "+Command+"  ]");
                    break;
            }
        }

        public void MessageEvent(byte[] pBuf, int index)
        {
            short sid = 0, len = 0;
            Tampon.GetShort(pBuf, ref sid, ref index);

            if (sid != m_Sid) return;

            byte[] text = new byte[4900];

            Tampon.GetShort(pBuf, ref len, ref index);

            Tampon.GetString(pBuf, ref text, len, ref index);

            MessageBox.Show(Encoding.UTF8.GetString(text), "Server Message ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        public void SendMyOnline(bool disconnet = false)
        {
            byte[] send_buff = new byte[32];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetShort(ref send_buff, m_Sid, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_ONLINE, ref send_index);     
            if( disconnet )
                Tampon.SetByte(ref send_buff, Define.WIZ_TRUE, ref send_index);
            else
                Tampon.SetByte(ref send_buff, Define.WIZ_FALSE, ref send_index);

            Send(send_buff, send_index);
        }

        public void Send( byte[] pBuf , int index)
        {
            try
            {
                TcpClient Client = new TcpClient("127.0.0.1", 15001);

                NetworkStream Stream = Client.GetStream();

                if(Stream.CanRead)
                    Stream.Write(pBuf, 0, index+1);
            }
            catch
            {
                ErrorSend.Parsing(ErrorSend.ErrorType.NotConnect,m_pMain);
            }
        }

        public short m_Sid
        {
            set { _m_Sid = value; }
            get { return _m_Sid; }
        }

        
    }
}
