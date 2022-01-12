using System;
using System.Collections.Generic;
using System.IO;

namespace VoteCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            StreamReader sr = null;
            Dictionary<string, int> votes = new Dictionary<string, int>();
            try
            {
                using (sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] read = sr.ReadLine().Split(",");
                        string key = read[0];
                        int value = int.Parse(read[1]);

                        if (!votes.ContainsKey(key))
                        {
                            votes.Add(key, value);
                        }
                        else
                        {
                            votes[key] += value;
                        }
                    }
                    
                    foreach (var v in votes)
                    {
                        Console.WriteLine(v.Key + ": " + v.Value);
                    }
                }

            }
            catch (IOException)
            {
                Console.WriteLine("Error File");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press a key to end");
            Console.Read();
        }
    }
}
