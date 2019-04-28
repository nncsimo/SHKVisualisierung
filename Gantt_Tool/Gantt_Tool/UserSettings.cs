using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SelectedSchedule = new ScheduleData(filename);
            DisplayedResource = 1;

            this.ResourceConsumptionAtTime_Setting = ResourceConsumptionAtTime_Setting;
            this.Makespan_Setting = Makespan_Setting;
        }

        public void ChangeSettings()
        {

        }
    }
}
