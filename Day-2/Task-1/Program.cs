// magic box. task 1
using System;
// make the user enter the size of the magic box
// handle cases of odd or even size
class Task1
{
    static void Main(string[] args)
    {
        int n;
        int row, col;
        int size;
        row = 1;
        col = 2;

        Console.WriteLine("Enter the size of the magic box (1, 3, 5, 7, 9):");
        size = Convert.ToInt32(Console.ReadLine());

        if (size < 1 || size > 9)
        {
            Console.WriteLine("Size must be between 1 and 9.");
            return;
        }

        if (size % 2 == 0)
        {
            Console.WriteLine("Even size is not supported.");
            return;
        }

        int rowDistance = 30 / (size + 1);
        int colDistance = 120 / (size + 1);

        for (n = 0; n <= size * size; n++)
        {
            Console.SetCursorPosition(col * colDistance, row * rowDistance);
            Console.WriteLine(n);

            if (n % size != 0)
            {
                row--;
                col--;
                if (row < 1)
                {
                    row = size;
                }
                if (col < 1)
                {
                    col = size;
                }
            }
            else
            {
                row++;
                if (row > size)
                {
                    row = 1;
                }
            }
        }
        Console.WriteLine();
    }
}
