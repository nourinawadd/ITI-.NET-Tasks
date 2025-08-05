// Design a program that get from user input
//  Number of class room
//  Number of student in each class
//  Mark for each student
//  Then calculate the 
//  Average mark for each class room

using System;
class Task5
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the number of class rooms:");
        int classCount = Convert.ToInt32(Console.ReadLine());

        if (classCount <= 0)
        {
            Console.WriteLine("Class count must be a positive integer.");
            return;
        }

        double[] classAverages = new double[classCount];

        for (int i = 0; i < classCount; i++)
        {
            Console.WriteLine($"Enter the number of students in classroom {i + 1}:");
            int studentCount = Convert.ToInt32(Console.ReadLine());

            if (studentCount <= 0)
            {
                Console.WriteLine("Student count must be a positive integer.");
                return;
            }

            double totalMarks = 0;

            for (int j = 0; j < studentCount; j++)
            {
                Console.WriteLine($"Enter marks for student {j + 1} in classroom {i + 1}:");
                double marks = Convert.ToDouble(Console.ReadLine());
                totalMarks += marks;
            }

            classAverages[i] = totalMarks / studentCount;
        }

        Console.WriteLine("\nAverage marks for each classroom:");
        for (int i = 0; i < classCount; i++)
        {
            Console.WriteLine($"Classroom {i + 1}: {classAverages[i]}");
        }

        Console.WriteLine("\nOverall average marks for all classrooms:");
        double overallAverage = 0;
        foreach (var avg in classAverages)
        {
            overallAverage += avg;
        }
        overallAverage /= classCount;

        Console.WriteLine(overallAverage);
    }
}