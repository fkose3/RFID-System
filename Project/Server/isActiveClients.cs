using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class isActiveClients : Form
    {
        List<User> m_pUserList;
        ServerDLG main;
        public isActiveClients( List<User> pUserList , ServerDLG pmain)
        {
            main = pmain;
            m_pUserList = pUserList;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            new EditUser(int.Parse(btn.Name),m_pUserList, main).Show();
        }

        private void isActiveClients_Load(object sender, EventArgs e)
        {
            ActiveClientList();
        }

        private void ActiveClientList()
        {
            int client = 0;
            foreach (User my in m_pUserList)
            {
                client++;

                Label lbl = new Label();
                Button btn = new Button();
                btn.Location = new System.Drawing.Point(118, 19);
                btn.Size = new System.Drawing.Size(126, 23);
                btn.TabIndex = 1;
                btn.Text = "Edit Client";
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.button1_Click);
                btn.Name = my.m_sSid.ToString();


                lbl.AutoSize = true;
                lbl.Location = new System.Drawing.Point(9, 16);
                lbl.Name = "label1";
                lbl.Size = new System.Drawing.Size(82, 26);
                lbl.TabIndex = 1;
                lbl.Text = "Soket ID : " + my.m_sSid.ToString("0000") + "\r\nIP : " + my.IP;

                GroupBox nwGroupBx = new GroupBox();
                nwGroupBx.Controls.Add(btn);
                nwGroupBx.Controls.Add(lbl);
                nwGroupBx.Location = new System.Drawing.Point(3, 3);
                nwGroupBx.Name = "groupBox1";
                nwGroupBx.Size = new System.Drawing.Size(250, 58);
                nwGroupBx.TabIndex = 0;
                nwGroupBx.TabStop = false;
                nwGroupBx.Text = "Client " + client.ToString("00");
                flowLayoutPanel1.Controls.Add(nwGroupBx);
            }
        }
    }
}
