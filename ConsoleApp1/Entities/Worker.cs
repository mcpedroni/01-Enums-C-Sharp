using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities.Enums;

namespace ConsoleApp1.Entities {

    class Worker {

        public string name { get; set; }
        public WorkerLevel level { get; set; }
        public double baseSalary { get; set; }
        public Department department { get; set; }
        public List<HourContract> contracts { get; set; } = new List<HourContract>();

        public Worker() {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department) {
            this.name = name;
            this.level = level;
            this.baseSalary = baseSalary;
            this.department = department;
        }

        public void AddContract(HourContract contract) {
            contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract) {
            contracts.Remove(contract);
        }

        public double Income(int year, int month) {
            double sum = baseSalary;

            foreach (HourContract c in contracts) {
                if (c.date.Year == year && c.date.Month == month) {
                    sum += c.totalValue();
                }
            }

            return sum;
        }
    }
}
