using System.Collections.Generic;

namespace Employee
{
    interface IHumanResource
    {
        public List<Employee> Over40(List<Employee> employees);
        public List<Employee> Salary10to13(List<Employee> employees);
        public List<Employee> PositionForMinSalary(List<Employee> employees);
        public List<Employee> PositionForMaxSalary(List<Employee> employees);
        public bool HasFemaleSalaryLess3(List<Employee> employees);
        public double TotalSalary(List<Employee> employees);
        public double AverageSalaryMen(List<Employee> employees);
        public double AverageAgeMen(List<Employee> employees);
        public void Print(List<Employee> employees);
    }
}
