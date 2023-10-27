// See https://aka.ms/new-console-template for more information

using GeometryLibrary;

Triangle triangle = new Triangle();
double a = triangle.C = 5;
double b= triangle.A = 12;
double c = triangle.B = 13;

triangle.validTriangle(a,b,c);
Console.WriteLine(triangle.typeTriangle(a, b, c));

