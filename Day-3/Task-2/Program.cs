using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace Task1
{
    internal class Program
    {
        static string[] Menu = { "New", "Display", "Sort", "Exit" };
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
                            case 0: NewMethod(); break;
                            case 1: DisplayMethod(); break;
                            case 2: SortEmployees(); break;
                            case 3: exit = true; break;
                        }
                        break;
                }

            } while (!exit);
        }

        private static void NewMethod()
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

        private static void DisplayMethod()
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

        private static void SortEmployees()
        {
            if (employees.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("No employee data available to sort.");
            }
            else
            {
                employees.Sort((e1, e2) => e1.Name.CompareTo(e2.Name));
                Console.Clear();
                Console.WriteLine("Employees sorted by name successfully!");
            }

            Console.ReadKey();
        }
    }
}
