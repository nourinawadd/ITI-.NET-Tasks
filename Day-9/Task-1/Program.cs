//using CompanyApp.Data;
//using CompanyApp.Models;
using Task_1.Data;
using Task_1.Models;

class Program
{
    static void Main(string[] args)
    {
        using var context = new CompanyDbContext();
        Console.WriteLine("Connected to DB: " + context.Database.CanConnect());

        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Add Department");
            Console.WriteLine("2. Add Employee");
            Console.WriteLine("3. Add Project");
            Console.WriteLine("4. Display Departments");
            Console.WriteLine("5. Display Employees");
            Console.WriteLine("6. Display Projects");
            Console.WriteLine("0. Exit");
            Console.Write("Option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddDepartment(context); break;
                case "2": AddEmployee(context); break;
                case "3": AddProject(context); break;
                case "4": DisplayDepartments(context); break;
                case "5": DisplayEmployees(context); break;
                case "6": DisplayProjects(context); break;
                case "0": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }

    static void AddDepartment(CompanyDbContext context)
    {
        Console.Write("Enter department name: ");
        string name = Console.ReadLine();

        var dept = new Department { Name = name };
        context.Departments.Add(dept);
        context.SaveChanges();

        Console.WriteLine("Department added!");
    }

    static void AddEmployee(CompanyDbContext context)
    {
        Console.Write("First name: ");
        string first = Console.ReadLine();
        Console.Write("Last name: ");
        string last = Console.ReadLine();
        Console.Write("Department ID: ");
        int deptId = int.Parse(Console.ReadLine());

        var emp = new Employee { FirstName = first, LastName = last, DepartmentId = deptId };
        context.Employees.Add(emp);
        context.SaveChanges();

        Console.WriteLine("Employee added!");
    }

    static void AddProject(CompanyDbContext context)
    {
        Console.Write("Project name: ");
        string name = Console.ReadLine();
        Console.Write("Start date (yyyy-mm-dd): ");
        DateOnly start = DateOnly.FromDateTime(DateTime.Parse(Console.ReadLine()));

        var proj = new Project { Name = name, StartDate = start };
        context.Projects.Add(proj);
        context.SaveChanges();

        Console.WriteLine("Project added!");
    }

    static void DisplayDepartments(CompanyDbContext context)
    {
        foreach (var d in context.Departments)
            Console.WriteLine($"{d.DepartmentId}: {d.Name}");
    }

    static void DisplayEmployees(CompanyDbContext context)
    {
        foreach (var e in context.Employees)
            Console.WriteLine($"{e.EmployeeId}: {e.FirstName} {e.LastName} (Dept {e.DepartmentId})");
    }

    static void DisplayProjects(CompanyDbContext context)
    {
        foreach (var p in context.Projects)
            Console.WriteLine($"{p.ProjectId}: {p.Name} (Start {p.StartDate:d})");
    }
}
