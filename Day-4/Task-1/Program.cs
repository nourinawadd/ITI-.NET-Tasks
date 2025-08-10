using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "Shapes Drawing");

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.White);

                // create shapes
                Circle c = new Circle(70, 70, 100, Color.Red);
                Circle c2 = new Circle(200, 200, 100, Color.Blue);
                Line l = new Line(500, 500, 240, 240, Color.Magenta);
                Rect r = new Rect(10, 10, 150, 100, Color.Yellow);

                // draw shapes
                c.Draw();
                c2.Draw();
                l.Draw();
                r.Draw();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}