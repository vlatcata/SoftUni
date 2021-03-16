using P03.Detail_Printer;
using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            List<IEmployee> employees = new List<IEmployee>();
            IEmployee employee = new Employee("Ivan");
            IEmployee manager = new Manager("boris", new List<string> {"kucheta", "kotki"});
            employees.Add(employee);
            employees.Add(manager);
            DetailsPrinter printer = new DetailsPrinter(employees);
            printer.PrintDetails();

        }
    }
}
