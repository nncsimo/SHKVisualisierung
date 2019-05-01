using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Gantt_Tool
{
    public class UserSettings
    {
        public ScheduleData SelectedSchedule { get; set; }

        public int DisplayedResource { get; set; }
        public bool ResourceConsumptionAtTime_Setting { get; set; }
        public bool Makespan_Setting { get; set; }

        public UserSettings(string filename, bool ResourceConsumptionAtTime_Setting, bool Makespan_Setting)
        {
            try
            {
                SelectedSchedule = new ScheduleData(filename);
            }
            catch (FileNotFoundException e)
            {
                MessageBox.Show($"The selected file was not found or no file was selected. Please select a file.");
            }

            DisplayedResource = 1;

            this.ResourceConsumptionAtTime_Setting = ResourceConsumptionAtTime_Setting;
            this.Makespan_Setting = Makespan_Setting;
        }

        public void ChangeSettings()
        {

        }
    }
}
