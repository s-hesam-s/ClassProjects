using System;
using System.Collections.Generic;

namespace Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee {Name = "Hesam",Age = 30, Gender = "male", Position = "Manager", Salary = 18},
                new Employee {Name = "Amir",Age = 33, Gender = "male", Position = "It", Salary = 10},
                new Employee {Name = "Mohammad",Age = 45, Gender = "male", Position = "GrandParent", Salary = 18},
                new Employee {Name = "Kobra",Age = 48, Gender = "female", Position = "Janitor", Salary = 2}
            };
            HumanResource humanResource = new HumanResource();

            List<Employee> over40 = humanResource.Over40(employees);
            Console.WriteLine("\nEmployees Over 40 :");
            humanResource.Print(over40);

            List<Employee> salary10to13 = humanResource.Salary10to13(employees);
            Console.WriteLine("\nSalary between 10 to 13 :");
            humanResource.Print(salary10to13);

            List<Employee> positionForMinSalary = humanResource.PositionForMinSalary(employees);
            Console.WriteLine("\nPosition(s) for minimum salary");
            humanResource.Print(positionForMinSalary);

            List<Employee> PositionForMaxSalary = humanResource.PositionForMaxSalary(employees);
            Console.WriteLine("\nPosition(s) for maximum salary");
            humanResource.Print(PositionForMaxSalary);

            Console.WriteLine("\nIs there any woman getting less than 3 Million? " + 
                               humanResource.HasFemaleSalaryLess3(employees));
            Console.WriteLine("Total salary: " + humanResource.TotalSalary(employees));
            Console.WriteLine("Average salary for men: " + humanResource.AverageSalaryMen(employees));
            Console.WriteLine("Average salary for wemen: " + humanResource.AverageAgeMen(employees));
        }
    }
}
