using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Summary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Temp/File1.csv";
            List<string> outLInes = new List<string>();
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        while (!sr.EndOfStream)
                        {

                            string[] fields = sr.ReadLine().Split(",");
                            
                            string description = fields[0];
                            double price = double.Parse(fields[1], CultureInfo.InvariantCulture);
                            int quant = int.Parse(fields[2]);

                            outLInes.Add(description + "," + (price * quant).ToString("F2", CultureInfo.InvariantCulture));
                        }
                    }
                }

                path = Path.GetDirectoryName(path) + "/out";

                Directory.CreateDirectory(path);

                path += "/summary.csv";

                using (FileStream fsOut = new FileStream(path, FileMode.Create))
                {
                    using (StreamWriter sw = new StreamWriter(fsOut))
                    {
                        foreach (string s in outLInes)
                        {
                            sw.WriteLine(s);
                        }
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
