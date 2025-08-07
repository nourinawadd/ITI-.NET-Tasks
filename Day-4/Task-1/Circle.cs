using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Task_1
{
    internal class Circle : Shape
    {
        Point Center;
        int radius;

        public Circle()
        {
            Center = new Point(0, 0);
            radius = 10;
            Co = Color.Black;
        }

        public Circle(int x, int y, int r, Color c)
        {
            Center = new Point(x, y);
            radius = r;
            Co = c;
        }

        public Circle(Point center, int r, Color c)
        {
            Center = center;
            radius = r;
            Co = c;
        }

        public override void Draw()
        {
            Raylib.DrawCircle(Center.getX(), Center.getY(), radius, Co);
        }
    }
}
