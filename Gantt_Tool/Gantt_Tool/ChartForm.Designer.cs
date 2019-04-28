namespace Gantt_Tool
{
    partial class ChartForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SelectedResourceType = new System.Windows.Forms.ComboBox();
            this.Resource = new System.Windows.Forms.Label();
            this.ExportPNG = new System.Windows.Forms.Button();
            this.ExportPDF = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart1.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.TopRight;
            chartArea2.AxisX.IsMarginVisible = false;
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Location = new System.Drawing.Point(42, 72);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chart1.Name = "chart1";
            series2.ChartArea = "ChartArea1";
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(1146, 566);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click_1);
            // 
            // SelectedResourceType
            // 
            this.SelectedResourceType.FormattingEnabled = true;
            this.SelectedResourceType.Location = new System.Drawing.Point(158, 18);
            this.SelectedResourceType.Name = "SelectedResourceType";
            this.SelectedResourceType.Size = new System.Drawing.Size(121, 33);
            this.SelectedResourceType.TabIndex = 2;
            this.SelectedResourceType.SelectedIndexChanged += new System.EventHandler(this.SelectedResourceType_SelectedIndexChanged);
            // 
            // Resource
            // 
            this.Resource.AutoSize = true;
            this.Resource.Location = new System.Drawing.Point(42, 21);
            this.Resource.Name = "Resource";
            this.Resource.Size = new System.Drawing.Size(110, 25);
            this.Resource.TabIndex = 3;
            this.Resource.Text = "Resource:";
            // 
            // ExportPNG
            // 
            this.ExportPNG.Location = new System.Drawing.Point(760, 10);
            this.ExportPNG.Name = "ExportPNG";
            this.ExportPNG.Size = new System.Drawing.Size(182, 46);
            this.ExportPNG.TabIndex = 4;
            this.ExportPNG.Text = "Export to PNG";
            this.ExportPNG.UseVisualStyleBackColor = true;
            this.ExportPNG.Click += new System.EventHandler(this.ExportPNG_Click);
            // 
            // ExportPDF
            // 
            this.ExportPDF.Location = new System.Drawing.Point(969, 10);
            this.ExportPDF.Name = "ExportPDF";
            this.ExportPDF.Size = new System.Drawing.Size(182, 46);
            this.ExportPDF.TabIndex = 5;
            this.ExportPDF.Text = "Export to PDF";
            this.ExportPDF.UseVisualStyleBackColor = true;
            this.ExportPDF.Click += new System.EventHandler(this.ExportPDF_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1248, 675);
            this.Controls.Add(this.ExportPDF);
            this.Controls.Add(this.ExportPNG);
            this.Controls.Add(this.Resource);
            this.Controls.Add(this.SelectedResourceType);
            this.Controls.Add(this.chart1);
            this.Name = "ChartForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Output";
            this.Load += new System.EventHandler(this.ReadModel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ComboBox SelectedResourceType;
        private System.Windows.Forms.Label Resource;
        private System.Windows.Forms.Button ExportPNG;
        private System.Windows.Forms.Button ExportPDF;
    }
}