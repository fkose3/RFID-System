namespace Server
{
    partial class z
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
            this.sid_List = new System.Windows.Forms.Button();
            this.Send_Packet = new System.Windows.Forms.Button();
            this.txtSocket = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sid_List
            // 
            this.sid_List.Location = new System.Drawing.Point(12, 12);
            this.sid_List.Name = "sid_List";
            this.sid_List.Size = new System.Drawing.Size(254, 45);
            this.sid_List.TabIndex = 0;
            this.sid_List.Text = "Socket ID List";
            this.sid_List.UseVisualStyleBackColor = true;
            this.sid_List.Click += new System.EventHandler(this.sid_List_Click);
            // 
            // Send_Packet
            // 
            this.Send_Packet.Location = new System.Drawing.Point(272, 12);
            this.Send_Packet.Name = "Send_Packet";
            this.Send_Packet.Size = new System.Drawing.Size(254, 45);
            this.Send_Packet.TabIndex = 1;
            this.Send_Packet.Text = "Send Packet";
            this.Send_Packet.UseVisualStyleBackColor = true;
            // 
            // txtSocket
            // 
            this.txtSocket.Location = new System.Drawing.Point(12, 79);
            this.txtSocket.Name = "txtSocket";
            this.txtSocket.Size = new System.Drawing.Size(254, 20);
            this.txtSocket.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Socket ID ";
            // 
            // z
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSocket);
            this.Controls.Add(this.Send_Packet);
            this.Controls.Add(this.sid_List);
            this.Name = "z";
            this.Text = "TestPacket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sid_List;
        private System.Windows.Forms.Button Send_Packet;
        private System.Windows.Forms.TextBox txtSocket;
        private System.Windows.Forms.Label label1;
    }
}