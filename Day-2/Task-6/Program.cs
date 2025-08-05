//  Menu Program
//  Design Menu program
//  New      
//  NewMethod (…)
//  Get Employee Data ( ID, Name, Salary)
//  Display  
//  Exit
//  DisplayMethod(…)
//  Display Employee Data
//  ExitMethod (…) 
// Exit the program

using System;
class Task6
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. New Employee");
            Console.WriteLine("2. Display Employees");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    NewEmployee();
                    break;
                case "2":
                    DisplayEmployees();
                    break;
                case "3":
                    ExitProgram();
                    return;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    break;
            }
        }
    }

    static void NewEmployee()
    {
        Console.Write("Enter Employee ID: ");
        int id = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();
        
        Console.Write("Enter Employee Salary: ");
        double salary = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine($"Employee {name} with ID {id} and Salary {salary} added successfully.");
    }

    static void DisplayEmployees()
    {
        // I would display a list of employees here.
        Console.WriteLine("Displaying all employees:");
    }

    static void ExitProgram()
    {
        Console.WriteLine("Exiting the program. Goodbye!");
    }
}