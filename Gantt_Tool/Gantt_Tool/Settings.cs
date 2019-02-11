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
        private ReadModel ChildForm;

        public Settings()
        {
            InitializeComponent();
        }

        public void Settings_Load(object sender, EventArgs e)
        {
            
        }

        public void OpenFile_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            this.InitializeComponent();

            openFileDialog1.ShowDialog();
            string filedirectory = openFileDialog1.FileName;
            CurrentSettings = new UserSettings(filedirectory);

            // Wenn SData erstellt, dann Anzeige der Einstellmöglichkeiten

            for (int i = 0; i < CurrentSettings.SelectedSchedule.NumberOfRenewableResources; i++)
            {
                SelectResourceType.Items.Add(i);
            }
            SelectResourceType.SelectedIndex = CurrentSettings.DisplayedResource;
        }

        public void RefreshSchedule_Click(object sender, EventArgs e)
        {

            CurrentSettings.DisplayedResource = Convert.ToInt32(SelectResourceType.SelectedIndex); //TODO: richtet sich derzeit noch nach .SelectedIndex, müsste aber den tatsächlichen Value berücksichtigen
            ChildForm = new ReadModel(this, CurrentSettings);
            new Thread(() => ChildForm.ShowDialog()).Start();
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
    }
}
