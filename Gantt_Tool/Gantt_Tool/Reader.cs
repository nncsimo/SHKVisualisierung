using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using System.IO;

namespace Gantt_Tool
{
    public class Reader
    {
        public static void ReadFromCsv(string filename)
        {
            TextReader textReader = File.OpenText(filename);
            var csv = new CsvReader(textReader);
            csv.Configuration.Delimiter = ";";
            var activity = csv.GetRecords<Activity>().ToList();
        }
    }
}
