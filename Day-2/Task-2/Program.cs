// Get sum, average ,max ,min of integers given by the user
using System;
class Task2
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of integers:");
        int count = Convert.ToInt32(Console.ReadLine());

        if (count <= 0)
        {
            Console.WriteLine("Count must be a positive integer.");
            return;
        }

        int sum = 0, max = int.MinValue, min = int.MaxValue;

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Enter integer {i + 1}:");
            int number = Convert.ToInt32(Console.ReadLine());

            sum += number;
            if (number > max) max = number;
            if (number < min) min = number;
        }

        double average = (double)sum / count;

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Average: {average}");
        Console.WriteLine($"Max: {max}");
        Console.WriteLine($"Min: {min}");
    }
}