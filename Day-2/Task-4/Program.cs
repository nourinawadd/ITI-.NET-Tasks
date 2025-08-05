//  Design a program to Get the degree of 3 student with 4 subject 
// from user 
// calculate
//  □
//  □
//  The sum of marks for each student 
// The average for each subject
// in this format:
// Student1 Subject1 Subject2 Subject3 Subject4 Sum
// Student2 Subject1 Subject2 Subject3 Subject4 Sum
// Student3 Subject1 Subject2 Subject3 Subject4 Sum
//           avg1  avg2  avg3  avg4

using System;
class Task4
{
    static void Main(string[] args)
    {
        string[] students = new string[3];
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Enter the name of student {i + 1}:");
            students[i] = Console.ReadLine();
        }

        double[,] marks = new double[students.Length, 4];
        
        // Get marks from user
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"Enter marks for {students[i]}:");

            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Subject {j + 1}: ");
                marks[i, j] = Convert.ToDouble(Console.ReadLine());
            }
        }

        // Calculate and display results
        Console.WriteLine("\nResults:");
        Console.WriteLine("Student  Subject1  Subject2  Subject3  Subject4  Sum");

        double[] subjectSums = new double[4];
        for (int i = 0; i < students.Length; i++)
        {
            double studentSum = 0;
            Console.Write($"{students[i]}  ");

            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{marks[i, j]}  ");
                studentSum += marks[i, j];
                subjectSums[j] += marks[i, j];
            }

            Console.WriteLine($"{studentSum}");
        }

        Console.Write("Average  ");
        for (int j = 0; j < 4; j++)
        {
            Console.Write($"{subjectSums[j] / students.Length}  ");
        }
    }
}