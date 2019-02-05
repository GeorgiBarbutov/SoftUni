using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, List<Employee>> departaments = new Dictionary<string, List<Employee>>();

        int n = int.Parse(Console.ReadLine());

        GetInput(departaments, n);

        string departamentName = CalculateHighestAverageSalary(departaments);

        Print(departaments, departamentName);
    }

    private static void Print(Dictionary<string, List<Employee>> departaments, string departamentName)
    {
        List<Employee> sortedListOfEmployees = departaments[departamentName].OrderByDescending(x => x.Salary).ToList();

        Console.WriteLine($"Highest Average Salary: {departamentName}");

        foreach (var employee in sortedListOfEmployees)
        {
            employee.Print();
        }
    }

    private static string CalculateHighestAverageSalary(Dictionary<string, List<Employee>> departaments)
    {
        string bestDepartamentIndex = "";

        double highestAverageSalary = 0;

        foreach (var departament in departaments)
        {
            double currentAverageSalary = 0;
            double totalSalary = 0;
            int peopleInDepartament = departament.Value.Count;

            for (int j = 0; j < departament.Value.Count; j++)
            {
                totalSalary += departament.Value[j].Salary;
            }

            currentAverageSalary = totalSalary / peopleInDepartament;

            if (currentAverageSalary > highestAverageSalary)
            {
                highestAverageSalary = currentAverageSalary;
                bestDepartamentIndex = departament.Key;
            }
        }

        return bestDepartamentIndex;
    }

    private static void GetInput(Dictionary<string, List<Employee>> departaments, int n)
    {
        for (int i = 0; i < n; i++)
        {
            string[] employeeInput = Console.ReadLine().Split(' ');

            string employeeName = employeeInput[0];
            double employeeSalary = double.Parse(employeeInput[1]);
            string employeePosition = employeeInput[2];
            string employeeDepartament = employeeInput[3];
            string employeeEmail = "n/a";
            int employeeAge = -1;


            if (employeeInput.Length == 5)
            {
                int age;

                bool isAge = int.TryParse(employeeInput[4], out age);

                if (isAge)
                {
                    employeeAge = age;
                }
                else
                {
                    employeeEmail = employeeInput[4];
                }
            }

            if (employeeInput.Length == 6)
            {
                employeeEmail = employeeInput[4];
                employeeAge = int.Parse(employeeInput[5]);
            }

            Employee employee = new Employee(employeeName, employeeSalary, employeePosition, employeeDepartament, employeeEmail, employeeAge);

            if (departaments.ContainsKey(employeeDepartament))
            {
                departaments[employeeDepartament].Add(employee);
            }
            else
            {
                departaments.Add(employeeDepartament, new List<Employee>());
                departaments[employeeDepartament].Add(employee);
            }
        }
    }
}

