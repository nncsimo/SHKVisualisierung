﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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

        public ScheduleData(string filename) {
            using (StreamReader sr = new StreamReader(filename))
            {
                char[] charSeperator = new char[] { ';' };

                // Skip line
                sr.ReadLine();

                // Read job 
                int[] initData =  Array.ConvertAll(sr.ReadLine().Split(charSeperator, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                // Write data to properties
                NumberOfActivities = initData[0];
                NumberOfRenewableResources = initData[1];
                NumberOfNonRenewableResources = initData[2];

                // Skip header line
                sr.ReadLine();

                // Create ListofActivities
                ListOfActivities = new List<Activity>();

                // Read activity data
                for (int i = 0; i < NumberOfActivities; i++)
                {
                    initData = Array.ConvertAll(sr.ReadLine().Split(charSeperator, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                    int z = 0;
                    int id = initData[z]; z++;
                    int startTime = initData[z]; z++;
                    int jobDuration = initData[z]; z++;

                    int[] renewResDump = new int[NumberOfRenewableResources];
                    int[] nonrenewResDump = new int[NumberOfNonRenewableResources];

                    for (int j = 0; j < NumberOfRenewableResources; j++)
                    {
                        renewResDump[j] = initData[j + z];
                    }

                    for (int j = 0; j < NumberOfNonRenewableResources; j++)
                    {
                        nonrenewResDump[j] = initData[j + NumberOfRenewableResources + z];
                    }

                    Activity activity = new Activity(id, startTime, jobDuration, renewResDump, nonrenewResDump);

                    ListOfActivities.Add(activity);
                }

                // Calculate makespan
                for (int i = 0; i < NumberOfActivities; i++)
                {
                    Makespan += ListOfActivities[i].jobDuration;
                }

                // Calculate ResourceConsumptionAtTime
                ResourceConsumptionAtTime = new int[NumberOfRenewableResources, Makespan];

                for (int i = 0; i < NumberOfRenewableResources; i++) // Resources
                {
                    for (int j = 0; j < Makespan; j++) // Time
                    {
                        for (int k = 0; k < NumberOfActivities; k++)
                        {
                            if (ListOfActivities[k].startingTime <= j && j < ListOfActivities[k].finishTime)
                            {
                                ResourceConsumptionAtTime[i, j] += ListOfActivities[k].renewableResourceConsumption[i];
                            }
                        }
                    }
                }
                
            }
        }       
    }
}
