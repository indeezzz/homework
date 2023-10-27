using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryLibrary
{
    public abstract class Figure
    {
        protected abstract string FigureName { get; }
        public abstract double Perimeter();
        public abstract double Area();
        public virtual void Print()
        {
            Console.WriteLine($"Периметр {FigureName.ToLower()}а: {Perimeter()}");
            Console.WriteLine($"Площадь {FigureName.ToLower()}а: {Area()}");
        }

        public Figure()
        {
        }
    }
}
