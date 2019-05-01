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
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;

namespace Gantt_Tool
{
    public partial class ChartForm : Form
    {
        private Settings _ParentForm;
        private UserSettings SelectedSettings;
        private string filename { get; set; }

        public ChartForm(Settings parentForm, UserSettings SelectedSettings, string filename)
        {            
            InitializeComponent();
            _ParentForm = parentForm;
            this.SelectedSettings = SelectedSettings;
            this.filename = filename;

            chart1.Series[0].Points.Clear();
            SelectedSettings.SelectedSchedule.CurrentActivities.Clear();
            SelectedSettings.SelectedSchedule.AlreadyPainted.Clear();
            CalculateBoxes(SelectedSettings);

            CalculateUpperBoxLine(SelectedSettings);

            CreateChart(SelectedSettings);

            DrawResourceConsumptionAtTime(SelectedSettings);
            DrawMakespan(SelectedSettings);

            UpdateChartLayers();

            for (int i = 1; i < SelectedSettings.SelectedSchedule.NumberOfRenewableResources + 1; i++)
            {
                SelectedResourceType.Items.Add(i);
            }

            SelectedResourceType.SelectedIndex = SelectedSettings.DisplayedResource - 1;
            this.Text = this.filename + " - Resource " + (SelectedSettings.DisplayedResource);
        }

        public void DrawSchedule(Settings parentForm, UserSettings SelectedSettings)
        {
            chart1.Series[0].Points.Clear();
            int count = chart1.Series.Count;
            for (int i = 1; i < count; i++)
            {
                chart1.Series.RemoveAt(1);
            }
            
            SelectedSettings.SelectedSchedule.CurrentActivities.Clear();
            SelectedSettings.SelectedSchedule.AlreadyPainted.Clear();
            CalculateBoxes(SelectedSettings);

            CalculateUpperBoxLine(SelectedSettings);

            CreateChart(SelectedSettings);

            DrawResourceConsumptionAtTime(SelectedSettings);
            DrawMakespan(SelectedSettings);

            UpdateChartLayers();

            this.Text = this.filename + " - Resource " + (SelectedSettings.DisplayedResource);
        }

        public void UpdateChartLayers()
        {            
            if (SelectedSettings.ResourceConsumptionAtTime_Setting)
            {
                AddResourceConsumptionAtTime();
            }
            else
            {
                RemoveResourceConsumptionAtTime();
            }

            if (SelectedSettings.Makespan_Setting)
            {
                AddMakespan();
            }
            else
            {
                RemoveMakespan();
            }
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
                    if (!Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted).Any(x => x.renewableResourceConsumption[Set.DisplayedResource - 1] != 0))
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
                    else if (Set.SelectedSchedule.CurrentActivities.Intersect(Set.SelectedSchedule.AlreadyPainted).Any(x => x.renewableResourceConsumption[Set.DisplayedResource - 1] != 0))
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
                                    CurrentAndPainted.RemoveAll(x => x.renewableResourceConsumption[Set.DisplayedResource - 1] == 0);
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
                                            if (ToPaint[w].renewableResourceConsumption[Set.DisplayedResource - 1] <= (CurrentAndPainted[s].yValue - (CurrentAndPainted[s - 1].yValue + CurrentAndPainted[s - 1].renewableResourceConsumption[Set.DisplayedResource - 1])))
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
        public void CalculateUpperBoxLine(UserSettings Set)
        {
            foreach (Activity activity in Set.SelectedSchedule.ListOfActivities)
            {
                activity.UpperBoxLine = activity.yValue + activity.renewableResourceConsumption[Set.DisplayedResource - 1];
            }
        }

