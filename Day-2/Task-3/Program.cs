// Calculate the result of one operation  Equation
//  Ex: user Input 5*3 
//  Output: 15  
using System;
class Task3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter an equation (e.g., 5*3):");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Input cannot be empty.");
            return;
        }

        char[] operators = { '+', '-', '*', '/' };
        string[] parts = input.Split(operators);

        if (parts.Length != 2)
        {
            Console.WriteLine("Invalid equation format. Please use the format 'number operator number'.");
            return;
        }

        if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[1], out double num2))
        {
            Console.WriteLine("Invalid numbers in the equation.");
            return;
        }

        char operation = input[parts[0].Length];

        double result = 0;

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
                if (num2 == 0)
                {
                    Console.WriteLine("Division by zero is not allowed.");
                    return;
                }
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Unsupported operation.");
                return;
        }

        Console.WriteLine($"Result: {result}");
    }
}