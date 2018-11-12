using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gantt_Tool
{
    class ScheduleData
    {
        public int NumberOfActivities { get; set; }
        public int NumberOfRenewableResources { get; set; }
        public int NumberOfNonRenewableResources { get; set; }
        public List<Activity> ListOfActivities{ get; set;}
        public int Makespan { get; set; }

        /* ResourceConsumptionAtTime Array dient zur Speicherung der Ressourcenverbräuche 
        der erneuerbaren Ressourcen zu jedem Zeitpunkt t bis zum Ende des Makespan*/
        public int[,] ResourceConsumptionAtTime { get; set; }
    }
}
