using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ClassLibrary1;

namespace Task1
{
    internal class Program
    {
        static string[] Menu = { "New", "Display", "Search", "Sort", "Save", "Load", "Exit" };
        static int xDistance = (120 - 10) / 2;
        static int yDistance = (30 - 3) / 4;

        static bool exit = false;
        static int Highlighted = 0;

        static List<Employee> employees = new List<Employee>();
        static string filePath = "employees.json";

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
                            case 4: SaveEmployees(); break;
                            case 5: LoadEmployees(); break;
                            case 6: exit = true; break;
                        }
                        break;
                }

            } while (!exit);
        }

        private static void NewEmployee()
        {
            Console.Clear();
            Employee employee = new Employee();

            Console.Write("Enter ID: ");
            employee.ID = Console.ReadLine();

            Console.Write("Enter Name: ");
            employee.Name = Console.ReadLine();

            try
            {
                Console.Write("Enter Age (18-60): ");
                employee.Age = int.Parse(Console.ReadLine());

                Console.Write("Enter Salary: ");
                employee.Salary = int.Parse(Console.ReadLine());

                employees.Add(employee);
                Console.WriteLine("\nEmployee added successfully.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. Please enter numeric values for Age and Salary.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Returning to menu...");
                Console.ReadKey();
            }
        }

        private static void DisplayEmployees()
        {
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
                Console.WriteLine(found != null ? found.DisplayData() : "Employee not found.");
            }
            else if (choice == "2")
            {
                Console.Write("Enter Name: ");
                string name = Console.ReadLine();
                var found = employees.Find(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                Console.WriteLine(found != null ? found.DisplayData() : "Employee not found.");
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
                case "1": employees.Sort(new SortByIdAsc()); break;
                case "2": employees.Sort(new SortByIdDesc()); break;
                case "3": employees.Sort(new SortByName()); break;
                case "4": employees.Sort(new SortBySalary()); break;
                default:
                    Console.WriteLine("Invalid choice.");
                    Console.ReadKey();
                    return;
            }

            Console.WriteLine("Employees sorted successfully!");
            Console.ReadKey();
        }

        private static void SaveEmployees()
        {
            try
            {
                string jsonData = JsonSerializer.Serialize(employees);
                File.WriteAllText(filePath, jsonData);
                Console.WriteLine("Employees saved successfully to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving file: " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private static void LoadEmployees()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    employees = JsonSerializer.Deserialize<List<Employee>>(jsonData);
                    Console.WriteLine("Employees loaded successfully from file.");
                }
                else
                {
                    Console.WriteLine("No saved file found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading file: " + ex.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }

    // Comparers
    class SortByIdAsc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.ID.CompareTo(y.ID);
    }
    class SortByIdDesc : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => y.ID.CompareTo(x.ID);
    }
    class SortByName : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Name.CompareTo(y.Name);
    }
    class SortBySalary : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y) => x.Salary.CompareTo(y.Salary);
    }
}
