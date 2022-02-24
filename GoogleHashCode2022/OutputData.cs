using System.IO;

namespace GoogleHashCode2021
{
    public class OutputData
    {
        //public List<SomeType> SomeProperty { get; set; }

        public void WriteToOutputFile(string fileName)
        {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Output");
            Directory.CreateDirectory(directory);
            var outputPath = Path.Combine(directory, fileName);

            using (var streamWriter = new StreamWriter(outputPath))
            {
                //streamWriter.WriteLine(SomeProperty.Count);


            }
        }
    }
}