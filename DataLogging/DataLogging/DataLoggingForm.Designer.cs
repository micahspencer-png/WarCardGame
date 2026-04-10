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
            ((System.ComponentModel.ISupportInitialize)(this.DisplayPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTrackBar)).BeginInit();
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
            this.DisplayPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DisplayMove);
            this.DisplayPictureBox.Paint += this.PaintLine;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(915, 501);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(89, 51);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "E&xit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(820, 501);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(89, 51);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "&Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // GraphButton
            // 
            this.GraphButton.Location = new System.Drawing.Point(725, 501);
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
            this.DataTrackBar.Location = new System.Drawing.Point(12, 372);
            this.DataTrackBar.Name = "DataTrackBar";
            this.DataTrackBar.Size = new System.Drawing.Size(271, 56);
            this.DataTrackBar.TabIndex = 3;
            this.DataTrackBar.Scroll += new System.EventHandler(this.DataTrackBar_Scroll);
            // 
            // ReloadButton
            // 
            this.ReloadButton.Enabled = false;
            this.ReloadButton.Location = new System.Drawing.Point(638, 501);
            this.ReloadButton.Name = "ReloadButton";
            this.ReloadButton.Size = new System.Drawing.Size(87, 50);
            this.ReloadButton.TabIndex = 4;
            this.ReloadButton.Text = "&Reload";
            this.ReloadButton.UseVisualStyleBackColor = true;
            this.ReloadButton.Click += new System.EventHandler(this.ReloadButton_Click);
            // 
            // DataLoggingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 564);
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
    }
}

