using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLogging
{
    public partial class DataLoggingForm : Form
    {
        private List<int> dataBuffer = new List<int>(); // data y values
        public DataLoggingForm()
        {
            InitializeComponent();
            SetDefaults();
        }
        //Program Logic-------------------------------------------------------------------------------------------------------------------------

        void SetDefaults() 
        { 
            DisplayPictureBox.BackColor = Color.Black;
        }

        private static int oldX = 0;
        void DrawVerticalLine(int newX) 
        {
            Graphics g = DisplayPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.LimeGreen,1);
            Pen erase = new Pen(Color.Black,1);
            g.DrawLine(thePen, newX, 0, newX,DisplayPictureBox.Height);
            g.DrawLine(erase, oldX, 0, oldX, DisplayPictureBox.Height);
            g.Dispose();
            thePen.Dispose();
        }
        private readonly Random random = new Random();
        private int RandomNumberZeroTo(int max, int min) 
        {
            int temp = max - min;
            return random.Next(0,temp) + min;
        }

        void GrabDataPoint() 
        {
            this.dataBuffer.Add(RandomNumberZeroTo(DisplayPictureBox.Height, 0));
        }

        //Event Handlers------------------------------------------------------------------------------------------------------------------------
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            
        }

        private void DisplayPictureBox_MouseMove(object sender, MouseEventArgs e) 
        { 
            this.Text = e.X.ToString();
            DrawVerticalLine(e.X);
            oldX = e.X;
        }

        private void DataAqTimer_Tick(object sender, EventArgs e)
        {
            GrabDataPoint();
        }
    }
}
