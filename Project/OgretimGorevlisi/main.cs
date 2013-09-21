using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace OgretimGorevlisi
{
    public partial class main : Form
    {

        public main()
        {
            InitializeComponent();            
        }

        private Packet pkt;
        private LoginBox lgnBox;
        private short m_sSid;

        private void main_Load(object sender, EventArgs e)
        {
            pkt = new Packet(this);

            lgnBox = new LoginBox();
            lgnBox.ShowDialog();
            StartPgram();
        }

        private void StartPgram()
        {
            // WIZ_PROGRAM_START Function

            byte[] send_buff = new byte[1];
            int send_index = -1;
            Tampon.SetByte(ref send_buff, Define.WIZ_LOGIN, ref send_index);

            Send(send_buff, send_index);

        }

        public void Parsing(byte[] pBuf, Socket soc)
        {
            int index = -1;            
            short sid = -1;
            byte command = Tampon.GetByte(pBuf, ref  index);
            MessageBox.Show(command.ToString());
            switch (command)
            {
                case Define.WIZ_SEND_SID:
                    LaunchProgram(pBuf ,index);
                    break;
                case Define.WIZ_ACC_LOGIN:
                    LoginProc(pBuf, index);
                    break;
            }
        }

        private void LoginProc(byte[] pBuf, int index)
        {
            short sid = Tampon.GetShort(pBuf, ref index);

            if (m_sSid != sid) return;

            byte command = Tampon.GetByte(pBuf, ref index);

            switch (command)
            {
                case Define.LOGIN_BANNET:
                    MessageBox.Show("Hesap Banlıdır.", "Uyarı");
                    break;
            }
        }

        private void LaunchProgram(byte[] get_data, int get_index)
        {
            short sid = -1;
            Tampon.GetShort(get_data, ref sid, ref get_index);
            if (sid < 0 || sid > 1500) return;

            m_sSid = sid;

        }

        public void Send(byte[] pBuf, int index)
        {
            try
            {
                TcpClient Client = new TcpClient("127.0.0.1", 15001);

                NetworkStream Stream = Client.GetStream();

                if (Stream.CanRead)
                    Stream.Write(pBuf, 0, index + 1);
            }
            catch
            {
                
            }
        }
    }
}
