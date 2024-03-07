using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Square _sqaure = new Square("red", 5);
        Console.WriteLine(_sqaure.GetArea());
        Console.WriteLine(_sqaure.GetColor());

        Rectangle _rectangle = new Rectangle("Blue", 5, 10);
        Console.WriteLine(_rectangle.GetArea());
        Console.WriteLine(_rectangle.GetColor());

        Circle _circle = new Circle("Green", 5);
        Console.WriteLine(_circle.GetArea());
        Console.WriteLine(_circle.GetColor());

    }
}