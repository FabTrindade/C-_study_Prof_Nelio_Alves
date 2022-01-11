using System;
using System.Collections.Generic;

namespace NumberOfStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> CourseA = new HashSet<int>();
            HashSet<int> CourseB = new HashSet<int>();
            HashSet<int> CourseC = new HashSet<int>();


            Console.Write("How many students for course A?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                CourseA.Add(int.Parse(Console.ReadLine()));
            }


            Console.Write("How many students for course B?");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                CourseB.Add(int.Parse(Console.ReadLine()));
            }


            Console.Write("How many students for course C?");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                CourseC.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> Total = new HashSet<int>(CourseA);

            Total.UnionWith(CourseB);
            Total.UnionWith(CourseC);

            Console.Write("Total of sutudents: " + Total.Count);
            Console.ReadLine();
        }
    }
}
