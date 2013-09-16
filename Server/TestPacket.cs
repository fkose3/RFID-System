using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class z : Form
    {
        public z(ServerDLG pMain)
        {
            m_pMain = pMain; // Main Function 
            InitializeComponent();
        }

        ServerDLG m_pMain = null;

        private void Send_Lesson_Test_Packet(short Sid,short count)
        {
            byte[] send_buff = new byte[512];
            int send_index = -1;

            Tampon.SetByte(ref send_buff, Define.WIZ_CLIENT_PROCESS, ref send_index);
            Tampon.SetShort(ref send_buff, Sid, ref send_index);
            for (int i = 0; i < count; i++)
            {
                string Name = "TestPacket" + i;
                byte[] Text = Encoding.ASCII.GetBytes(Name);
                Tampon.SetShort(ref send_buff, (short)i, ref send_index);
                Tampon.SetShort(ref send_buff, (short)Text.Length, ref send_index);
                Tampon.SetString(ref send_buff, Text, Text.Length, ref send_index);
                Text = Encoding.ASCII.GetBytes("TestLessonTeacher" + i);
                Tampon.SetShort(ref send_buff, (short)Text.Length, ref send_index);
                Tampon.SetString(ref send_buff, Text, Text.Length, ref send_index);
            }
        }

        private void sid_List_Click(object sender, EventArgs e)
        {
            new isActiveClients(m_pMain.m_UserArray,m_pMain);
        }
    }
}
