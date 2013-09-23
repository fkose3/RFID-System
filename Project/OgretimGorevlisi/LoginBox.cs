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
    public partial class LoginBox : Form
    {
        public LoginBox()
        {
            InitializeComponent();
            txtPass.PasswordChar = '*';
        }


        private void Login()
        {
               byte[] pBuf = new byte[512];
                int index = -1;

                Tampon.SetByte(ref pBuf, Define.WIZ_ACC_LOGIN,ref index);
                Tampon.SetShort(ref pBuf, 0, ref index);
                Tampon.SetShort(ref pBuf, (short)txtAcc.Text.Length, ref index);
                Tampon.SetString(ref pBuf, Encoding.UTF8.GetBytes(txtAcc.Text), txtAcc.Text.Length, ref index);
                Tampon.SetShort(ref pBuf, (short)txtPass.Text.Length, ref index);
                Tampon.SetString(ref pBuf, Encoding.UTF8.GetBytes(txtPass.Text), txtPass.Text.Length, ref index);

                TcpClient Client = new TcpClient("127.0.0.1", 15001);

                NetworkStream Stream = Client.GetStream();
                byte[] Read = new byte[Client.ReceiveBufferSize];
                if (Stream.CanWrite)
                    Stream.Write(pBuf, 0, index + 1);
                
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }
    }
}
