﻿using System;
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
            // short reference for our dummy:
            Series S0 = chart1.Series[0];
            // a simple type
            S0.ChartType = SeriesChartType.Line;
            // set 10 point with x-values going from 0-100 and y-values going from 1-10:
            for (int i = 0; i < 100; i += 10) S0.Points.AddXY(i, i / 10);
            // or add only a few, e.g. the first and last points:
            //S0.Points.AddXY(100, 10);
            //S0.Points.AddXY(0, 10);
            // hide the line:
            S0.Color = Color.Transparent;
            // hide the legend text (it will still take up a little space, though)
            S0.LegendText = " ";
            // limit the axis to the target values
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = 0;


        }
    }
}
