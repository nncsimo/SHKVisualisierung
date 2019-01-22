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
        //private Rectangle r1;
        //private Rectangle r2;
        public ReadModel()
        {                      
            
            InitializeComponent();
           
        }

        public void ReadModel_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string filedirectory = openFileDialog1.FileName;
            ScheduleData SData = new ScheduleData(openFileDialog1.FileName);

            CreateChart(SData);
        }

        public void chart1_Click(object sender, EventArgs e)
        {
            
        }               

        public void CreateChart(ScheduleData S)
        {
            Axis ax = chart1.ChartAreas[0].AxisX;
            Axis ay = chart1.ChartAreas[0].AxisY;
            ax.Maximum = S.Makespan;  // pick or calculate
            ay.Maximum = S.MaximumResourceConsumption[0];  //TODO: Noch Hardcoded, muss aber in Zukunft abhängig von der Auswahl der zu visualisierenden Ressource durch den Nutzer gewählt werden
            ax.Interval = 1; // maximum values..
            ay.Interval = 1; // .. needed
            ax.MajorGrid.Enabled = false;
            ay.MajorGrid.Enabled = false;
            //popokacki
            Series series1 = chart1.Series[0];
            series1.ChartType = SeriesChartType.Point;

            for (int i = 0; i < S.Makespan; i++)
            {
                if (S.AlreadyPainted.Count != 0)
                {
                    S.AlreadyPainted.RemoveAll(x => x.finishTime <= i);
                }

                for (int j = 0; j < S.NumberOfActivities; j++)
                {
                    if (S.ActiveActivitiesAtTime[i, j] == true && !S.AlreadyPainted.Any(x => x.ID == j+1))
                    {
                        S.CurrentActivities.Add(S.ListOfActivities[j]);
                    }                    
                }

                if (S.CurrentActivities.Count != 0)
                {
                    S.CurrentActivities.OrderByDescending(x => x.jobDuration);
                }

                

                while (S.CurrentActivities.Count != 0)
                {
                    int y = 0;
                    if (S.AlreadyPainted.Count == 0)
                    {
                        AddBox(series1, S.CurrentActivities[0].startingTime, 0, S.CurrentActivities[0].jobDuration, S.CurrentActivities[0].renewableResourceConsumption[0], Convert.ToString(S.CurrentActivities[0].ID)); //TODO: renewableResourceConsumption[0] hardcoded, in Zukunft Auswahl der Ressource im Programm
                        S.AlreadyPainted.Add(S.CurrentActivities[0]);
                        S.CurrentActivities.RemoveAt(0);                       
                    }
                    else
                    {
                        
                        for (int k  = 0; k < S.AlreadyPainted.Count; k++)
                        {
                            y += S.AlreadyPainted[k].renewableResourceConsumption[0]; //TODO:in Zukunft variabel abhängig vom Ressourcentyp 
                        }
                        
                        AddBox(series1, S.CurrentActivities[0].startingTime, y, S.CurrentActivities[0].jobDuration, S.CurrentActivities[0].renewableResourceConsumption[0], Convert.ToString(S.CurrentActivities[0].ID));
                        S.AlreadyPainted.Add(S.CurrentActivities[0]);
                        S.CurrentActivities.RemoveAt(0);
                    }
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

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }        
    }
}

