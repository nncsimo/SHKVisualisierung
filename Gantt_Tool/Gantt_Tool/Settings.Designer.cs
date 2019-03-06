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
            this.SelectResourceType = new System.Windows.Forms.ComboBox();
            this.OpenFile = new System.Windows.Forms.Button();
            this.RefreshSchedule = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ExportToPNG = new System.Windows.Forms.Button();
            this.DisplayResourceConsumptionAtTime = new System.Windows.Forms.CheckBox();
            this.DisplayMakespan = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // SelectResourceType
            // 
            this.SelectResourceType.FormattingEnabled = true;
            this.SelectResourceType.Location = new System.Drawing.Point(50, 173);
            this.SelectResourceType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SelectResourceType.Name = "SelectResourceType";
            this.SelectResourceType.Size = new System.Drawing.Size(180, 33);
            this.SelectResourceType.TabIndex = 0;
            this.SelectResourceType.SelectedIndexChanged += new System.EventHandler(this.SelectResourceType_SelectedIndexChanged);
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(50, 44);
            this.OpenFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(182, 50);
            this.OpenFile.TabIndex = 1;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.OpenFile_Click);
            // 
            // RefreshSchedule
            // 
            this.RefreshSchedule.Location = new System.Drawing.Point(50, 442);
            this.RefreshSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RefreshSchedule.Name = "RefreshSchedule";
            this.RefreshSchedule.Size = new System.Drawing.Size(182, 48);
            this.RefreshSchedule.TabIndex = 2;
            this.RefreshSchedule.Text = "Refresh";
            this.RefreshSchedule.UseVisualStyleBackColor = true;
            this.RefreshSchedule.Click += new System.EventHandler(this.RefreshSchedule_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ExportToPNG
            // 
            this.ExportToPNG.Location = new System.Drawing.Point(50, 528);
            this.ExportToPNG.Name = "ExportToPNG";
            this.ExportToPNG.Size = new System.Drawing.Size(180, 48);
            this.ExportToPNG.TabIndex = 3;
            this.ExportToPNG.TabStop = false;
            this.ExportToPNG.Text = "Export as PNG";
            this.ExportToPNG.UseVisualStyleBackColor = true;
            this.ExportToPNG.Click += new System.EventHandler(this.ExportToPNG_Click);
            // 
            // DisplayResourceConsumptionAtTime
            // 
            this.DisplayResourceConsumptionAtTime.AutoSize = true;
            this.DisplayResourceConsumptionAtTime.Location = new System.Drawing.Point(50, 225);
            this.DisplayResourceConsumptionAtTime.Name = "DisplayResourceConsumptionAtTime";
            this.DisplayResourceConsumptionAtTime.Size = new System.Drawing.Size(406, 29);
            this.DisplayResourceConsumptionAtTime.TabIndex = 4;
            this.DisplayResourceConsumptionAtTime.Text = "Display ResourceConsumptionAtTime";
            this.DisplayResourceConsumptionAtTime.UseVisualStyleBackColor = true;
            this.DisplayResourceConsumptionAtTime.CheckedChanged += new System.EventHandler(this.DisplayResourceConsumptionAtTime_CheckedChanged);
            // 
            // DisplayMakespan
            // 
            this.DisplayMakespan.AutoSize = true;
            this.DisplayMakespan.Location = new System.Drawing.Point(50, 261);
            this.DisplayMakespan.Name = "DisplayMakespan";
            this.DisplayMakespan.Size = new System.Drawing.Size(221, 29);
            this.DisplayMakespan.TabIndex = 5;
            this.DisplayMakespan.Text = "Display Makespan";
            this.DisplayMakespan.UseVisualStyleBackColor = true;
            this.DisplayMakespan.CheckedChanged += new System.EventHandler(this.DisplayMakespan_CheckedChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 703);
            this.Controls.Add(this.DisplayMakespan);
            this.Controls.Add(this.DisplayResourceConsumptionAtTime);
            this.Controls.Add(this.ExportToPNG);
            this.Controls.Add(this.RefreshSchedule);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.SelectResourceType);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectResourceType;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button RefreshSchedule;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ExportToPNG;
        private System.Windows.Forms.CheckBox DisplayResourceConsumptionAtTime;
        private System.Windows.Forms.CheckBox DisplayMakespan;
    }
}