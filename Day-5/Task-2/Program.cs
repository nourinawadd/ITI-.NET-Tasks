using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace Task1
{
    internal class Program
    {
        static string[] Menu = { "New", "Display", "Search", "Sort", "Exit" };
        static int xDistance = (120 - 10) / 2;
        static int yDistance = (30 - 3) / 4;

        static bool exit = false;
        static int Highlighted = 0;

        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                for (int i = 0; i < Menu.Length; i++)
                {
                    Console.BackgroundColor = i == Highlighted ? ConsoleColor.Blue : ConsoleColor.Black;
                    Console.SetCursorPosition(xDistance, yDistance + (i * yDistance));
                    Console.WriteLine(Menu[i]);
                }

                ConsoleKeyInfo kInfo = Console.ReadKey();
                switch (kInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Highlighted = (Highlighted - 1 + Menu.Length) % Menu.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        Highlighted = (Highlighted + 1) % Menu.Length;
                        break;
                    case ConsoleKey.Enter:
                        switch (Highlighted)
                        {
                            case 0: NewEmployee(); break;
                            case 1: DisplayEmployees(); break;
                            case 2: SearchEmployees(); break;
                            case 3: SortEmployees(); break;
                            case 4: exit = true; break;
                        }
                        break;
                }

            } while (!exit);
        }

        private static void NewEmployee()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Employee employee = new Employee();

            Console.Write("Enter ID: ");
            employee.ID = Console.ReadLine();

            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();

            Console.Write("Enter Age (18-60): ");
            int age = int.Parse(Console.ReadLine());
            try
            {
                employee.Age = age;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Salary: ");
            employee.Salary = int.Parse(Console.ReadLine());

            employees.Add(employee);

            Console.WriteLine("\nEmployee added successfully.");
            Console.ReadKey();
        }

        private static void DisplayEmployees()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            if (employees.Count == 0)
            {
                Console.WriteLine("No employee data available.");
            }
            else
            {
                foreach (var emp in employees)
                {
                    Console.WriteLine(emp.DisplayData());
                    Console.WriteLine(new string('-', 40));
                }
            }

            Console.ReadKey();
        }

        private static void SearchEmployees()
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees to search.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Search by: 1) ID  2) Name");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.Write("Enter ID: ");
                string id = Console.ReadLine();
                var found = employees.Find(e => e.ID.Equals(id, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                    Console.WriteLine(found.DisplayData());
                else
                    Console.WriteLine("Employee not found.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                var found = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (found != null)
                    Console.WriteLine(found.DisplayData());
                else
                    Console.WriteLine("Employee not found.");
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }

            Console.ReadKey();
        }

        private static void SortEmployees()
        {
            Console.Clear();
            if (employees.Count == 0)
            {
                Console.WriteLine("No employee data available to sort.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Sort by:\n1) ID Asc\n2) ID Desc\n3) Name\n4) Salary");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    employees.Sort(new SortByIdAsc());
                    break;
                case "2":
                    employees.Sort(new SortByIdDesc());
                    break;
                case "3":
                    employees.Sort(new SortByName());
                    break;
                case "4":
                    employees.Sort(new SortBySalary());
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("Employees sorted successfully!");
            Console.ReadKey();
        }
    }

    // Comparers
    class SortByIdAsc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.ID.CompareTo(y.ID);
        }
    }

    class SortByIdDesc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return y.ID.CompareTo(x.ID);
        }
    }

    class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    class SortBySalary : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.Salary.CompareTo(y.Salary);
        }
    }
}
