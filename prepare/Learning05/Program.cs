using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> myShapes = new List<Shape>();
        Square square = new Square("red", 6.54);
        Rectangle rect = new Rectangle("blue", 43, 2.34);
        Circle circle = new Circle("White", Math.PI);
        myShapes.Add(square);
        myShapes.Add(rect);
        myShapes.Add(circle);

        foreach (Shape shape in myShapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
        }
    }
}