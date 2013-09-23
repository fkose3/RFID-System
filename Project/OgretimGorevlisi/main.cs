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
            lgnBox.Focus();
        }

        private Packet pkt;
        private LoginBox lgnBox;
        private short m_sSid;
        private bool Login;

        private void main_Load(object sender, EventArgs e)
        {
            Login = false;
            pkt = new Packet(this);

            lgnBox = new LoginBox();
            lgnBox.Show();
            
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
            
            switch (command)
            {
                case Define.WIZ_SEND_SID:
                    LaunchProgram(pBuf ,index);
                    break;
                case Define.WIZ_ACC_LOGIN:
                    LoginProc(pBuf,index);
                    break;
            }
        }

        private void SendMyOnline(bool disconnet = false)
        {
            byte[] send_buff = new byte[32];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetShort(ref send_buff, m_sSid, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_ONLINE, ref send_index);
            if (disconnet)
                Tampon.SetByte(ref send_buff, Define.WIZ_TRUE, ref send_index);
            else
                Tampon.SetByte(ref send_buff, Define.WIZ_FALSE, ref send_index);

            Send(send_buff, send_index);
        }

        private void LoginProc(byte[] pBuf, int index)
        {
            short sid = Tampon.GetShort(pBuf, ref index);

            if (m_sSid != sid) return;

            byte command = Tampon.GetByte(pBuf, ref index);

            switch (command)
            {
                case Define.LOGIN_BANNET:
                    MessageBox.Show("Hesap Banlıdır.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Define.LOGIN_INCORRENT:
                case Define.LOGIN_NOT_LOGIN:
                    MessageBox.Show("Hesap Bilgileri Yanlış veya kullanılmıyor.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case Define.LOGIN_LOGIN:
                    Login = true;
                    MessageBox.Show("Giriş Başarılı.","Onay.",MessageBoxButtons.OK,MessageBoxIcon.Information);
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

        private void PacketTimer_Tick(object sender, EventArgs e)
        {
            SendMyOnline();
        }

        private void LoginTimer_Tick(object sender, EventArgs e)
        {
            panel1.Visible = !Login;
            lgnBox.Visible = !Login;
        }
    }
}
