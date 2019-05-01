using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Gantt_Tool
{
    public class ScheduleData
    {
        public int NumberOfActivities { get; set; }
        public int NumberOfRenewableResources { get; set; }
        public int NumberOfNonRenewableResources { get; set; }
        public List<Activity> ListOfActivities{ get; set;}
        public int Makespan { get; set; }

        /* ResourceConsumptionAtTime Array dient zur Speicherung der Ressourcenverbräuche 
        der erneuerbaren Ressourcen zu jedem Zeitpunkt t bis zum Ende des Makespan*/
        public int[,] ResourceConsumptionAtTime { get; set; }

        public bool[,] ActiveActivitiesAtTime { get; set; }

        public int[] MaximumResourceConsumption { get; set; }

        public List<Activity> AlreadyPainted { get; set; }

        public List<Activity> CurrentActivities { get; set; }

        public ScheduleData(string filename) {
            
                using (StreamReader sr = new StreamReader(filename))
                {
                    char[] charSeperator = new char[] { ';' };

                    // Skip line
                    sr.ReadLine();

                    // Read job 
                    int[] initData = Array.ConvertAll(sr.ReadLine().Split(charSeperator, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                    // Write data to properties
                    NumberOfActivities = initData[0];
                    NumberOfRenewableResources = initData[1];
                    NumberOfNonRenewableResources = initData[2];

                    // Skip header line
                    sr.ReadLine();

                    // Create ListofActivities
                    ListOfActivities = new List<Activity>();

                    AlreadyPainted = new List<Activity>();

                    CurrentActivities = new List<Activity>();

                    // Read activity data
                    for (int i = 0; i < NumberOfActivities; i++)
                    {
                        initData = Array.ConvertAll(sr.ReadLine().Split(charSeperator, StringSplitOptions.RemoveEmptyEntries), int.Parse);

                        int z = 0;
                        int userid = initData[z]; z++;
                        int id = i;
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

                        Activity activity = new Activity(userid, id, startTime, jobDuration, renewResDump, nonrenewResDump);

                        ListOfActivities.Add(activity);
                    }

                    // Calculate makespan

                    Makespan = 0;

                    for (int i = 0; i < NumberOfActivities; i++)
                    {
                        if (ListOfActivities[i].finishTime > Makespan)
                        {
                            Makespan = ListOfActivities[i].finishTime;
                        }
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

                    MaximumResourceConsumption = new int[NumberOfRenewableResources];

                    for (int i = 0; i < NumberOfRenewableResources; i++)
                    {
                        for (int j = 0; j < Makespan; j++)
                        {
                            if (MaximumResourceConsumption[i] < ResourceConsumptionAtTime[i, j])
                            {
                                MaximumResourceConsumption[i] = ResourceConsumptionAtTime[i, j];
                            }
                        }
                    }

                    ActiveActivitiesAtTime = new bool[Makespan, NumberOfActivities];

                    for (int t = 0; t < Makespan; t++) // Time
                    {
                        for (int z = 0; z < NumberOfActivities; z++)
                        {
                            if (ListOfActivities[z].startingTime <= t && t < ListOfActivities[z].finishTime)
                            {
                                ActiveActivitiesAtTime[t, z] = true;
                            }
                        }
                    }
                }            
        }       
    }
}
