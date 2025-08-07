using System;
using System.Collections.Generic;
using Raylib_cs;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal abstract class Shape
    {
        protected Color Co;
        public Shape()
        {
            Co = Color.Black;
        }

        public abstract void Draw();
    }
}
