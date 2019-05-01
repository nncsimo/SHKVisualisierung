namespace Gantt_Tool
{
    partial class Settings
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
            this.OpenFile = new System.Windows.Forms.Button();
            this.NewChartWindow = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.DisplayResourceConsumptionAtTime = new System.Windows.Forms.CheckBox();
            this.DisplayMakespan = new System.Windows.Forms.CheckBox();
            this.label_filename = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(33, 28);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(121, 32);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // NewChartWindow
            // 
            this.NewChartWindow.Location = new System.Drawing.Point(33, 185);
            this.NewChartWindow.Name = "NewChartWindow";
            this.NewChartWindow.Size = new System.Drawing.Size(166, 31);
            this.NewChartWindow.TabIndex = 2;
            this.NewChartWindow.Text = "New Chart Window";
            this.NewChartWindow.UseVisualStyleBackColor = true;
            this.NewChartWindow.Click += new System.EventHandler(this.NewChartWindow_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.AddExtension = false;
            this.openFileDialog.FileName = "MyScheduleFile";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // DisplayResourceConsumptionAtTime
            // 
            this.DisplayResourceConsumptionAtTime.AutoSize = true;
            this.DisplayResourceConsumptionAtTime.Location = new System.Drawing.Point(33, 104);
            this.DisplayResourceConsumptionAtTime.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DisplayResourceConsumptionAtTime.Name = "DisplayResourceConsumptionAtTime";
            this.DisplayResourceConsumptionAtTime.Size = new System.Drawing.Size(267, 21);
            this.DisplayResourceConsumptionAtTime.TabIndex = 4;
            this.DisplayResourceConsumptionAtTime.Text = "Display ResourceConsumptionAtTime";
            this.DisplayResourceConsumptionAtTime.UseVisualStyleBackColor = true;
            this.DisplayResourceConsumptionAtTime.CheckedChanged += new System.EventHandler(this.DisplayResourceConsumptionAtTime_CheckedChanged);
            // 
            // DisplayMakespan
            // 
            this.DisplayMakespan.AutoSize = true;
            this.DisplayMakespan.Location = new System.Drawing.Point(33, 127);
            this.DisplayMakespan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DisplayMakespan.Name = "DisplayMakespan";
            this.DisplayMakespan.Size = new System.Drawing.Size(145, 21);
            this.DisplayMakespan.TabIndex = 5;
            this.DisplayMakespan.Text = "Display Makespan";
            this.DisplayMakespan.UseVisualStyleBackColor = true;
            this.DisplayMakespan.CheckedChanged += new System.EventHandler(this.DisplayMakespan_CheckedChanged);
            // 
            // label_filename
            // 
            this.label_filename.AutoSize = true;
            this.label_filename.Location = new System.Drawing.Point(173, 36);
            this.label_filename.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_filename.Name = "label_filename";
            this.label_filename.Size = new System.Drawing.Size(0, 17);
            this.label_filename.TabIndex = 7;
            this.label_filename.Click += new System.EventHandler(this.label_filename_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label_filename);
            this.Controls.Add(this.DisplayMakespan);
            this.Controls.Add(this.DisplayResourceConsumptionAtTime);
            this.Controls.Add(this.NewChartWindow);
            this.Controls.Add(this.OpenFile);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button NewChartWindow;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox DisplayResourceConsumptionAtTime;
        private System.Windows.Forms.CheckBox DisplayMakespan;
        private System.Windows.Forms.Label label_filename;
    }
}