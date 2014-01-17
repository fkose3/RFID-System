using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using Client.OkumaYazma;


namespace Client
{
    public partial class cMainForm : Form
    {
        public cMainForm()
        {
            InitializeComponent();
        }

  
       
        ClientPC Client = null;
        public RFSocket pkt;
        public string language;
        public int soket;
        public string MAIN_SERVER_IP;
        public bool ReadPort = false;

        private string test_cart, test_pw;

        private void cMainForm_Load(object sender, EventArgs e)
        {
            Client = new ClientPC(this);
            
            if (!ReadConfig.ReadBasicConfig(this))      // Ayar dosyasini okuma
                Application.Exit();                     // Okuma başarısız.

            if (!CreateSocket())                        // Haberlerlesme portunu aç
            {                                           // Açılmassa Hata verip programı kapat
                ErrorSend.Parsing(ErrorSend.ErrorType.OnlineProgram, this);
                Application.Exit();
            }

            // BackGround Clor :)
            foreach (Control c in this.Controls)
            {
                if (c is MdiClient)
                    c.BackColor = Color.FromArgb(35, 35, 35);
            }

            pMainPanel.BackColor = Color.FromArgb(111, 111, 111);
            

            StartPgram();

        }

        private bool CreateSocket()
        {
            try
            {
                pkt = new RFSocket(this);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void StartPgram()
        {
            // WIZ_PROGRAM_START Function

            byte[] send_buff = new byte[1];
            int send_index = -1;
            Tampon.SetByte(ref send_buff, Define.WIZ_LOGIN, ref send_index);

            Client.Send(send_buff, send_index);
            
        }
        
        public void Parsing(byte[] get_data)
        {
            int get_index = -1;
            byte command = 0x00;
            Tampon.GetByte(get_data, ref command, ref get_index);

            switch (command)
            {
                case Define.WIZ_SEND_SID:
                    LaunchProgram(get_data,get_index);                    
                    break;
                case Define.WIZ_CLIENT_PROCESS:
                    Client.Parsing(ref get_data, ref get_index);
                    break;
            }
        }

        private void LaunchProgram(byte[] get_data, int get_index)
        {
            short sid = -1;
            Tampon.GetShort(get_data, ref sid, ref get_index);
            if (sid < 0 || sid > 1500) return;

            Client.m_Sid = sid;

        }

        private void PacketTimer_Tick(object sender, EventArgs e)
        {
            Client.SendMyOnline();
        }

        private void btn_MouseHover(object sender, EventArgs e)
        {
           Button btn = (Button)sender;

            btn.BackColor = Color.FromArgb(111, 255, 254);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        
    }
}
