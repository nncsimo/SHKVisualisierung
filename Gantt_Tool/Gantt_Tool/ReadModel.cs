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
        private Settings _ParentForm;

        public ReadModel(Settings parentForm, UserSettings SelectedSettings)
        {
            
            InitializeComponent();
            _ParentForm = parentForm;
            chart1.Series[0].Points.Clear();
            CalculateBoxes(SelectedSettings);

            CreateChart(SelectedSettings);

            DrawResourceConsumptionAtTime(SelectedSettings);
        }

        public void ReadModel_Load(object sender, EventArgs e)
        {

        }

        public void chart1_Click(object sender, EventArgs e)
        {
            
        }

        public void CalculateBoxes(UserSettings Set)
        {
            for (int i = 0; i < Set.SelectedSchedule.Makespan; i++)
            {
                if (Set.SelectedSchedule.CurrentActivities.Count != 0)
                {
                    Set.SelectedSchedule.CurrentActivities.RemoveAll(x => x.finishTime <= i);
                }

                for (int j = 0; j < Set.SelectedSchedule.NumberOfActivities; j++)
                {
                    if (Set.SelectedSchedule.ActiveActivitiesAtTime[i, j] == true && !Set.SelectedSchedule.CurrentActivities.Any(x => x.ID == j) )
                    {
                        Set.SelectedSchedule.CurrentActivities.Add(Set.SelectedSchedule.ListOfActivities[j]);
                    }
                }

                if (Set.SelectedSchedule.CurrentActivities.Count > 0)
                {
                    if (!Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted).Any())
                    {
                        Set.SelectedSchedule.CurrentActivities = Set.SelectedSchedule.CurrentActivities.OrderByDescending(x => x.jobDuration).ToList();

                        for (int k = 0; k < Set.SelectedSchedule.CurrentActivities.Count; k++)
                        {
                            int y = 0;

                            foreach (Activity act in Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted))
                            {
                                y += act.renewableResourceConsumption[Set.DisplayedResource - 1];
                            }

                            Set.SelectedSchedule.CurrentActivities[k].yValue = y;
                            Set.SelectedSchedule.AlreadyPainted.Add(Set.SelectedSchedule.CurrentActivities[k]);
                        }
                    }
                    else if (Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted).Any())
                    {
                        List<Activity> ToPaint = new List<Activity>();
                        int count = Set.SelectedSchedule.CurrentActivities.Except(Set.SelectedSchedule.AlreadyPainted).Count();

                        ToPaint = Set.SelectedSchedule.CurrentActivities.Except(Set.SelectedSchedule.AlreadyPainted).ToList();
                        ToPaint = ToPaint.OrderByDescending(x => x.jobDuration).ToList();

                        if (count > 0)
                        {
                            for (int w = 0; w < count; w++)
                            {                           
                                    List<Activity> CurrentAndPainted = Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted).ToList();
                                    CurrentAndPainted = CurrentAndPainted.OrderBy(x => x.yValue).ToList();

                                    for (int s = 0; s < CurrentAndPainted.Count + 1; s++)
                                    {
                                        if (s == 0)
                                        {
                                            if (ToPaint[w].renewableResourceConsumption[Set.DisplayedResource - 1] <= CurrentAndPainted[s].yValue)
                                            {
                                                ToPaint[w].yValue = 0;
                                                Set.SelectedSchedule.AlreadyPainted.Add(ToPaint[w]);
                                                break;
                                            }
                                        }
                                        else if (s == CurrentAndPainted.Count)
                                        {
                                            ToPaint[w].yValue = CurrentAndPainted[CurrentAndPainted.Count - 1].yValue + CurrentAndPainted[CurrentAndPainted.Count - 1].renewableResourceConsumption[Set.DisplayedResource - 1];
                                            Set.SelectedSchedule.AlreadyPainted.Add(ToPaint[w]);
                                            break;
                                        }
                                        else
                                        {
                                            if (ToPaint[w].renewableResourceConsumption[Set.DisplayedResource - 1] <= (CurrentAndPainted[s].yValue - (CurrentAndPainted[s - 1].yValue + CurrentAndPainted[s - 1].renewableResourceConsumption[Set.DisplayedResource])))
                                            {
                                                ToPaint[w].yValue = CurrentAndPainted[s - 1].yValue + CurrentAndPainted[s - 1].renewableResourceConsumption[Set.DisplayedResource - 1];
                                                Set.SelectedSchedule.AlreadyPainted.Add(ToPaint[w]);
                                                break;
                                            }
                                        }
                                    }
                            }
                            
                        }

                    }
                }
            }
        }

        public void CreateChart(UserSettings SelectedSettings)
        {
            // Set axis options

            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            ax.Maximum = SelectedSettings.SelectedSchedule.Makespan + 1;
            ay.Maximum = SelectedSettings.SelectedSchedule.ListOfActivities.Max(x => x.yValue) + 4;
            ax.Interval = 1;
            ay.Interval = 1;
            ax.MajorGrid.Enabled = false;
            ay.MajorGrid.Enabled = false;
            ax.ArrowStyle = AxisArrowStyle.Lines;
            ay.ArrowStyle = AxisArrowStyle.Lines;
            ax.Title = "t = time";
            ay.Title = "Consumption of renewable resource " + SelectedSettings.DisplayedResource;

            // Add boxes for the activities to the chart area

            Series series1 = chart1.Series[0];
            series1.ChartType = SeriesChartType.Point;

            foreach (Activity activity in SelectedSettings.SelectedSchedule.ListOfActivities)
            {
                AddBox(series1, activity.startingTime, activity.yValue, activity.jobDuration, activity.renewableResourceConsumption[SelectedSettings.DisplayedResource - 1], Convert.ToString(activity.UserID));
            }

            this.chart1.PostPaint += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs>(this.PostPaint);
        }

        public int AddBox(Series s, float x, float y, float w, float h, string label)
        {
            return AddBox(s, new PointF(x, y), new SizeF(w, h), label);
        }

        public int AddBox(Series s, PointF pt, SizeF sz, string label)
        {
            int i = s.Points.AddXY(pt.X, pt.Y);
            s.Points[i].Tag = sz;
            s.Points[i].Label = label;
            s.Points[i].LabelForeColor = Color.Transparent;
            s.Points[i].Color = Color.Transparent;
            return i;
        }

        public void PostPaint(object sender, System.Windows.Forms.DataVisualization.Charting.ChartPaintEventArgs e)
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

                        using (Pen pen = new Pen(Color.Black))
                            g.DrawRectangle(pen, rect);
                        g.DrawString(dp.Label, Font, Brushes.Black, rect, fmt);
                    }
                }
        }

        public void DrawResourceConsumptionAtTime(UserSettings SelectedSettings)
        {
            Series Points = chart1.Series.Add("points");
            Points.ChartType = SeriesChartType.Point;

            Series Lines = chart1.Series.Add("lines");
            Lines.ChartType = SeriesChartType.Line;
            Lines.Color = Color.Black;
            Lines.BorderWidth = 2;

            List<PointF> points = new List<PointF>();
            List<Point> lines = new List<Point>();

            for (int i = 0; i < SelectedSettings.SelectedSchedule.Makespan; i++)
            {
                points.Add(new PointF(i, SelectedSettings.SelectedSchedule.ResourceConsumptionAtTime[SelectedSettings.DisplayedResource - 1, i]));
                points.Add(new PointF(i + 1, SelectedSettings.SelectedSchedule.ResourceConsumptionAtTime[SelectedSettings.DisplayedResource - 1, i]));
            }

            for (int i = 0; i < SelectedSettings.SelectedSchedule.Makespan * 2; i++)
            {
                lines.Add(new Point(i, i + 1));
                i++;
            }

            for (int i = 1; i < points.Count - 1; i++)
            {
                if (points[i].Y != points[i + 2].Y)
                {
                    Points.Points.AddXY(points[i].X, points[i].Y);
                }         
                i++;
            }

            foreach (var point in Points.Points)
            {
                point.Color = Color.Black;
                point.MarkerStyle = MarkerStyle.Circle;
            }

            //for (int i = 0; i < points.Count; i++)
            //{
            //    if (points[i].Y != points[i + 2].Y)
            //    {
            //        Points.Points.AddXY(points[i].X, points[i].Y);
            //    }
            //    i++;
            //}

            foreach (Point ln in lines)
            {
                int p0 = Lines.Points.AddXY(points[ln.X].X, points[ln.X].Y);
                int p1 = Lines.Points.AddXY(points[ln.Y].X, points[ln.Y].Y);
                Lines.Points[p0].Color = Color.Transparent;
                Lines.Points[p1].Color = Color.Black;
            }
        }

        public void ExportToPng()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(ExportToPng));
            }
            else
            {
                chart1.SaveImage("test.png", ChartImageFormat.Png);
            }                    
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}

