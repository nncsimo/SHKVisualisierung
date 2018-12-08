using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Gantt_Tool
{
    public partial class ReadModel : Form
    {
        public ReadModel()
        {
            InitializeComponent();
        }

        private void ReadModel_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            //string filedirectory = openFileDialog1.FileName;
            ScheduleData SData = new ScheduleData(openFileDialog1.FileName);

            CreateChart(SData);
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void CreateChart(ScheduleData initData)
        {
            //    this.chart1.Series.Clear();
            int j = 1;
            chart1.Titles.Add("Activities");

            for (int i = 0; i < initData.Makespan; i++)
            {
                chart1.Series["Data1"].Points.AddXY(i, initData.ResourceConsumptionAtTime[j,i]);
            }            
            
            //chart1.Series["Data1"].Points.AddXY("0", "2");
            //chart1.Series["Data1"].Points.AddXY("1", "2");
            //chart1.Series["Data1"].Points.AddXY("2", "0");

            //// Data arrays
            //string[] seriesArray = { "Cat" };
            //int[] pointsArray = { 2 };

            //// Set palette
            //this.chart1.Palette = ChartColorPalette.EarthTones;

            //// Set title
            //this.chart1.Titles.Add("Activities");

            //// Add series.
            //for (int i = 0; i < seriesArray.Length; i++)
            //{
            //    Series series = this.chart1.Series.Add(seriesArray[i]);
            //    series.Points.Add(pointsArray[i]);
            //}
        }
    }
}
