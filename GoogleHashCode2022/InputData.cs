using System.IO;

namespace GoogleHashCode2021
{
    public class InputData
    {
        //public int A_SomeProperty { get; set; }

        public InputData(string file)
        {
            ReadInputFile(file);
        }

        private void ReadInputFile(string file)
        {
            using (var reader = new StreamReader(file))
            {
                // First line
                var line = reader.ReadLine();
                var l = line.Split(' ');

                //A_SomeProperty = int.Parse(l[0]);
            }
        }
    }
}
