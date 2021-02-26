using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpening
{
    class Bakery
    {
        private List<Employee> data;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            data = new List<Employee>();
        }
        

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count { get { return data.Count; } }

        public void Add(Employee employee)
        {
            if (data.Count < Capacity)
            {
                data.Add(employee);
            }
        }

        public void Remove(string name)
        {
            Employee employee = data.FirstOrDefault(p => p.Name == name);
            if (employee != null)
            {
                data.Remove(employee);
            }
        }

        public Employee GetOldestEmployee()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = data.FirstOrDefault(p => p.Name == name);
            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Employees working at Bakery {Name}:");
            foreach (Employee employee in data)
            {
                sb.Append(employee);
            }
            return sb.ToString();
        }
    }
}
