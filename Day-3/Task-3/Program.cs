using System;
class Stack
{
    private int[] data;
    private int size;
    private int top;

    // Constructor
    public Stack(int size)
    {
        this.size = size;
        data = new int[size];
        top = -1;
    }

    public bool IsFull()
    {
        return top == size - 1;
    }

    public bool IsEmpty()
    {
        return top == -1;
    }

    public void Push(int value)
    {
        if (IsFull())
        {
            Console.WriteLine("Stack is full!");
            return;
        }
        top++;
        data[top] = value;
    }

    public int Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty!");
            return -1;
        }
        int value = data[top];
        top--;
        return value;
    }
}

class Program
{
    static void Main()
    {
        Stack stack = new Stack(5);

        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
        Console.WriteLine(stack.Pop());
    }
}
