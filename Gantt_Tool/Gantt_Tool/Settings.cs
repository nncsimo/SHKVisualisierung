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
        List<UserSettings> CurrentSettings { get; set; }
        public ChartForm ChildForm;
        public List<ChartForm> FormsList { get; set; }
        public string filename { get; set; }

        public Settings()
        {
            InitializeComponent();
            FormsList = new List<ChartForm>();
            CurrentSettings = new List<UserSettings>();
        }

        public void Settings_Load(object sender, EventArgs e)
        {

        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.ShowDialog();
            
            string filedirectory = openFileDialog.FileName;

            string[] dump = filedirectory.Split('\\');
            label_filename.Text = dump[dump.Length - 1];
            filename = dump[dump.Length - 1];

            string[] filenamePieces = filename.Split('.');

            if(filenamePieces[filenamePieces.Length - 1] == "csv" | filenamePieces[filenamePieces.Length - 1] == openFileDialog.FileName)
            {
                bool ResourceConsumptionAtTime_Setting = DisplayResourceConsumptionAtTime.Checked;
                bool Makespan_Setting = DisplayMakespan.Checked;

                try
                {
                    CurrentSettings.Add(new UserSettings(filedirectory, ResourceConsumptionAtTime_Setting, Makespan_Setting));
                    ChildForm = new ChartForm(this, CurrentSettings[CurrentSettings.Count - 1], filename);
                    FormsList.Add(ChildForm);
                    new Thread(() => ChildForm.ShowDialog()).Start();
                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("The selected file is not a .csv file. Please select a .csv file.");
                Array.Clear(filenamePieces, 0, filenamePieces.Length - 1);
            }
        }

        public void NewChartWindow_Click(object sender, EventArgs e)
        {
            CurrentSettings[CurrentSettings.Count - 1].ResourceConsumptionAtTime_Setting = DisplayResourceConsumptionAtTime.Checked;
            CurrentSettings[CurrentSettings.Count - 1].Makespan_Setting = DisplayMakespan.Checked;

            ChildForm = new ChartForm(this, CurrentSettings[CurrentSettings.Count - 1], filename);
            FormsList.Add(ChildForm);
         
            new Thread(() => ChildForm.ShowDialog()).Start();
            
        }

        private void CloseThread()
        {
            this.BeginInvoke(new MethodInvoker(FormsList[0].Close));
        }

        private void DisplayResourceConsumptionAtTime_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayResourceConsumptionAtTime.Checked == true)
            {
                foreach (UserSettings Setting in CurrentSettings)
                {
                    Setting.ResourceConsumptionAtTime_Setting = true;
                }
               
                foreach (ChartForm item in FormsList)
                {
                    item.AddResourceConsumptionAtTime();
                }               
            }
            if (DisplayResourceConsumptionAtTime.Checked == false)
            {
                foreach (UserSettings Setting in CurrentSettings)
                {
                    Setting.ResourceConsumptionAtTime_Setting = false;
                }
                
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
                foreach (UserSettings Setting in CurrentSettings)
                {
                    Setting.Makespan_Setting = true;
                }

                foreach (ChartForm item in FormsList)
                {
                    item.AddMakespan();
                }
            }
            if (DisplayMakespan.Checked == false)
            {
                foreach (UserSettings Setting in CurrentSettings)
                {
                    Setting.Makespan_Setting = false;
                }

                foreach (ChartForm item in FormsList)
                {
                    item.RemoveMakespan();
                }
            }
        }

        private void label_filename_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
