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

        public UserSettings(string filename)
        {
            SelectedSchedule = new ScheduleData(filename);
            DisplayedResource = 0;
        }

        public void ChangeSettings()
        {

        }
    }
}
