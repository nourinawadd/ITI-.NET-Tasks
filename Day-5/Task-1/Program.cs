using System;
class Stack<Type>
{
    private Type[] data;
    private int size;
    private int top;

    public Stack(int size)
    {
        this.size = size;
        data = new Type[size];
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

    public void Push(Type value)
    {
        if (IsFull())
        {
            Console.WriteLine("Stack is full!");
            return;
        }
        top++;
        data[top] = value;
    }

    public Type Pop()
    {
        if (IsEmpty())
        {
            Console.WriteLine("Stack is empty!");
            return default(Type);
        }
        Type value = data[top];
        top--;
        return value;
    }
}

class Program
{
    static void Main()
    {
        Stack<int> intStack = new Stack<int>(5);
        intStack.Push(1);
        intStack.Push(2);
        Console.WriteLine(intStack.Pop());

        Stack<string> stringStack = new Stack<string>(3);
        stringStack.Push("Hello");
        stringStack.Push("World");
        Console.WriteLine(stringStack.Pop());
    }
}
