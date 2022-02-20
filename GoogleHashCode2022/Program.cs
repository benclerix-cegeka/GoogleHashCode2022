using System;
using System.IO;

namespace GoogleHashCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Input");
            var files = Directory.GetFiles(inputPath);

            foreach (var file in files)
            {
                Console.WriteLine($"Calculating solution for file {file}");
                var inputData = new InputData(file);
                var outputData = CalculateSolution(inputData);
                outputData.WriteToOutputFile(Path.GetFileName(file));
            }

            Console.WriteLine("Done...");
            Console.ReadKey();
        }

        private static OutputData CalculateSolution(InputData input)
        {
            var output = new OutputData();

            throw new NotImplementedException();

            return output;
        }
    }
}
