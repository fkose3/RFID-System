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
            this.txtCommand = new System.Windows.Forms.TextBox();
            this.lstCommand = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OnlineUserTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCommand
            // 
            this.txtCommand.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtCommand.Location = new System.Drawing.Point(12, 354);
            this.txtCommand.Multiline = true;
            this.txtCommand.Name = "txtCommand";
            this.txtCommand.Size = new System.Drawing.Size(407, 30);
            this.txtCommand.TabIndex = 0;
            this.txtCommand.TextChanged += new System.EventHandler(this.txtCommand_TextChanged);
            this.txtCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCommand_KeyDown);
            // 
            // lstCommand
            // 
            this.lstCommand.FormattingEnabled = true;
            this.lstCommand.Location = new System.Drawing.Point(12, 19);
            this.lstCommand.Name = "lstCommand";
            this.lstCommand.Size = new System.Drawing.Size(407, 329);
            this.lstCommand.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstCommand);
            this.groupBox1.Controls.Add(this.txtCommand);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(432, 390);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program Command";
            // 
            // OnlineUserTimer
            // 
            this.OnlineUserTimer.Enabled = true;
            this.OnlineUserTimer.Interval = 1000;
            this.OnlineUserTimer.Tick += new System.EventHandler(this.OnlineUserTimer_Tick);
            // 
            // windowsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 414);
            this.Controls.Add(this.groupBox1);
            this.Name = "windowsPane";
            this.Text = "Server Program";
            this.Load += new System.EventHandler(this.windowsPane_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommand;
        private System.Windows.Forms.ListBox lstCommand;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Timer OnlineUserTimer;
    }
}