        public void CreateChart(UserSettings SelectedSettings)
        {
            // Set axis options

            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            ax.Maximum = SelectedSettings.SelectedSchedule.Makespan + 1;
            ay.Maximum = SelectedSettings.SelectedSchedule.ListOfActivities.Max(x => x.UpperBoxLine);
            ax.Interval = 1;
            ay.Interval = 1;
            ax.MajorGrid.Enabled = false;
            ay.MajorGrid.Enabled = false;
            ax.ArrowStyle = AxisArrowStyle.Lines;
            ay.ArrowStyle = AxisArrowStyle.Lines;
            ax.Title = "t";
            ay.Title = "Consumption of renewable resource " + SelectedSettings.DisplayedResource;

            // Add boxes for the activities to the chart area

            Series series1 = chart1.Series[0];
            series1.ChartType = SeriesChartType.Point;

            foreach (Activity activity in SelectedSettings.SelectedSchedule.ListOfActivities)
            {
                if (activity.renewableResourceConsumption[SelectedSettings.DisplayedResource - 1] > 0)
                {
                    AddBox(series1, activity.startingTime, activity.yValue, activity.jobDuration, activity.renewableResourceConsumption[SelectedSettings.DisplayedResource - 1], Convert.ToString(activity.UserID));
                }            
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
                Alignment = StringAlignment.Far,
                LineAlignment = StringAlignment.Far
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
            Series Lines = chart1.Series.Add("lines");
            Lines.ChartType = SeriesChartType.Line;
            Lines.Color = Color.Black;
            Lines.BorderWidth = 2;

            Series Circles = chart1.Series.Add("circles");
            Circles.ChartType = SeriesChartType.Point;
            Circles.BackSecondaryColor = Color.White;

            List<PointF> CircleCoordinates = new List<PointF>();
            List<Point> LineCoordinates = new List<Point>();

            for (int i = 0; i < SelectedSettings.SelectedSchedule.Makespan; i++)
            {
                CircleCoordinates.Add(new PointF(i, SelectedSettings.SelectedSchedule.ResourceConsumptionAtTime[SelectedSettings.DisplayedResource - 1, i]));
                CircleCoordinates.Add(new PointF(i + 1, SelectedSettings.SelectedSchedule.ResourceConsumptionAtTime[SelectedSettings.DisplayedResource - 1, i]));
            }

            for (int i = 0; i < SelectedSettings.SelectedSchedule.Makespan * 2; i++)
            {
                LineCoordinates.Add(new Point(i, i + 1));
                i++;
            }

            for (int i = 1; i < CircleCoordinates.Count; i++)
            {
                if (i == CircleCoordinates.Count - 1)
                {
                    Circles.Points.AddXY(CircleCoordinates[i].X, CircleCoordinates[i].Y);
                }
                else if (CircleCoordinates[i].Y != CircleCoordinates[i + 2].Y)
                {
                    Circles.Points.AddXY(CircleCoordinates[i].X, CircleCoordinates[i].Y);
                }

                i++;
            }

            for (int i = 0; i < Circles.Points.Count; i++)
            {
                Circles.Points[i].MarkerStyle = MarkerStyle.Circle;
                Circles.Points[i].MarkerSize = 8;
                Circles.Points[i].MarkerBorderColor = Color.Black;
                Circles.Points[i].Color = Color.FromArgb(255, Color.White);
            }

            //foreach (var circle in Circles.Points)
            //{
            //    circle.MarkerStyle = MarkerStyle.Circle;
            //    circle.MarkerSize = 8;
            //    circle.MarkerBorderColor = Color.Black;
            //    circle.MarkerColor = Color.FromArgb(255, Color.White);
            //}           

            int count = Circles.Points.Count;

            for (int j = 0; j < CircleCoordinates.Count - 1; j++)
            {
                if (j == 0)
                {
                    Circles.Points.AddXY(CircleCoordinates[j].X, CircleCoordinates[j].Y);
                }
                else if(CircleCoordinates[j].Y != CircleCoordinates[j - 2].Y)
                {
                    Circles.Points.AddXY(CircleCoordinates[j].X, CircleCoordinates[j].Y);
                }               
               j++;
            }

            for (int i = count; i < Circles.Points.Count; i++)
            {
                Circles.Points[i].MarkerStyle = MarkerStyle.Circle;
                Circles.Points[i].MarkerSize = 8;
                Circles.Points[i].Color = Color.Black;
            }

            foreach (Point Line in LineCoordinates)
            {
                int p0 = Lines.Points.AddXY(CircleCoordinates[Line.X].X, CircleCoordinates[Line.X].Y);
                int p1 = Lines.Points.AddXY(CircleCoordinates[Line.Y].X, CircleCoordinates[Line.Y].Y);
                Lines.Points[p0].Color = Color.Transparent;
                Lines.Points[p1].Color = Color.Black;
            }

            chart1.Series["circles"].Enabled = false;
            chart1.Series["lines"].Enabled = false;
        }

        public void AddResourceConsumptionAtTime()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(AddResourceConsumptionAtTime));
            }
            else
            {               
                chart1.Series["lines"].Enabled = true;
                chart1.Series["circles"].Enabled = true;
            }    
        }

        public void RemoveResourceConsumptionAtTime()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(RemoveResourceConsumptionAtTime));
            }
            else
            {
                chart1.Series["circles"].Enabled = false;
                chart1.Series["lines"].Enabled = false;
            }
        }

        public void DrawMakespan(UserSettings SelectedSettings)
        {
            Series MakespanLine = chart1.Series.Add("makespan");
            MakespanLine.ChartType = SeriesChartType.Line;
            MakespanLine.Color = Color.Blue;
            MakespanLine.BorderWidth = 2;
            MakespanLine.BorderDashStyle = ChartDashStyle.Dash;

            int p0 = MakespanLine.Points.AddXY(SelectedSettings.SelectedSchedule.Makespan, 0);
            int p1 = MakespanLine.Points.AddXY(SelectedSettings.SelectedSchedule.Makespan, chart1.ChartAreas[0].AxisX.Maximum);
            MakespanLine.Points[p0].Color = Color.Transparent;
            MakespanLine.Points[p1].Color = Color.Blue;

            chart1.Series["makespan"].Enabled = false;
        }

        public void AddMakespan()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(AddMakespan));
            }
            else
            {
                chart1.Series["makespan"].Enabled = true;
            }
        }

        public void RemoveMakespan()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(RemoveMakespan));
            }
            else
            {
                chart1.Series["makespan"].Enabled = false;
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

        public void ExportToPDF()
        {
                if (InvokeRequired)
                {
                    BeginInvoke(new MethodInvoker(ExportToPng));
                }
                else
                {
                    chart1.SaveImage("test.png", ChartImageFormat.Png);
                }

                PdfDocument document = new PdfDocument();
                document.PageSettings.Margins.All = 0;
                MemoryStream ms = new MemoryStream();
                document.Save(ms);
                PdfImage image = new PdfBitmap("test.png");
                PdfPage page = document.Pages.Add();
                //Draw chart as image
                page.Graphics.DrawImage(image, new RectangleF(100, 100, 450, 300));
                //Save and close PDF document
                document.Save("test.pdf");
                document.Close(true);
        }

        private void SelectedResourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedSettings.DisplayedResource = Convert.ToInt32(SelectedResourceType.SelectedItem.ToString());

            DrawSchedule(_ParentForm, this.SelectedSettings);
        }

        private void ExportPNG_Click(object sender, EventArgs e)
        {
            ExportToPng();
        }

        private void ExportPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF();
        }
    }
}

