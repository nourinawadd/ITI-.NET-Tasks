// Create simple menu  and get user selection from it
//  Option 1 To calculate sum 
// Option 2 get max
// Option 3 get min

using System;
class Task2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Select an option:");
        Console.WriteLine("1. Calculate Sum");
        Console.WriteLine("2. Get Maximum");
        Console.WriteLine("3. Get Minimum");

        int option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:
                double sum = num1 + num2;
                Console.WriteLine($"Sum = {sum}");
                break;
            case 2:
                double max = Math.Max(num1, num2);
                Console.WriteLine($"Maximum = {max}");
                break;
            case 3:
                double min = Math.Min(num1, num2);
                Console.WriteLine($"Minimum = {min}");
                break;
            default:
                Console.WriteLine("Invalid option selected.");
                break;
        }
    }
}