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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartForm));
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
            chartArea1.AxisX.IsMarginVisible = false;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Location = new System.Drawing.Point(28, 46);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(723, 672);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click_1);
            // 
            // SelectedResourceType
            // 
            this.SelectedResourceType.FormattingEnabled = true;
            this.SelectedResourceType.Location = new System.Drawing.Point(105, 12);
            this.SelectedResourceType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SelectedResourceType.Name = "SelectedResourceType";
            this.SelectedResourceType.Size = new System.Drawing.Size(82, 26);
            this.SelectedResourceType.TabIndex = 2;
            this.SelectedResourceType.SelectedIndexChanged += new System.EventHandler(this.SelectedResourceType_SelectedIndexChanged);
            // 
            // Resource
            // 
            this.Resource.AutoSize = true;
            this.Resource.Location = new System.Drawing.Point(28, 13);
            this.Resource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Resource.Name = "Resource";
            this.Resource.Size = new System.Drawing.Size(75, 19);
            this.Resource.TabIndex = 3;
            this.Resource.Text = "Resource:";
            // 
            // ExportPNG
            // 
            this.ExportPNG.Location = new System.Drawing.Point(507, 6);
            this.ExportPNG.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportPNG.Name = "ExportPNG";
            this.ExportPNG.Size = new System.Drawing.Size(121, 29);
            this.ExportPNG.TabIndex = 4;
            this.ExportPNG.Text = "Export to PNG";
            this.ExportPNG.UseVisualStyleBackColor = true;
            this.ExportPNG.Click += new System.EventHandler(this.ExportPNG_Click);
            // 
            // ExportPDF
            // 
            this.ExportPDF.Location = new System.Drawing.Point(646, 6);
            this.ExportPDF.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ExportPDF.Name = "ExportPDF";
            this.ExportPDF.Size = new System.Drawing.Size(121, 29);
            this.ExportPDF.TabIndex = 5;
            this.ExportPDF.Text = "Export to PDF";
            this.ExportPDF.UseVisualStyleBackColor = true;
            this.ExportPDF.Click += new System.EventHandler(this.ExportPDF_Click);
            // 
            // ChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(791, 742);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.ExportPDF);
            this.Controls.Add(this.ExportPNG);
            this.Controls.Add(this.Resource);
            this.Controls.Add(this.SelectedResourceType);
            this.Font = new System.Drawing.Font("Open Sans", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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