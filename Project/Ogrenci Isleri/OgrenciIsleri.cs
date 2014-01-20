using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ogrenci_Isleri
{
    public partial class OgrenciIsleri : Form
    {
        public OgrenciIsleri()
        {
            InitializeComponent();
            RFSocket skt = new RFSocket(this);
        }

        public int m_Sid { get; set; }
        
        internal void Parsing(Packet pkt)
        {
            byte command = pkt.GetByte();
            switch (command)
            {
                case Define.WIZ_LOGIN:
                    Login(pkt);
                    break;
            }
        }

        private void Login(Packet pkt)
        {
            byte nRet = pkt.GetByte();

            switch (nRet)
            {
                case 0:// Master Account
                case 1:// Normal Account
                    // Login Successfully
                    m_Sid = pkt.GetDWORD();
                    break;
                default:
                    // Login error
                    Alert("Kullanıcı Adı veya şifre yanlış");
                    break;
            }
        }

        private void Alert(string p, string p2 = "Bir Sorun oluştu")
        {
            MessageBox.Show(p,p2,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }


        private void OgrenciIsleri_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Packet pkt = new Packet(Define.WIZ_LOGIN);
            pkt.AddParameter(Define.WIZ_LOGIN_SAffairs);
            pkt.AddParameter(textBox1.Text);
            pkt.AddParameter(textBox2.Text);

            pkt.Send();
        }



        
    }
}
