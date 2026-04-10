namespace DataLogging
{
    partial class DataLoggingForm
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
            this.DisplayPictureBox = new System.Windows.Forms.PictureBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.GraphButton = new System.Windows.Forms.Button();
            this.DataAqTimer = new System.Windows.Forms.Timer(this.components);
            this.LogComboBox = new System.Windows.Forms.ComboBox();
            this.DataTrackBar = new System.Windows.Forms.TrackBar();
            this.ReloadButton = new System.Windows.Forms.Button();
            this.PortComboBox = new System.Windows.Forms.ComboBox();
            this.TimeComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.PortStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Analog1StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Analog2StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.Analog1RadioButton = new System.Windows.Forms.RadioButton();
            this.Analog2RadioButton = new System.Windows.Forms.RadioButton();
            this.Reloadtimer = new System.Windows.Forms.Timer(this.components);
            this.ConnectButton = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.AnalogStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.AnalogStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTrackBar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayPictureBox
            // 
            this.DisplayPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DisplayPictureBox.Location = new System.Drawing.Point(12, 12);
            this.DisplayPictureBox.Name = "DisplayPictureBox";
            this.DisplayPictureBox.Size = new System.Drawing.Size(992, 354);
            this.DisplayPictureBox.TabIndex = 0;
            this.DisplayPictureBox.TabStop = false;
            this.DisplayPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintLine);
            this.DisplayPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayMove);
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(915, 485);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(89, 51);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(820, 485);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(89, 51);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // GraphButton
            // 
            this.GraphButton.Location = new System.Drawing.Point(725, 485);
            this.GraphButton.Name = "GraphButton";
            this.GraphButton.Size = new System.Drawing.Size(89, 51);
            this.GraphButton.TabIndex = 1;
            this.GraphButton.Text = "&Graph";
            this.GraphButton.UseVisualStyleBackColor = true;
            this.GraphButton.Click += new System.EventHandler(this.GraphButton_Click);
            // 
            // DataAqTimer
            // 
            this.DataAqTimer.Tick += new System.EventHandler(this.DataAqTimer_Tick);
            // 
            // LogComboBox
            // 
            this.LogComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogComboBox.FormattingEnabled = true;
            this.LogComboBox.Location = new System.Drawing.Point(812, 372);
            this.LogComboBox.Name = "LogComboBox";
            this.LogComboBox.Size = new System.Drawing.Size(192, 33);
            this.LogComboBox.TabIndex = 2;
            this.LogComboBox.SelectedIndexChanged += new System.EventHandler(this.LogComboBox_SelectedIndexChanged);
            // 
            // DataTrackBar
            // 
            this.DataTrackBar.Location = new System.Drawing.Point(12, 384);
            this.DataTrackBar.Name = "DataTrackBar";
            this.DataTrackBar.Size = new System.Drawing.Size(271, 56);
            this.DataTrackBar.TabIndex = 3;
            this.DataTrackBar.Scroll += new System.EventHandler(this.DataTrackBar_Scroll);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Enabled = false;
            this.ReloadButton.Location = new System.Drawing.Point(632, 485);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(87, 50);
            this.ReloadButton.TabIndex = 4;
            this.ReloadButton.Text = "&Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // PortComboBox
            // 
            this.PortComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortComboBox.FormattingEnabled = true;
            this.PortComboBox.Location = new System.Drawing.Point(12, 501);
            this.PortComboBox.Name = "PortComboBox";
            this.PortComboBox.Size = new System.Drawing.Size(121, 33);
            this.PortComboBox.TabIndex = 5;
            // 
            // TimeComboBox
            // 
            this.TimeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TimeComboBox.FormattingEnabled = true;
            this.TimeComboBox.Location = new System.Drawing.Point(881, 430);
            this.TimeComboBox.Name = "TimeComboBox";
            this.TimeComboBox.Size = new System.Drawing.Size(123, 33);
            this.TimeComboBox.TabIndex = 6;
            this.TimeComboBox.SelectedIndexChanged += new System.EventHandler(this.TimeComboBox_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PortStatusLabel,
            this.AnalogStatusLabel1,
            this.Analog1StatusLabel,
            this.AnalogStatusLabel2,
            this.Analog2StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 538);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1016, 26);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // PortStatusLabel
            // 
            this.PortStatusLabel.Name = "PortStatusLabel";
            this.PortStatusLabel.Size = new System.Drawing.Size(53, 20);
            this.PortStatusLabel.Text = "Label1";
            // 
            // Analog1StatusLabel
            // 
            this.Analog1StatusLabel.Name = "Analog1StatusLabel";
            this.Analog1StatusLabel.Size = new System.Drawing.Size(53, 20);
            this.Analog1StatusLabel.Text = "Label2";
            // 
            // Analog2StatusLabel
            // 
            this.Analog2StatusLabel.Name = "Analog2StatusLabel";
            this.Analog2StatusLabel.Size = new System.Drawing.Size(53, 20);
            this.Analog2StatusLabel.Text = "Label3";
            // 
            // Analog1RadioButton
            // 
            this.Analog1RadioButton.AutoSize = true;
            this.Analog1RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analog1RadioButton.Location = new System.Drawing.Point(363, 459);
            this.Analog1RadioButton.Name = "Analog1RadioButton";
            this.Analog1RadioButton.Size = new System.Drawing.Size(106, 29);
            this.Analog1RadioButton.TabIndex = 8;
            this.Analog1RadioButton.TabStop = true;
            this.Analog1RadioButton.Text = "Analog1";
            this.Analog1RadioButton.UseVisualStyleBackColor = true;
            // 
            // Analog2RadioButton
            // 
            this.Analog2RadioButton.AutoSize = true;
            this.Analog2RadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Analog2RadioButton.Location = new System.Drawing.Point(363, 494);
            this.Analog2RadioButton.Name = "Analog2RadioButton";
            this.Analog2RadioButton.Size = new System.Drawing.Size(106, 29);
            this.Analog2RadioButton.TabIndex = 8;
            this.Analog2RadioButton.TabStop = true;
            this.Analog2RadioButton.Text = "Analog2";
            this.Analog2RadioButton.UseVisualStyleBackColor = true;
            // 
            // Reloadtimer
            // 
            this.Reloadtimer.Enabled = true;
            this.Reloadtimer.Interval = 300;
            this.Reloadtimer.Tick += new System.EventHandler(this.Reloadtimer_Tick);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(159, 501);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(83, 31);
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(248, 501);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(77, 31);
            this.RefreshButton.TabIndex = 10;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // AnalogStatusLabel1
            // 
            this.AnalogStatusLabel1.Name = "AnalogStatusLabel1";
            this.AnalogStatusLabel1.Size = new System.Drawing.Size(68, 20);
            this.AnalogStatusLabel1.Text = "Analog1:";
            // 
            // AnalogStatusLabel2
            // 
            this.AnalogStatusLabel2.Name = "AnalogStatusLabel2";
            this.AnalogStatusLabel2.Size = new System.Drawing.Size(68, 20);
            this.AnalogStatusLabel2.Text = "Analog2:";
            // 
            // DataLoggingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 564);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.Analog2RadioButton);
            this.Controls.Add(this.Analog1RadioButton);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.TimeComboBox);
            this.Controls.Add(this.PortComboBox);
            this.Controls.Add(this.ReloadButton);
            this.Controls.Add(this.DataTrackBar);
            this.Controls.Add(this.LogComboBox);
            this.Controls.Add(this.GraphButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.DisplayPictureBox);
            this.MaximizeBox = false;
            this.Name = "DataLoggingForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Logging Form";
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTrackBar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.PictureBox DisplayPictureBox;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button GraphButton;
        private System.Windows.Forms.Timer DataAqTimer;
        private System.Windows.Forms.ComboBox LogComboBox;
        private System.Windows.Forms.TrackBar DataTrackBar;
        private System.Windows.Forms.Button ReloadButton;
        private System.Windows.Forms.ComboBox PortComboBox;
        private System.Windows.Forms.ComboBox TimeComboBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel PortStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel Analog1StatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel Analog2StatusLabel;
        private System.Windows.Forms.RadioButton Analog1RadioButton;
        private System.Windows.Forms.RadioButton Analog2RadioButton;
        private System.Windows.Forms.Timer Reloadtimer;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ToolStripStatusLabel AnalogStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel AnalogStatusLabel2;
    }
}

