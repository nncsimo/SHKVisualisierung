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
        public ReadModel ChildForm;
        public List<ReadModel> FormsList { get; set; }

        public Settings()
        {
            InitializeComponent();
            SelectResourceType.Visible = false;
            DisplayResourceConsumptionAtTime.Visible = false;
            DisplayMakespan.Visible = false;
            RefreshSchedule.Visible = false;
            ExportToPNG.Visible = false;
            FormsList = new List<ReadModel>();
        }

        public void Settings_Load(object sender, EventArgs e)
        {

        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            try
            {
                string filedirectory = openFileDialog1.FileName;
                CurrentSettings = new UserSettings(filedirectory);

                InitializeComponent();
                SelectResourceType.Visible = false;
                DisplayResourceConsumptionAtTime.Visible = false;
                DisplayMakespan.Visible = false;
                ExportToPNG.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select a file from the file dialog window.");
                return;
            }       
     
            // Wenn SData erstellt, dann Anzeige der Einstellmöglichkeiten

            for (int i = 1; i < CurrentSettings.SelectedSchedule.NumberOfRenewableResources + 1; i++)
            {
                SelectResourceType.Items.Add(i);
            }
            SelectResourceType.SelectedIndex = CurrentSettings.DisplayedResource - 1;
        }

        public void RefreshSchedule_Click(object sender, EventArgs e)
        {
            CurrentSettings.DisplayedResource = Convert.ToInt32(SelectResourceType.SelectedItem.ToString());

            ChildForm = new ReadModel(this, CurrentSettings);
            FormsList.Add(ChildForm);

            //if (FormsList.Count > 1)
            //{
            //    CloseThread();
            //    FormsList.RemoveAt(0);
            //}
         
            new Thread(() => ChildForm.ShowDialog()).Start();

            SelectResourceType.Visible = true;
            DisplayResourceConsumptionAtTime.Visible = true;
            DisplayMakespan.Visible = true;
            ExportToPNG.Visible = true;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void SelectResourceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void ExportToPNG_Click(object sender, EventArgs e)
        {
            ChildForm.ExportToPng();
        }
<<<<<<< HEAD

        private void CloseThread()
        {
            this.BeginInvoke(new MethodInvoker(FormsList[0].Close));
        }

        private void DisplayResourceConsumptionAtTime_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayResourceConsumptionAtTime.Checked == true)
            {
                ChildForm.AddResourceConsumptionAtTime();
            }
            if (DisplayResourceConsumptionAtTime.Checked == false)
            {
                ChildForm.RemoveResourceConsumptionAtTime();
            }
        }

        private void DisplayMakespan_CheckedChanged(object sender, EventArgs e)
        {
            if (DisplayMakespan.Checked == true)
            {
                ChildForm.AddMakespan();
            }
            if (DisplayMakespan.Checked == false)
            {
                ChildForm.RemoveMakespan();
            }
        }
=======
>>>>>>> parent of 7b4be7a... PDF-Export Method
    }
}
