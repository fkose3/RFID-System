using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class EditUser : Form
    {
        User m_pUser = null;
        ServerDLG m_pMain;
        public EditUser(int sid , List<User> m_userList, ServerDLG main)
        {
            m_pMain = main;
            CheckUser(sid,m_userList);
            InitializeComponent();
        }

        private void CheckUser(int sid, List<User> m_userList)
        {
            foreach (User my in m_userList)
            {
                if (my.m_sSid == sid)
                {
                    m_pUser = my;
                    break;
                }
            }

            if (m_pUser == null) this.Close() ;
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
        }

        private void sendmessage_Click(object sender, EventArgs e)
        {
            byte[] send_buff = new byte[5000];
            int send_index = -1;

            byte[] text_test = Encoding.UTF8.GetBytes(textBox1.Text);
            if (text_test.Length > 4900) return;
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_MESSAGE, ref send_index);
            Tampon.SetShort(ref send_buff, m_pUser.m_sSid, ref send_index);
            Tampon.SetShort(ref send_buff, (short)textBox1.Text.Length, ref send_index);
            Tampon.SetString(ref send_buff, Encoding.UTF8.GetBytes(textBox1.Text), textBox1.Text.Length, ref send_index);

            m_pUser.Send(send_buff, send_index);

            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] send_buff = new byte[5000];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_CLOSE, ref send_index);
            Tampon.SetShort(ref send_buff, m_pUser.m_sSid, ref send_index);

            m_pUser.Send(send_buff, send_index);

            m_pMain.m_UserArray.Remove(m_pUser);
        }
    }
}
