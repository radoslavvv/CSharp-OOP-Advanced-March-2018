using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Employee employee = new Employee("Ivan");

        List<string> documents = new List<string> { "document1", "document2" };
        Manager manager = new Manager("Georgi", documents);

        List<Employee> employees = new List<Employee> { employee, manager };

        DetailsPrinter dp = new DetailsPrinter(employees);
        dp.PrintDetails();
    }
}

