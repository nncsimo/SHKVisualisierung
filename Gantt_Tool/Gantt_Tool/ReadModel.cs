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
            for (int i = 0; i < initData.NumberOfActivities; i++)
            {
                chart1.Series.Add($"a{i}");
                chart1.Series[$"a{i}"].Points.Add(new DataPoint(initData.ListOfActivities[i].startingTime, initData.ListOfActivities[i].renewableResourceConsumption[1]));
                chart1.Series[$"a{i}"].Points.Add(new DataPoint(initData.ListOfActivities[i].finishTime, initData.ListOfActivities[i].renewableResourceConsumption[1]));
                chart1.Series[$"a{i}"].ChartType = SeriesChartType.StackedArea;
            }
        }
    }
}
