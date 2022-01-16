using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SalaryConsultation.Entities;



namespace SalaryConsultation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            List <Employee> employees = new List<Employee>();   

            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] lines = sr.ReadLine().Split(",");

                    string name = lines[0];
                    string email = lines[1];    
                    double salary = double.Parse(lines[2], CultureInfo.InvariantCulture);

                    employees.Add(new Employee(name, email, salary));
                }

            }

            Console.Write("Enter salary: ");
            double salaryComp = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Email of people whose salary is more than " + salaryComp.ToString("F2", CultureInfo.InvariantCulture) + ":");

            var emailPrint = employees.Where(p => p.Salary > salaryComp).OrderBy(p => p.Email).Select(p => p.Email);

            foreach (string mail in emailPrint)
            {
                Console.WriteLine(mail);
            }

            var sum = employees.Where(p => p.Name.ToUpper()[0] == 'M').Sum(p => p.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}
