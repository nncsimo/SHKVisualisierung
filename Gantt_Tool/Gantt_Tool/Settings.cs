using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

namespace Gantt_Tool
{
    public partial class Settings : Form
    {
        UserSettings CurrentSettings { get; set; }
        public ChartForm ChildForm;
        public List<ChartForm> FormsList { get; set; }
        public string filename { get; set; }

        public Settings()
        {
            InitializeComponent();
            FormsList = new List<ChartForm>();
        }

        public void Settings_Load(object sender, EventArgs e)
        {

        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            
            string filedirectory = openFileDialog1.FileName;

            string[] dump = filedirectory.Split('\\');
            label_filename.Text = dump[dump.Length - 1];
            filename = dump[dump.Length - 1];

            bool ResourceConsumptionAtTime_Setting = DisplayResourceConsumptionAtTime.Checked;
            bool Makespan_Setting = DisplayMakespan.Checked;

            CurrentSettings = new UserSettings(filedirectory, ResourceConsumptionAtTime_Setting, Makespan_Setting);

            ChildForm = new ChartForm(this, CurrentSettings, filename);
            FormsList.Add(ChildForm);
            new Thread(() => ChildForm.ShowDialog()).Start();  
            
        }

        public void NewChartWindow_Click(object sender, EventArgs e)
        {
            CurrentSettings.ResourceConsumptionAtTime_Setting = DisplayResourceConsumptionAtTime.Checked;
            CurrentSettings.Makespan_Setting = DisplayMakespan.Checked;

            ChildForm = new ChartForm(this, CurrentSettings, filename);
            FormsList.Add(ChildForm);
         
            new Thread(() => ChildForm.ShowDialog()).Start();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }       

        private void CloseThread()
        {
            this.BeginInvoke(new MethodInvoker(FormsList[0].Close));
        }

        private void DisplayResourceConsumptionAtTime_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayResourceConsumptionAtTime.Checked == true)
            {
                CurrentSettings.ResourceConsumptionAtTime_Setting = true;

                foreach (ChartForm item in FormsList)
                {
                    item.AddResourceConsumptionAtTime();
                }               
            }
            if (DisplayResourceConsumptionAtTime.Checked == false)
            {
                CurrentSettings.ResourceConsumptionAtTime_Setting = false;

                foreach (ChartForm item in FormsList)
                {
                    item.RemoveResourceConsumptionAtTime();
                }
            }
        }

        private void DisplayMakespan_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayMakespan.Checked == true)
            {
                CurrentSettings.Makespan_Setting = true;

                foreach (ChartForm item in FormsList)
                {
                    item.AddMakespan();
                }
            }
            if (DisplayMakespan.Checked == false)
            {
                CurrentSettings.Makespan_Setting = false;

                foreach (ChartForm item in FormsList)
                {
                    item.RemoveMakespan();
                }
            }
        }

        private void label_filename_Click(object sender, EventArgs e)
        {

        }
       
    }
}
