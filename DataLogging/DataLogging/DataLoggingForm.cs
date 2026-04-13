using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataLogging
{
    public partial class DataLoggingForm : Form
    {
        private List<int> dataBuffer = new List<int>(); // data y values
        SerialPort serialPort1 = new SerialPort();
        public DataLoggingForm()
        {
            InitializeComponent();
            SetDisplayDefaults();
            GetQYAtBoards();
            DefaultValues();
        }
        //Program Logic-------------------------------------------------------------------------------------------------------------------------

        void SetDisplayDefaults() 
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

        void DefaultValues() 
        {
            TimeComboBox.Items.Clear();
            TimeComboBox.Items.Add("100 mS");
            TimeComboBox.Items.Add("200 mS");
            TimeComboBox.Items.Add("500 mS");
            TimeComboBox.Items.Add("1 S");
            TimeComboBox.Items.Add("5 S");
            TimeComboBox.Items.Add("10 S");
            TimeComboBox.Items.Add("30 S");
            TimeComboBox.Items.Add("1 Min");
            TimeComboBox.Items.Add("5 Min");
            TimeComboBox.Items.Add("10 Min");
            TimeComboBox.SelectedIndex = 0;
            Analog1RadioButton.Checked = true;
        }
        void DrawVerticalLine(int newX) 
        {
            cursor = newX;
            DisplayPictureBox.Invalidate();
        }
        private readonly Random random = new Random();
        private int AnalogValues() 
        {
            int conversion = 0;
            int analog = 0;
            if (Analog1RadioButton.Checked) 
            {
                analog = int.Parse(Analog1StatusLabel.Text);
            }
            if (Analog2RadioButton.Checked)
            {
                analog = int.Parse(Analog2StatusLabel.Text);
            }
            conversion = analog*99/1024;
            conversion++;
            return conversion;
        }
        void GrabDataPoint() 
        {
            int currentData = AnalogValues();
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
                string analog = "";
                int analogData = 0;
                if (Analog1RadioButton.Checked == true) 
                {
                    analog = "Analog1:";
                    analogData = int.Parse(Analog1StatusLabel.Text);
                }
                if (Analog2RadioButton.Checked == true) 
                {
                    analog = "Analog2:";
                    analogData = int.Parse(Analog2StatusLabel.Text);
                }
                string path = $"..\\..\\logs\\log_{DateTime.Now.ToString("yyMMddHH")}.log";
                using (StreamWriter currentFile = File.AppendText(path))
                {
                    currentFile.WriteLine($"{DateTime.Now:yy/MM/dd/HH:mm:ss.}{DateTime.Now.Millisecond:D3},{analog},{currentData},Display Value,{analogData}");
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
                    dataBuffer.Add(int.Parse(temp[2]));
                    length++;
                }
            }
            DataTrackBar.Maximum = length-100;
            if (DataTrackBar.Maximum < 0) 
            {
                DataTrackBar.Maximum = 0;
            }
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    GraphDataPoint(i, dataBuffer.ElementAt(i));
                }
            }
            catch (Exception ex) 
            { 
            }
        }

        void SerialConnect(string name)
        {
            serialPort1.Close();
            serialPort1.BaudRate = 115200;
            serialPort1.PortName = name;
            serialPort1.Parity = System.IO.Ports.Parity.None;
            //serialPort1.StopBits = System.IO.Ports.StopBits.None;
            try
            {
                serialPort1.Open();
                if (serialPort1.IsOpen)
                {
                    //MessageBox.Show($"{serialPort1.PortName} Connected Successfully");
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            //ConnectButton.Enabled = false;
        }
        byte[] SendData(byte[] data)
        {
            byte[] buffer = new byte[0];
            try
            {

                if (serialPort1.IsOpen)
                {
                    //flush old bytes from buffers
                    serialPort1.DiscardInBuffer();
                    serialPort1.DiscardOutBuffer();

                    //send command
                    serialPort1.Write(data, 0, data.Length);

                    //wait for response
                    Thread.Sleep(50);
                    //make the array the size of the input buffer
                    buffer = new byte[serialPort1.BytesToRead];
                    //actually read the input buffer
                    serialPort1.Read(buffer, 0, buffer.Length);
                }
                return buffer;
            }
            catch
            {
                return buffer;
            }
        }

        void GetQYAtBoards()
        {
            PortComboBox.Text = "";
            PortComboBox.Items.Clear();
            string[] names = SerialPort.GetPortNames();
            foreach (string name in names)
            {
                SerialConnect(name);
                if (IsQYAtBoardCheck())
                {
                    PortComboBox.Items.Add(name);
                }
            }
            if (PortComboBox.Items.Count > 0)
            {
                PortComboBox.SelectedIndex = 0;
            }
            serialPort1.Close();
        }

        bool IsQYAtBoardCheck()
        {
            bool QYAt = false;
            byte[] QyAtSettings = { 0xf0 };
            byte[] ReadBuffer = SendData(QyAtSettings);
            if (ReadBuffer.Length == 64 && ReadBuffer[58] == 81 && ReadBuffer[59] == 121 && ReadBuffer[60] == 64)
            {
                //MessageBox.Show($"QY@ Board Connected  to {serialPort1.PortName}");
                QYAt = true;
            }
            return QYAt;
        }
        int ReadAnalogOne()
        {
            byte[] data = { 0x51 };
            byte[] response = SendData(data);
            if (response.Length == 2)
            {
                return (response[0] << 2) + (response[1] >> 6);
            }
            return -1;
        }
        int ReadAnalogTwo()
        {
            byte[] data = { 0x52 };
            byte[] response = SendData(data);
            if (response.Length == 2)
            {
                return (response[0] << 2) + (response[1] >> 6);
            }
            return -1;
        }

        void LoadTimer() 
        { 
            if (TimeComboBox.SelectedIndex == 0) 
            {
                DataAqTimer.Interval = 100;
            }
            else if (TimeComboBox.SelectedIndex == 1)
            {
                DataAqTimer.Interval = 200;
            }
            else if (TimeComboBox.SelectedIndex == 2)
            {
                DataAqTimer.Interval = 500;
            }
            else if (TimeComboBox.SelectedIndex == 3)
            {
                DataAqTimer.Interval = 1000;
            }
            else if (TimeComboBox.SelectedIndex == 4)
            {
                DataAqTimer.Interval = 5000;
            }
            else if (TimeComboBox.SelectedIndex == 5)
            {
                DataAqTimer.Interval = 10000;
            }
            else if (TimeComboBox.SelectedIndex == 6)
            {
                DataAqTimer.Interval = 30000;
            }
            else if (TimeComboBox.SelectedIndex == 7)
            {
                DataAqTimer.Interval = 60000;
            }
            else if (TimeComboBox.SelectedIndex == 8)
            {
                DataAqTimer.Interval = 300000;
            }
            else if (TimeComboBox.SelectedIndex == 9)
            {
                DataAqTimer.Interval = 600000;
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
            SetDisplayDefaults();
        }

        private void GraphButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                if (DataAqTimer.Enabled == true)
                {
                    DataAqTimer.Enabled = false;
                    LoadLogFiles();
                    Analog1RadioButton.Enabled = true;
                    Analog2RadioButton.Enabled = true;
                    DisplayValueTextBox.Show();
                }
                else
                {
                    DataAqTimer.Enabled = true;
                    DataTrackBar.Enabled = false;
                    DataTrackBar.Value = 0;
                    Analog1RadioButton.Enabled = false;
                    Analog2RadioButton.Enabled = false;
                    DisplayValueTextBox.Hide();
                }
            }
            else 
            {
                DataAqTimer.Enabled = false;
                LoadLogFiles();
            }
        }

        private void DisplayMove(object sender, MouseEventArgs e) 
        {
            int y = e.Y;
            double value = (y-285)*(-(1024.0/285.0));
            value = Math.Round(value);
            DisplayValueTextBox.Text = value.ToString();
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
            DataTrackBar.Value = 0;
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

        private void Reloadtimer_Tick(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                PortStatusLabel.Text = serialPort1.PortName;
            }
            else 
            {
                PortStatusLabel.Text = "None";
            }
          
            Analog1StatusLabel.Text =ReadAnalogOne().ToString();
            Analog2StatusLabel.Text =ReadAnalogTwo().ToString();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                GetQYAtBoards();
            }
        }

        private void ConnectButton_Click(object sender, EventArgs e)
        {
            if (PortComboBox.SelectedIndex != -1)
            {
                SerialConnect(PortComboBox.SelectedItem.ToString());
            }
        }

        private void TimeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTimer();
        }
    }
}
