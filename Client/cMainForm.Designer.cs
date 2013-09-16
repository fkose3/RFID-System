namespace Client
{
    partial class cMainForm
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
            this.pMainPanel = new System.Windows.Forms.Panel();
            this.inc = new System.Windows.Forms.Panel();
            this.ProcessBar = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.PacketTimer = new System.Windows.Forms.Timer(this.components);
            this.pMainPanel.SuspendLayout();
            this.ProcessBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pMainPanel
            // 
            this.pMainPanel.Controls.Add(this.inc);
            this.pMainPanel.Controls.Add(this.ProcessBar);
            this.pMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainPanel.Location = new System.Drawing.Point(0, 0);
            this.pMainPanel.Name = "pMainPanel";
            this.pMainPanel.Size = new System.Drawing.Size(985, 348);
            this.pMainPanel.TabIndex = 1;
            // 
            // inc
            // 
            this.inc.BackColor = System.Drawing.SystemColors.Desktop;
            this.inc.Dock = System.Windows.Forms.DockStyle.Left;
            this.inc.Location = new System.Drawing.Point(240, 0);
            this.inc.Name = "inc";
            this.inc.Size = new System.Drawing.Size(10, 348);
            this.inc.TabIndex = 1;
            // 
            // ProcessBar
            // 
            this.ProcessBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProcessBar.Controls.Add(this.button3);
            this.ProcessBar.Controls.Add(this.button2);
            this.ProcessBar.Controls.Add(this.button1);
            this.ProcessBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProcessBar.Location = new System.Drawing.Point(0, 0);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.Size = new System.Drawing.Size(240, 348);
            this.ProcessBar.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button3.Location = new System.Drawing.Point(6, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(228, 52);
            this.button3.TabIndex = 5;
            this.button3.Text = "Ders Programı";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button2.Location = new System.Drawing.Point(6, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(228, 52);
            this.button2.TabIndex = 4;
            this.button2.Text = "Not Listeleme";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(6, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(228, 52);
            this.button1.TabIndex = 3;
            this.button1.Text = "Devamsızlık Listeleme";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // PacketTimer
            // 
            this.PacketTimer.Enabled = true;
            this.PacketTimer.Interval = 25000;
            this.PacketTimer.Tick += new System.EventHandler(this.PacketTimer_Tick);
            // 
            // cMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 348);
            this.ControlBox = false;
            this.Controls.Add(this.pMainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "cMainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.cMainForm_Load);
            this.pMainPanel.ResumeLayout(false);
            this.ProcessBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pMainPanel;
        private System.Windows.Forms.Panel ProcessBar;
        private System.Windows.Forms.Panel inc;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer PacketTimer;
    }
}

