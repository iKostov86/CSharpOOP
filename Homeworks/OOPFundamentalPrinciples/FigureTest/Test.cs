using System;
using Figures;

public class Test
{
    private static void Main()
    {
        Shape[] myShape =
        {
            new Triangle(5, 4),
            new Rectangle(10, 3),
            new Circle(5),
        };

        foreach (Shape shape in myShape)
        {
            Console.WriteLine(shape.CalculateSurface());
        }
    }
}
