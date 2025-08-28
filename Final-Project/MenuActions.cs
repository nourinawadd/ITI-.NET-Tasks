using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Final_Project
{
    public static class MenuActions
    {
        public static void Run()
        {
            using var db = new AppDbContext();
            db.Database.EnsureCreated();

            while (true)
            {
                Console.WriteLine("\n=== Company Management ===");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. Add Employee");
                Console.WriteLine("3. Add Project");
                Console.WriteLine("4. Assign Employee to Department");
                Console.WriteLine("5. Assign Employee to Project");
                Console.WriteLine("6. Remove Employee from Project");
                Console.WriteLine("7. Show Employees");
                Console.WriteLine("8. Show Departments");
                Console.WriteLine("9. Show Projects");
                Console.WriteLine("10. Delete Employee");
                Console.WriteLine("11. Delete Department");
                Console.WriteLine("12. Delete Project");
                Console.WriteLine("0. Exit");
                Console.Write("Choose: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDepartment(); break;
                    case "2": AddEmployee(); break;
                    case "3": AddProject(); break;
                    case "4": AssignEmployeeToDepartment(); break;
                    case "5": AssignEmployeeToProject(); break;
                    case "6": RemoveEmployeeFromProject(); break;
                    case "7": ShowEmployees(); break;
                    case "8": ShowDepartments(); break;
                    case "9": ShowProjects(); break;
                    case "10": DeleteEmployee(); break;
                    case "11": DeleteDepartment(); break;
                    case "12": DeleteProject(); break;
                    case "0": return;
                    default: Console.WriteLine("Invalid choice."); break;
                }
            }
        }

        // CRUD METHODS 

        static void AddDepartment()
        {
            Console.Write("Enter Department Name: ");
            var name = Console.ReadLine();
            using var db = new AppDbContext();
            db.Departments.Add(new Department { Name = name });
            db.SaveChanges();
            Console.WriteLine("Department added!");
        }

        static void AddEmployee()
        {
            Console.Write("Enter Employee Name: ");
            var name = Console.ReadLine();
            using var db = new AppDbContext();
            db.Employees.Add(new Employee { FullName = name });
            db.SaveChanges();
            Console.WriteLine("Employee added!");
        }

        static void AddProject()
        {
            Console.Write("Enter Project Title: ");
            var title = Console.ReadLine();
            using var db = new AppDbContext();
            db.Projects.Add(new Project { Title = title });
            db.SaveChanges();
            Console.WriteLine("Project added!");
        }

        static void AssignEmployeeToDepartment()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.ToList();
            var departments = db.Departments.ToList();

            if (!employees.Any() || !departments.Any())
            {
                Console.WriteLine("No employees or departments available.");
                return;
            }

            Console.WriteLine("Select Employee:");
            foreach (var e in employees) Console.WriteLine($"{e.EmployeeId}: {e.FullName}");
            int empId = int.Parse(Console.ReadLine());

            Console.WriteLine("Select Department:");
            foreach (var d in departments) Console.WriteLine($"{d.DepartmentId}: {d.Name}");
            int deptId = int.Parse(Console.ReadLine());

            var emp = db.Employees.Find(empId);
            emp.DepartmentId = deptId;
            db.SaveChanges();
            Console.WriteLine("Assigned!");
        }

        static void AssignEmployeeToProject()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.ToList();
            var projects = db.Projects.ToList();

            if (!employees.Any() || !projects.Any())
            {
                Console.WriteLine("No employees or projects available.");
                return;
            }

            Console.WriteLine("Select Employee:");
            foreach (var e in employees) Console.WriteLine($"{e.EmployeeId}: {e.FullName}");
            int empId = int.Parse(Console.ReadLine());

            Console.WriteLine("Select Project:");
            foreach (var p in projects) Console.WriteLine($"{p.ProjectId}: {p.Title}");
            int projId = int.Parse(Console.ReadLine());

            var emp = db.Employees.Include(e => e.Projects).First(e => e.EmployeeId == empId);
            var proj = db.Projects.Find(projId);

            emp.Projects.Add(proj);
            db.SaveChanges();
            Console.WriteLine("Assigned!");
        }

        static void RemoveEmployeeFromProject()
        {
            using var db = new AppDbContext();
            var emp = db.Employees.Include(e => e.Projects).FirstOrDefault();

            if (emp == null || !emp.Projects.Any())
            {
                Console.WriteLine("No employee or assigned projects.");
                return;
            }

            Console.WriteLine($"Employee: {emp.FullName}");
            Console.WriteLine("Projects:");
            foreach (var p in emp.Projects) Console.WriteLine($"{p.ProjectId}: {p.Title}");
            int projId = int.Parse(Console.ReadLine());

            var proj = emp.Projects.First(p => p.ProjectId == projId);
            emp.Projects.Remove(proj);
            db.SaveChanges();
            Console.WriteLine("Removed!");
        }

        static void ShowEmployees()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Projects).ToList();
            foreach (var e in employees)
            {
                Console.WriteLine($"\nEmployee: {e.FullName} (Dept: {e.Department?.Name ?? "None"})");
                foreach (var p in e.Projects) Console.WriteLine($"   Project: {p.Title}");
            }
        }

        static void ShowDepartments()
        {
            using var db = new AppDbContext();
            var depts = db.Departments.Include(d => d.Employees).ToList();
            foreach (var d in depts)
            {
                Console.WriteLine($"\nDepartment: {d.Name}");
                foreach (var e in d.Employees) Console.WriteLine($"   Employee: {e.FullName}");
            }
        }

        static void ShowProjects()
        {
            using var db = new AppDbContext();
            var projects = db.Projects.Include(p => p.Employees).ToList();
            foreach (var p in projects)
            {
                Console.WriteLine($"\nProject: {p.Title}");
                foreach (var e in p.Employees) Console.WriteLine($"   Employee: {e.FullName}");
            }
        }

        static void DeleteEmployee()
        {
            using var db = new AppDbContext();
            var employees = db.Employees.ToList();
            foreach (var e in employees) Console.WriteLine($"{e.EmployeeId}: {e.FullName}");
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var emp = db.Employees.Find(id);
            if (emp != null)
            {
                db.Employees.Remove(emp);
                db.SaveChanges();
                Console.WriteLine("Employee deleted!");
            }
        }

        static void DeleteDepartment()
        {
            using var db = new AppDbContext();
            var depts = db.Departments.ToList();
            foreach (var d in depts) Console.WriteLine($"{d.DepartmentId}: {d.Name}");
            Console.Write("Enter Department ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var dept = db.Departments.Find(id);
            if (dept != null)
            {
                db.Departments.Remove(dept);
                db.SaveChanges();
                Console.WriteLine("Department deleted!");
            }
        }

        static void DeleteProject()
        {
            using var db = new AppDbContext();
            var projects = db.Projects.ToList();
            foreach (var p in projects) Console.WriteLine($"{p.ProjectId}: {p.Title}");
            Console.Write("Enter Project ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var proj = db.Projects.Find(id);
            if (proj != null)
            {
                db.Projects.Remove(proj);
                db.SaveChanges();
                Console.WriteLine("Project deleted!");
            }
        }
    }
}
