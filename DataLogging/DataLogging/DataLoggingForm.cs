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
        private static int oldY = 0;
        void DrawVerticalLine(int newX) 
        {
            Graphics g = DisplayPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.Black,1);
            g.DrawLine(thePen, oldX, 0, oldX,DisplayPictureBox.Height);
            thePen.Color = Color.Lime;
            g.DrawLine(thePen, newX, 0, newX, DisplayPictureBox.Height);
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
            if (this.dataBuffer.Count >= 100)
            {
                dataBuffer.RemoveAt(0);    
            }
            this.dataBuffer.Add(RandomNumberZeroTo(DisplayPictureBox.Height, 0)); 
        }

        void GraphDataPoint(int dataX,int dataY) 
        {
            Graphics g = DisplayPictureBox.CreateGraphics();
            Pen thePen = new Pen(Color.Black, 1);
            g.DrawLine(thePen,dataX,0,dataX,DisplayPictureBox.Height);
            thePen.Color = Color.Lime;
            g.DrawLine(thePen, dataX-1,oldY,dataX,dataY);
            oldY = dataY;
            g.Dispose();
            thePen.Dispose();
        }

        void UpdateGraph() 
        {
            //DisplayPictureBox.Refresh();
            int dataX = 0;
            foreach (int dataY in this.dataBuffer) 
            {
                GraphDataPoint(dataX,dataY);
                dataX++;
            }
            
        }

        //Event Handlers------------------------------------------------------------------------------------------------------------------------
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            DisplayPictureBox.Refresh();
            SetDefaults();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            if (DataAqTimer.Enabled == true)
            {
                DataAqTimer.Enabled = false;
            }
            else 
            { 
                DataAqTimer.Enabled = true;
            }
        }

        private void DisplayMove(object sender, MouseEventArgs e) 
        { 
            this.Text = e.X.ToString();
            DrawVerticalLine(e.X);
            oldX = e.X;
        }
        private void DataAqTimer_Tick(object sender, EventArgs e)
        {
            GrabDataPoint();
            UpdateGraph();
        }
    }
}
