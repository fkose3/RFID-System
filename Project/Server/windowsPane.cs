using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Server
{
    public partial class windowsPane : Form
    {
        ServerDLG m_pMain = null;
        bool isCommandClear = false;
        public windowsPane( ServerDLG pMain = null)
        {
            InitializeComponent();
            m_pMain = pMain;
        }

        private void windowsPane_Load(object sender, EventArgs e)
        {
            txtCommand.Focus();
            txtCommand.Select();
        }

        private void txtCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;

            string command = txtCommand.Text;
                                    
            switch (command.ToLower())
            {
                case "help":
                    lstCommand.Items.Add("IsCommand List");
                    lstCommand.Items.Add("Active Client Edits [ActiveClient] ");
                    break;
                case "activeclient":
                    lstCommand.Items.Add("-> Active Client list [  " + m_pMain.m_UserArray.Count + "  ]");
                    new isActiveClients(m_pMain.m_UserArray,m_pMain).Show();
                    break;
                
                default:
                    if( command != "")
                    lstCommand.Items.Add("Bad Command [ " + command + " ]");
                    break;
            }

            command = "";
            isCommandClear = true;
        }

        private void txtCommand_TextChanged(object sender, EventArgs e)
        {
            if (isCommandClear)
                this.txtCommand.Text = "";

            isCommandClear = false;
        }

        private void OnlineUserTimer_Tick(object sender, EventArgs e)
        {
            m_pMain.TimerFunction();
        }

        
    }
}
