using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Gantt_Tool
{
    using OxyPlot;
    using OxyPlot.Series;

    public partial class Form1 : Form
    {
        public Form1()
        {
            this.InitializeComponent();
            var myModel = new PlotModel { Title = "Example 1" };
            myModel.Series.Add(new FunctionSeries(Math.Cos, 0, 10, 0.1, "cos(x)"));
            this.plot1.Model = myModel;
        }

    }
}
