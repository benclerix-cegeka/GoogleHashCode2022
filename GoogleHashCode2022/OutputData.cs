using GoogleHashCode2022.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleHashCode2021
{
    public class OutputData
    {
        public List<Solution> Solutions { get; set; }

        public void WriteToOutputFile(string fileName)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Output");
            Directory.CreateDirectory(directory);
            var outputPath = Path.Combine(directory, fileName);

            using (var streamWriter = new StreamWriter(outputPath))
            {
                streamWriter.WriteLine(Solutions.Count);
                foreach (var solution in Solutions)
                {
                    streamWriter.WriteLine(solution.ProjectName);
                    streamWriter.WriteLine(string.Join(" ", solution.Contributers));
                }
            }
        }
    }
}