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
                        string srLine = null;

                        while (!sr.EndOfStream)
                        {
                            srLine = sr.ReadLine();
                            string description = null;
                            double price = 0;
                            int quant = 0;
                            for (int index = 0, end_index = 0, count_comma = 0; index < srLine.Length; count_comma++)
                            {

                                end_index = srLine.IndexOf(',', index);

                                if (end_index == -1)
                                {
                                    end_index = srLine.Length;
                                }
                                switch (count_comma)
                                {
                                    case 0:
                                        //Description
                                        description = srLine.Substring(index, (end_index - index));
                                        break;
                                    case 1:
                                        //Price
                                        price = double.Parse(srLine.Substring(index, (end_index - index)), CultureInfo.InvariantCulture);
                                        break;
                                    case 2:
                                        //Price
                                        quant = int.Parse(srLine.Substring(index, (end_index - index)));
                                        break;
                                    default:
                                        break;
                                }
                                index = end_index+1;
                            }
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
