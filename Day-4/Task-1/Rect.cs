using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib_cs;

namespace Task_1
{
    internal class Rect : Shape
    {
        Point UL; // upper left
        Point LR; // lower right

        public Rect()
        {
            UL = new Point(0, 0);
            LR = new Point(0, 0);
            Co = Color.Black;
        }

        public Rect(int x1, int y1, int x2, int y2, Color c)
        {
            UL = new Point(x1, y1);
            LR = new Point(x2, y2);
            Co = c;
        }

        public override void Draw()
        {
            int width = LR.getX() - UL.getX();
            int height = LR.getY() - UL.getY();
            Raylib.DrawRectangle(UL.getX(), UL.getY(), width, height, Co);
        }
    }
}
