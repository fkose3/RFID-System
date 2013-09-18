namespace Server
{
    partial class windowsPane
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.OnlineUserTimer = new System.Windows.Forms.Timer(this.components);
            this.lstCommand = new System.Windows.Forms.ListBox();
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // OnlineUserTimer
            // 
            this.OnlineUserTimer.Enabled = true;
            this.OnlineUserTimer.Interval = 1000;
            this.OnlineUserTimer.Tick += new System.EventHandler(this.OnlineUserTimer_Tick);
            // 
            // lstCommand
            // 
            this.lstCommand.BackColor = System.Drawing.SystemColors.InfoText;
            this.lstCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lstCommand.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.lstCommand.FormattingEnabled = true;
            this.lstCommand.ItemHeight = 20;
            this.lstCommand.Location = new System.Drawing.Point(0, 0);
            this.lstCommand.Name = "lstCommand";
            this.lstCommand.Size = new System.Drawing.Size(835, 414);
            this.lstCommand.TabIndex = 3;
            // 
            // txtCommand
            // 
            this.txtCommand.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCommand.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCommand.ForeColor = System.Drawing.Color.Silver;
            this.txtCommand.Location = new System.Drawing.Point(0, 384);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(835, 30);
            this.txtCommand.TabIndex = 5;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // windowsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(835, 414);
            this.Controls.Add(this.txtCommand);
            this.Controls.Add(this.lstCommand);
            this.Name = "windowsPane";
            this.Text = "Server Program";
            this.Load += new System.EventHandler(this.windowsPane_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer OnlineUserTimer;
        private System.Windows.Forms.ListBox lstCommand;
        private System.Windows.Forms.TextBox txtCommand;
    }
}