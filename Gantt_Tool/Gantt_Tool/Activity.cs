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
        public int finishTime { get; set; }
        public int[] renewableResourceConsumption{ get; set; }
        public int[] nonrenewableResourceConsumption{ get; set; }

        public Activity(int initID, int initStart, int initJobDur, int[] initRenewCons, int[] initNonRenewCons)
        {
            ID = initID;
            startingTime = initStart;
            jobDuration = initJobDur;
            finishTime = startingTime + jobDuration;

            renewableResourceConsumption = new int[initRenewCons.Length];
            nonrenewableResourceConsumption = new int[initNonRenewCons.Length];

            for (int i = 0; i < initRenewCons.Length; i++)
            {
                renewableResourceConsumption[i] = initRenewCons[i];
            }

            for (int i = 0; i < initNonRenewCons.Length; i++)
            {
                nonrenewableResourceConsumption[i] = initNonRenewCons[i];
            }

        }
    }
}
