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
            this.btnDersprogrami = new System.Windows.Forms.Button();
            this.btnNotlist = new System.Windows.Forms.Button();
            this.btnDevamsizlik = new System.Windows.Forms.Button();
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
            this.ProcessBar.Controls.Add(this.btnDersprogrami);
            this.ProcessBar.Controls.Add(this.btnNotlist);
            this.ProcessBar.Controls.Add(this.btnDevamsizlik);
            this.ProcessBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.ProcessBar.Location = new System.Drawing.Point(0, 0);
            this.ProcessBar.Name = "ProcessBar";
            this.ProcessBar.Size = new System.Drawing.Size(240, 348);
            this.ProcessBar.TabIndex = 0;
            // 
            // btnDersprogrami
            // 
            this.btnDersprogrami.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDersprogrami.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDersprogrami.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDersprogrami.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnDersprogrami.Location = new System.Drawing.Point(6, 123);
            this.btnDersprogrami.Name = "btnDersprogrami";
            this.btnDersprogrami.Size = new System.Drawing.Size(228, 52);
            this.btnDersprogrami.TabIndex = 5;
            this.btnDersprogrami.Text = "Ders Programı";
            this.btnDersprogrami.UseVisualStyleBackColor = false;
            // 
            // btnNotlist
            // 
            this.btnNotlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnNotlist.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNotlist.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNotlist.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNotlist.Location = new System.Drawing.Point(6, 65);
            this.btnNotlist.Name = "btnNotlist";
            this.btnNotlist.Size = new System.Drawing.Size(228, 52);
            this.btnNotlist.TabIndex = 4;
            this.btnNotlist.Text = "Not Listeleme";
            this.btnNotlist.UseVisualStyleBackColor = false;
            // 
            // btnDevamsizlik
            // 
            this.btnDevamsizlik.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.btnDevamsizlik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDevamsizlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDevamsizlik.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnDevamsizlik.Location = new System.Drawing.Point(6, 7);
            this.btnDevamsizlik.Name = "btnDevamsizlik";
            this.btnDevamsizlik.Size = new System.Drawing.Size(228, 52);
            this.btnDevamsizlik.TabIndex = 3;
            this.btnDevamsizlik.Text = "Devamsızlık Listeleme";
            this.btnDevamsizlik.UseVisualStyleBackColor = true;
            this.btnDevamsizlik.Click += new System.EventHandler(this.button1_Click);
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
        private System.Windows.Forms.Button btnDersprogrami;
        private System.Windows.Forms.Button btnNotlist;
        private System.Windows.Forms.Button btnDevamsizlik;
        private System.Windows.Forms.Timer PacketTimer;
    }
}

