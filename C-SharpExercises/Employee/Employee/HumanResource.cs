using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee
{
    class HumanResource : IHumanResource
    {
        public double AverageAgeMen(List<Employee> employees)
        {
            return employees.Where(g => g.Gender == "male").Average(a => a.Age);
        }
        public double AverageSalaryMen(List<Employee> employees)
        {
            return employees.Where(g => g.Gender == "male").Average(a => a.Salary);
        }
        public double TotalSalary(List<Employee> employees)
        {
            return employees.Sum(s => s.Salary);
        }
        public bool HasFemaleSalaryLess3(List<Employee> employees)
        {
            return employees.Exists(g => g.Gender == "female" && g.Salary < 3);
        }
        public List<Employee> Over40(List<Employee> employees)
        {
            return employees.Where(a => a.Age > 40).OrderByDescending(o => o.Age).ToList();
        }
        public List<Employee> PositionForMinSalary(List<Employee> employees)
        {
            var min = employees.Min(s => s.Salary);
            return employees.Where(e => e.Salary == min).ToList();
        }
        public List<Employee> PositionForMaxSalary(List<Employee> employees)
        {
            var max = employees.Max(s => s.Salary);
            return employees.Where(e => e.Salary == max).ToList();
        }
        public List<Employee> Salary10to13(List<Employee> employees)
        {
            return employees.Where(s => s.Salary >= 10 && s.Salary <= 13).OrderBy(o => o.Salary).ToList();
        }
        public void Print(List<Employee> employees)
        {
            employees.ForEach(p => Console.Write($"\nName: {p.Name}\nAge: {p.Age}\nGender: {p.Gender}\n" +
                $"Salary: {p.Salary}\nPosition: {p.Position}\n"));
        }
    }
}
