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
        

        private int AddBox(Series s, float x, float y, float w, float h, string label)
        {
            return AddBox(s, new PointF(x, y), new SizeF(w, h), label);
        }

        private int AddBox(Series s, PointF pt, SizeF sz, string label)
        {
            int i = s.Points.AddXY(pt.X, pt.Y);
            s.Points[i].Tag = sz;
            s.Points[i].Label = label;
            s.Points[i].LabelForeColor = Color.Transparent;
            s.Points[i].Color = Color.Transparent;
            return i;
        }

        private void CreateChart(ScheduleData initData)
        {
            //for (int i = 0; i < initData.NumberOfActivities; i++)
            //{
            //    chart1.Series.Add($"a{i}");
            //    chart1.Series[$"a{i}"].Points.Add(new DataPoint(initData.ListOfActivities[i].startingTime, initData.ListOfActivities[i].renewableResourceConsumption[1]));
            //    chart1.Series[$"a{i}"].Points.Add(new DataPoint(initData.ListOfActivities[i].finishTime, initData.ListOfActivities[i].renewableResourceConsumption[1]));
            //    chart1.Series[$"a{i}"].ChartType = SeriesChartType.StackedArea;
            //}

            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            ax.Maximum = 9;  // pick or calculate
            ay.Maximum = 6;  // minimum and..
            ax.Interval = 1; // maximum values..
            ay.Interval = 1; // .. needed
            ax.MajorGrid.Enabled = false;
            ay.MajorGrid.Enabled = false;

            Series s1 = chart1.Series.Add("A");
            s1.ChartType = SeriesChartType.Point;

            AddBox(s1, 1, 0, 3, 1, "# 1");
            //AddBox(s, 2, 1, 2, 2, "# 2");
            //AddBox(s, 4, 0, 4, 2, "# 3");
            //AddBox(s, 4, 2, 2, 2, "# 4");
            //AddBox(s, 4, 4, 1, 1, "# 5");

            chart1_PostPaint(chart1);
            setMinMax(chart1, chart1.ChartAreas[0]);

        }
        private void chart1_PostPaint(ChartPaintEventArgs e)
        {
            if (chart1.Series[0].Points.Count <= 0) return;

            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            Graphics g = e.ChartGraphics.Graphics;
            using (StringFormat fmt = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            })
                foreach (Series s in chart1.Series)
                {
                    foreach (DataPoint dp in s.Points)
                    {
                        if (dp.Tag == null) break;
                        SizeF sz = (SizeF)dp.Tag;
                        double vx2 = dp.XValue + sz.Width;
                        double vy2 = dp.YValues[0] + sz.Height;
                        int x1 = (int)ax.ValueToPixelPosition(dp.XValue);
                        int y1 = (int)ay.ValueToPixelPosition(dp.YValues[0]);
                        int x2 = (int)ax.ValueToPixelPosition(vx2);
                        int y2 = (int)ay.ValueToPixelPosition(vy2);
                        Rectangle rect = Rectangle.FromLTRB(x1, y2, x2, y1);

                        using (Pen pen = new Pen(s.Color, 2f))
                            g.DrawRectangle(pen, rect);
                        g.DrawString(dp.Label, Font, Brushes.Black, rect, fmt);
                    }
                }
        }

        private void setMinMax(Chart chart, ChartArea ca)
        {
            var allPoints = chart.Series.SelectMany(x => x.Points);
            double minx = allPoints.Select(x => x.XValue).Min();
            double miny = allPoints.Select(x => x.YValues[0]).Min();
            double maxx = allPoints.Select(x => x.XValue + ((SizeF)x.Tag).Width).Max();
            double maxy = allPoints.Select(x => x.YValues[0] + ((SizeF)x.Tag).Height).Max();

            ca.AxisX.Minimum = minx;
            ca.AxisX.Maximum = maxx;
            ca.AxisY.Minimum = miny;
            ca.AxisY.Maximum = maxy;
        }
    }
}

