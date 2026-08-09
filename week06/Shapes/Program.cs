using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("red", 4);
        Console.WriteLine($"Square color: {square.GetColor()}, area: {square.GetArea()}");

        Rectangle rectangle = new Rectangle("blue", 5, 3);
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");

        Circle circle = new Circle("green", 2);
        Console.WriteLine($"Circle color: {circle.GetColor()}, area: {circle.GetArea()}");

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        Console.WriteLine();
        Console.WriteLine("All shapes in the list:");
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"Color: {shape.GetColor()}, Area: {shape.GetArea()}");
        }
    }
}
