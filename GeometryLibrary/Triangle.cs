namespace GeometryLibrary
{
    public class Triangle : Figure
    {
        private double _a;
        private double _b;
        private double _c;
        private double _areaTriangle;
        private double _perimeterTriangle;

        public double A { get { return _a; } set { _a = value; } }
        public double B { get { return _b; } set { _b = value; } }
        public double C { get { return _c; } set { _c = value; } }

        protected override string FigureName => "Треугольник";
        public override double Perimeter()
        {
            _perimeterTriangle = (A + B + C) / 2;
            return _perimeterTriangle;
        }

        public override double Area()
        {
            _perimeterTriangle = Perimeter();
            _areaTriangle = Math.Sqrt(_perimeterTriangle * (_perimeterTriangle - A) * (_perimeterTriangle - B) * (_perimeterTriangle - C));
            return _areaTriangle;
        }
        public bool validTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && c + b > a ? true : false;
        }
        public string typeTriangle(double a, double b, double c)
        {
            string typeTriangle = $"{FigureName}";
            if (c > a && c > b)
            {
                if (Math.Pow(c, 2) < Math.Pow(a, 2) + Math.Pow(b, 2))
                {
                    typeTriangle += " тупоугольный";
                }
                else if (Math.Pow(c, 2) == Math.Pow(a, 2) + Math.Pow(b, 2))
                {
                    typeTriangle += " прямоугольный";
                }
                else if (Math.Pow(c, 2) < Math.Pow(a, 2) + Math.Pow(b, 2))
                {
                    typeTriangle += " остроугольный";
                }
            }
            else
            {
                if (a == b && a != c && b != c)
                {
                    typeTriangle += " равнобедренный";
                }
                else if (a == b && a == c)
                {
                    typeTriangle += " равносторонний";
                }
                else if (a != b && a != c)
                {
                    typeTriangle += " разносторонний";
                }
            }           
            return typeTriangle;
        }

        public Triangle()
        {
            _a = 1;
            _b = 2;
            _c = 3;
        }
        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
    }
}
