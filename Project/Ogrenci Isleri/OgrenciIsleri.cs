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
        
        internal void Parsing(Packet pkt)
        {
            byte command = pkt.GetByte();
            switch (command)
            {
                case Define.WIZ_LOGIN:
                    MessageBox.Show(pkt.GetByte().ToString());
                    break;
            }
        }


        private void OgrenciIsleri_Load(object sender, EventArgs e)
        {

        }

        
    }
}
