using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Task_1
{
    internal class Line : Shape
    {
        Point Start;
        Point End;

        public Line()
        {
            Start = new Point(0, 0);
            End = new Point(0, 0);
            Co = Color.Black;
        }

        public Line(int x1, int y1, int x2, int y2, Color c)
        {
            Start = new Point(x1, y1);
            End = new Point(x2, y2);
            Co = c;
        }

        public Line(Point p1, Point p2, Color c)
        {
            Start = p1;
            End = p2;
            Co = c;
        }

        public override void Draw()
        {
            Raylib.DrawLine(Start.getX(), Start.getY(), End.getX(), End.getY(), Co);
        }
    }
}
