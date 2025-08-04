//  Simple calculator 
//  Get 2 number from user and get operator (* or / or + or -)
//  Calculate the result
using System;
class Task3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Select an operator (+, -, *, /):");
        char operation = Console.ReadKey().KeyChar;
        Console.WriteLine();

        double result;
        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 != 0)
                    result = num1 / num2;
                else
                {
                    Console.WriteLine("Cannot divide by zero.");
                    return;
                }
                break;
            default:
                Console.WriteLine("Invalid operator selected.");
                return;
        }

        Console.WriteLine($"Result = {result}");
    }
}