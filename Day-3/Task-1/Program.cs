using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static string name = "";
        static string id = "";
        static int salary = 0;
        static void Main(string[] args)
        {
            string[] Menu = { "New", "Display", "Exit" };
            int xDistance = (120 - 10) / 2;
            int yDistance = (30 - 3) / 4;

            bool exit = false;
            int Highlighted = 0;

            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                for (int i = 0; i < Menu.Length; i++)
                {
                    if (i == Highlighted)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.SetCursorPosition(xDistance, yDistance + (i * yDistance));
                    Console.WriteLine(Menu[i]);
                }
                ConsoleKeyInfo kInfo = Console.ReadKey();
                switch (kInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Highlighted--;
                        if (Highlighted < 0)
                            Highlighted = Menu.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        Highlighted++;
                        if (Highlighted >= Menu.Length)
                            Highlighted = 0;
                        break;

                    case ConsoleKey.Enter:
                        switch (Highlighted)
                        {
                            case 0:
                                NewMethod();
                                break;

                            case 1:
                                DisplayMethod();
                                break;
                            case 2:
                                exit = true;
                                break;
                        }
                        break;

                }

            } while (!exit);

        }

        private static void NewMethod()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("Enter new employee's ID: ");
            id = Console.ReadLine();
            Console.WriteLine("Enter new employee's name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter new employee's salary: ");
            salary = int.Parse(Console.ReadLine());
            Console.WriteLine($"New employee added: ID = {id}, Name = {name}, Salary = {salary}");
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }

        private static void DisplayMethod()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || salary <= 0)
            {
                Console.WriteLine("No employee data available. Please add an employee first.");
            }
            else
            {
                Console.WriteLine($"Employee ID: {id}");
                Console.WriteLine($"Employee Name: {name}");
                Console.WriteLine($"Employee Salary: {salary}");
            }
            Console.WriteLine("Press any key to return to the menu.");
            Console.ReadKey();
        }
    }
}
