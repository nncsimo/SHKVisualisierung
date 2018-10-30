using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace Gantt_Tool
{
    class Activity
    {
        public int ID { get; set; }
        public int startingTime { get; set; }
        public int jobDuration { get; set; }
        public int renewableResourceConsumption_R1 { get; set; }
        public int renewableResourceConsumption_R2 { get; set; }
        public int nonrenewableResourceConsumption_N1 { get; set; }
    }
}
