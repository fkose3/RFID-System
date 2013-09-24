namespace OgretimGorevlisi
{
    partial class main
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
            this.PacketTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.LoginTimer = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOgrenci = new System.Windows.Forms.Button();
            this.btnNot = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PacketTimer
            // 
            this.PacketTimer.Enabled = true;
            this.PacketTimer.Interval = 15000;
            this.PacketTimer.Tick += new System.EventHandler(this.PacketTimer_Tick);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 10);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.AliceBlue;
            this.label1.Location = new System.Drawing.Point(310, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Kullanıcı Girişi bekleniyor..!";
            // 
            // LoginTimer
            // 
            this.LoginTimer.Enabled = true;
            this.LoginTimer.Interval = 1000;
            this.LoginTimer.Tick += new System.EventHandler(this.LoginTimer_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Controls.Add(this.btnNot);
            this.panel2.Controls.Add(this.btnOgrenci);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(225, 387);
            this.panel2.TabIndex = 1;
            // 
            // btnOgrenci
            // 
            this.btnOgrenci.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnOgrenci.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOgrenci.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOgrenci.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOgrenci.Location = new System.Drawing.Point(3, 3);
            this.btnOgrenci.Name = "btnOgrenci";
            this.btnOgrenci.Size = new System.Drawing.Size(219, 48);
            this.btnOgrenci.TabIndex = 3;
            this.btnOgrenci.Text = "Öğrenci ";
            this.btnOgrenci.UseVisualStyleBackColor = false;
            // 
            // btnNot
            // 
            this.btnNot.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.btnNot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNot.Location = new System.Drawing.Point(3, 57);
            this.btnNot.Name = "btnNot";
            this.btnNot.Size = new System.Drawing.Size(219, 48);
            this.btnNot.TabIndex = 4;
            this.btnNot.Text = "Not işlemleri";
            this.btnNot.UseVisualStyleBackColor = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 387);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "main";
            this.Text = "Öğretim üyeleri";
            this.Load += new System.EventHandler(this.main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer PacketTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer LoginTimer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNot;
        private System.Windows.Forms.Button btnOgrenci;
    }
}

