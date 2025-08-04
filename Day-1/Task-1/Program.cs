//  Get sum , average for 2 numbers entered by the user
using System;
class Task1
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter first number:");
        double num1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        double num2 = Convert.ToDouble(Console.ReadLine());

        double sum = num1 + num2;
        double average = sum/2;

        Console.WriteLine($"Sum = {sum}");
        Console.WriteLine($"Average = {average}");
    }
}