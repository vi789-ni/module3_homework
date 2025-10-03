using System;

namespace OCP
{
    public class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
    }

    public interface ISalaryCalculator
    {
        double CalculateSalary(Employee employee);
    }

    public class PermanentSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.2;
    }

    public class ContractSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee) => employee.BaseSalary * 1.1;
    }

    public class InternSalaryCalculator : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee) => employee.BaseSalary * 0.8;
    }

    class Program
    {
        static void Main()
        {
            var employee = new Employee();

            Console.Write("Введите имя сотрудника: ");
            employee.Name = Console.ReadLine();

            Console.Write("Введите базовую зарплату: ");
            employee.BaseSalary = double.Parse(Console.ReadLine());

            Console.WriteLine("Выберите тип: 1 - Permanent, 2 - Contract, 3 - Intern");
            string type = Console.ReadLine();

            ISalaryCalculator calculator = type switch
            {
                "1" => new PermanentSalaryCalculator(),
                "2" => new ContractSalaryCalculator(),
                "3" => new InternSalaryCalculator(),
                _ => throw new Exception("Неизвестный тип сотрудника")
            };

            double salary = calculator.CalculateSalary(employee);
            Console.WriteLine($"{employee.Name} получит: {salary}$");
        }
    }
}
