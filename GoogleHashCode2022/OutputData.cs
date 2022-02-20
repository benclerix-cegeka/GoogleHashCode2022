using System.IO;

namespace GoogleHashCode2021
{
    public class OutputData
    {
        //public List<SomeType> SomeProperty { get; set; }

        public void WriteToOutputFile(string fileName)
        {
            var outputPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Output", fileName);

            using (var streamWriter = new StreamWriter(outputPath))
            {
                //streamWriter.WriteLine(SomeProperty.Count);


            }
        }
    }
}
