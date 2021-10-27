using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;
using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var context = new SoftUniContext();
            using (context)
            {
                //Console.WriteLine(GetEmployeesFullInformation(context));
                //Console.WriteLine(GetEmployeesWithSalaryOver50000(context));
                //Console.WriteLine(GetEmployeesFromResearchAndDevelopment(context));
                //Console.WriteLine(AddNewAddressToEmployee(context));
                //Console.WriteLine(GetEmployeesInPeriod(context));
                //Console.WriteLine(GetAddressesByTown(context));
                //Console.WriteLine(GetEmployee147(context));
                //Console.WriteLine(GetDepartmentsWithMoreThan5Employees(context));
                //Console.WriteLine(GetLatestProjects(context));
                //Console.WriteLine(IncreaseSalaries(context));
                //Console.WriteLine(GetEmployeesByFirstNameStartingWithSa(context));
                //Console.WriteLine(DeleteProjectById(context));
                Console.WriteLine(RemoveTown(context));
            }
        }

        // Task 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.MiddleName,
                e.JobTitle,
                e.Salary
            })
            .OrderBy(e => e.EmployeeId)
            .ToList();

            StringBuilder result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        // Task 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.Salary
            })
            .Where(e => e.Salary > 50000)
            .OrderBy(e => e.FirstName)
            .ToList();

            var result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        // Task 05
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Department,
                e.Salary
            })
            .Where(e => e.Department.Name == "Research and Development")
            .OrderBy(e => e.Salary)
            .ThenByDescending(e => e.FirstName)
            .ToList();

            var result = new StringBuilder();

            foreach (var employee in employees)
            {
                result.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return result.ToString().Trim();
        }

        // Task 06
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            context.Addresses.Add(address);
            context.SaveChanges();

            var employee = context.Employees.First(e => e.LastName == "Nakov");

            employee.Address = address;
            context.SaveChanges();

            var allEmployees = context.Employees.OrderByDescending(e => e.AddressId).Select(e => e.Address.AddressText).Take(10).ToList();

            return String.Join(Environment.NewLine, allEmployees);
        }

        // Task 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var employees = context.Employees.Where(e => e.EmployeesProjects
                    .Any(ep => ep.Project.StartDate.Year >= 2001 && ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    managerFirstName = e.Manager.FirstName,
                    managerLastName = e.Manager.LastName,
                    projects = e.EmployeesProjects.Select(ep => new
                    {
                        ProjectName = ep.Project.Name,
                        ProjectStartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                        ProjectEndDate = ep.Project.EndDate.HasValue ? ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                            : "not finished"
                    }).ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.managerFirstName} {employee.managerLastName}");
                foreach (var ep in employee.projects)
                {
                    sb.AppendLine($"--{ep.ProjectName} - {ep.ProjectStartDate} - {ep.ProjectEndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        // Task 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count)
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    NumberOfEmployees = a.Employees.Count,
                    a.AddressText,
                    a.Town.Name
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.Name} - {address.NumberOfEmployees} employees");
            }

            return sb.ToString().Trim();
        }

        // Task 09
        public static string GetEmployee147(SoftUniContext context)
        {
            var employee = context.Employees.Select(e => new
            {
                e.EmployeeId,
                e.FirstName,
                e.LastName,
                e.JobTitle,
                Projects = e.EmployeesProjects.Select(p => new
                {
                    p.Project.Name
                })
                    .OrderBy(p => p.Name)
                    .ToList()
            }).Where(e => e.EmployeeId == 147)
              .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var e in employee)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"{p.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        // Task 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var departments = context.Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(e => e.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    DepartmentName = d.Name,
                    ManagerFirstName = d.Manager.FirstName,
                    ManagerLastname = d.Manager.LastName,
                    allEmployees = d.Employees.Select(e => new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        JobTitle = e.JobTitle
                    }).OrderBy(e => e.FirstName)
                      .ThenBy(e => e.LastName)
                      .ToList()
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.DepartmentName} - {department.ManagerFirstName} {department.ManagerLastname}");
                foreach (var employee in department.allEmployees)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        // Task 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    ProjectName = p.Name,
                    ProjectDescription = p.Description,
                    ProjectStartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                })
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.ProjectName}");
                sb.AppendLine($"{project.ProjectDescription}");
                sb.AppendLine($"{project.ProjectStartDate}");
            }

            return sb.ToString().Trim();
        }

        // Task 12
        public static string IncreaseSalaries(SoftUniContext context)
        {
            var employeesToIncreaseSalary = context.Employees
                .Where(d => d.Department.Name == "Engineering"
                            || d.Department.Name == "Tool Design"
                            || d.Department.Name == "Marketing"
                            || d.Department.Name == "Information Services")
                .ToList();

            foreach (var employee in employeesToIncreaseSalary)
            {
                employee.Salary *= 1.12m;
            }

            context.SaveChanges();

            var employees = employeesToIncreaseSalary
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        // Task 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var employeesWithSa = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            var sb = new StringBuilder();

            foreach (var employee in employeesWithSa)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().Trim();
        }

        // Task 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var project = context.Projects.Find(2);

            var projectToDelete = context.EmployeesProjects
                .Where(e => e.ProjectId == 2)
                .ToList();

            foreach (var p in projectToDelete)
            {
                context.EmployeesProjects.Remove(p);
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            var tenProjects = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            var sb = new StringBuilder();

            foreach (var p in tenProjects)
            {
                sb.AppendLine($"{p}");
            }

            return sb.ToString().Trim();
        }

        // Task 15
        public static string RemoveTown(SoftUniContext context)
        {
            var seattleTown = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addressesToDelete = context.Addresses
                .Where(a => a.TownId == seattleTown.TownId);

            var employeeAddressesToDelete = context.Employees
                .Where(e => addressesToDelete.Any(a => a.AddressId == e.AddressId));

            var count = addressesToDelete.Count();

            foreach (var e in employeeAddressesToDelete)
            {
                e.AddressId = null;
            }

            foreach (var address in addressesToDelete)
            {
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(seattleTown);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}
