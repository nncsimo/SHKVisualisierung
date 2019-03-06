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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SelectResourceType
            // 
            this.SelectResourceType.FormattingEnabled = true;
            this.SelectResourceType.Location = new System.Drawing.Point(33, 111);
            this.SelectResourceType.Name = "SelectResourceType";
            this.SelectResourceType.Size = new System.Drawing.Size(121, 24);
            this.SelectResourceType.TabIndex = 0;
            this.SelectResourceType.SelectedIndexChanged += new System.EventHandler(this.SelectResourceType_SelectedIndexChanged);
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
            // RefreshSchedule
            // 
            this.RefreshSchedule.Location = new System.Drawing.Point(33, 283);
            this.RefreshSchedule.Name = "RefreshSchedule";
            this.RefreshSchedule.Size = new System.Drawing.Size(121, 31);
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
            this.ExportToPNG.Location = new System.Drawing.Point(33, 338);
            this.ExportToPNG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportToPNG.Name = "ExportToPNG";
            this.ExportToPNG.Size = new System.Drawing.Size(120, 31);
            this.ExportToPNG.TabIndex = 3;
            this.ExportToPNG.TabStop = false;
            this.ExportToPNG.Text = "Export as PNG";
            this.ExportToPNG.UseVisualStyleBackColor = true;
            this.ExportToPNG.Click += new System.EventHandler(this.ExportToPNG_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 382);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 4;
            this.button1.TabStop = false;
            this.button1.Text = "Export as PDF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExportToPDF);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ExportToPNG);
            this.Controls.Add(this.RefreshSchedule);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.SelectResourceType);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox SelectResourceType;
        private System.Windows.Forms.Button OpenFile;
        private System.Windows.Forms.Button RefreshSchedule;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ExportToPNG;
        private System.Windows.Forms.Button button1;
    }
}