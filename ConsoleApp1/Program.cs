using System;
using System.Collections.Generic;
using System.Globalization;
using ConsoleApp1.Entities;
using ConsoleApp1.Entities.Enums;

namespace ConsoleApp1 {
    class Program {

        static void Main(string[] args) {

            Console.Write("Enter department's name:");
            string nameDepo = Console.ReadLine();

            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string nameWorker = Console.ReadLine();
            Console.Write("Level(Junior/MidLevel/Senior): ");

            WorkerLevel level;
            if (!Enum.TryParse<WorkerLevel>(Console.ReadLine(), out level))
                throw new Exception("Value is not valid member of enumeration WorkerLevel enum.");

            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(nameDepo);
            Worker worker = new Worker(nameWorker, level, salary, dept);

            Console.Write("How many contracts to this worker?");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++) {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valueHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int duration = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valueHour, duration);
                worker.AddContract(contract);
            }
            
            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Name: " + worker.name);
            Console.WriteLine("Department: " + worker.department.name);
            Console.WriteLine("Income for " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
 