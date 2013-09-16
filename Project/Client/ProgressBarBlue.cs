using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Client
{
    public partial class ProgressBarBlue : UserControl
    {
        public ProgressBarBlue()
        {
            InitializeComponent();
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int leftRect, int topRect, int rightRect, int bottomRect, int wEllipse, int hEllipse);

        private int Maxsimum;
        private int Minimum;
        public int Values;

        public int Update
        {
            get { return Values; }
            set
            {
                Values = value;
                if (Values > Maxsimum)
                {
                    Values = Maxsimum;
                    return;
                }
                DrawGrap();
            }
        }

        private void DrawGrap()
        {
            double percent = 0;
            try
            {
                percent = (100 * Values) / Maxsimum;
            }
            catch
            {
                percent = 0;
            }
            lblPercent1.Text = percent.ToString("0.00")+"%";
            int CurX, CurY;
            CurX = Convert.ToInt32((this.Size.Width / 100 ) * percent);
            CurY = panel1.Size.Height;
            panel1.Size =  new Size(CurX,CurY);
        }

        public int isMinimum
        {
            set { Minimum = value; }
            get { return Minimum; }
        }

        public int isMaximum
        {
            set { Maxsimum = value; }
            get { return Maxsimum; }
        }

        private void ProgressBarBlue_Load(object sender, EventArgs e)
        {
            Values = 0;
            DrawGrap();
        }
    }
}
