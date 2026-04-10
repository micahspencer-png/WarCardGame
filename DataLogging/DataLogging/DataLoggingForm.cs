using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            graphBitMap = new Bitmap(DisplayPictureBox.Width,DisplayPictureBox.Height);
            DisplayPictureBox.Image = graphBitMap;
            LoadLogFiles();
        }
        private Bitmap graphBitMap;
        private int cursor;

        private static int oldX = 0;
        private static int oldY = 0;
        private static string LogFile = "";
        void DrawVerticalLine(int newX) 
        {
            
            //Graphics g = DisplayPictureBox.CreateGraphics();
            //Pen thePen = new Pen(Color.Black,1);
            //g.DrawLine(thePen, oldX, 0, oldX,DisplayPictureBox.Height);
            //thePen.Color = Color.Lime;
            //g.DrawLine(thePen, newX, 0, newX, DisplayPictureBox.Height);
            //g.Dispose();
            //thePen.Dispose();
            cursor = newX;
            DisplayPictureBox.Invalidate();
        }
        private readonly Random random = new Random();
        private int RandomNumberZeroTo(int max, int min) 
        {
            int temp = max - min;
            return random.Next(0,temp) + min;
        }

        void GrabDataPoint() 
        {
            int currentData = RandomNumberZeroTo(100, 0);
            while (this.dataBuffer.Count >= 100)
            {
                dataBuffer.RemoveAt(0);    
            }
            this.dataBuffer.Add(currentData);
            LogDataToFile(currentData);
        }

        void GraphDataPoint(int dataX,int dataY) 
        {
            using (Graphics g = Graphics.FromImage(graphBitMap)) 
            {
                float sx = DisplayPictureBox.Width / 100F;
                float sy = DisplayPictureBox.Height / 100F;
                g.ScaleTransform(sx, sy * -1);
                g.TranslateTransform(0, -100);
                using (Pen thePen = new Pen(Color.Lime, 0.25F) )
                {
                    Pen clear = new Pen(Color.Black, 1);
                    g.DrawLine(clear, dataX, 0, dataX, 100);
                    g.DrawLine(thePen, dataX - 1, oldY, dataX, dataY);
                    clear.Dispose();
                }
            }
            oldY = dataY;
            DisplayPictureBox.Invalidate();
        }

        void UpdateGraph() 
        {
            int dataX = 0;
            foreach (int dataY in this.dataBuffer) 
            {
                GraphDataPoint(dataX,dataY);
                dataX++;
            }
            
        }

        void LogDataToFile(int currentData)
        {
            try
            {
                string path = $"..\\..\\logs\\{DateTime.Now.ToString("yyMMddHH")}.log";
                using (StreamWriter currentFile = File.AppendText(path))
                {
                    currentFile.WriteLine($"{DateTime.Now:yyMMddHHmmss}{DateTime.Now.Millisecond.ToString("#####")},{currentData}");
                }
            }
            catch (Exception ex)
            {
            }
        }

        void LoadLogFiles()
        {
            LogComboBox.Items.Clear();
            try
            {
                string[] logFiles = Directory.GetFiles("..\\..\\logs", "*.log");
                foreach (string logFile in logFiles)
                {
                    string[] location = logFile.Split('\\');
                    LogComboBox.Items.Add(location[3]);
                }
            }
            catch 
            { 
            
            }
        }

        void GraphLogFile() 
        {
            string path = $"..\\..\\logs\\{LogFile}";
            string[] temp;
            int length = 0;
            dataBuffer.Clear();
            using (StreamReader currentFile = new StreamReader(path)) 
            {
                while (!currentFile.EndOfStream) 
                {
                    temp = currentFile.ReadLine().Split(',');
                    dataBuffer.Add(int.Parse(temp[1]));
                    length++;
                }
            }
            DataTrackBar.Maximum = length-100;
            for (int i = 0; i < 100; i++)
            {
                GraphDataPoint(i, dataBuffer.ElementAt(i));
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
                LoadLogFiles();
            }
            else 
            { 
                DataAqTimer.Enabled = true;
                DataTrackBar.Enabled = false;
                DataTrackBar.Value = 0;
            }
        }

        private void DisplayMove(object sender, MouseEventArgs e) 
        { 
            this.Text = e.X.ToString();
            DrawVerticalLine(e.X);
        }
        private void DataAqTimer_Tick(object sender, EventArgs e)
        {
            GrabDataPoint();
            UpdateGraph();
        }

        private void LogComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LogFile = LogComboBox.SelectedItem.ToString();
            GraphLogFile();
            ReloadButton.Enabled = true;
        }

        private void DataTrackBar_Scroll(object sender, EventArgs e)
        {
            int val = 0;
            val = DataTrackBar.Value;
            for (int i = 0; i < 100; i++) 
            {
                GraphDataPoint(i,dataBuffer.ElementAt(val+i));
            }
        }

        private void ReloadButton_Click(object sender, EventArgs e)
        {
            GraphLogFile();
            DataTrackBar.Value = DataTrackBar.Maximum;
            DataTrackBar.Enabled = true;
        }
        private void PaintLine(object sender, PaintEventArgs e)
        {
            if (cursor>=0) 
            {
                using (Pen thePen = new Pen(Color.Lime, 1))
                {
                    e.Graphics.DrawLine(thePen, cursor, 0, cursor, DisplayPictureBox.Height);
                }
            }
        }
    }
}
