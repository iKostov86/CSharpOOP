namespace ProgramTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Point3DSpace;

    public class Point3DSPaceTest
    {
        internal static void Main()
        {
            Console.WriteLine(Point3D.StartPoint);
            Point3D pointA = new Point3D(1m, 3m, -5m);
            Point3D pointB = new Point3D(-9m, 4m, 5m);
            decimal distance = CalculateDistance.CalculateDistanceBetweenTwoPoints(pointA, pointB);
            Console.WriteLine(distance);

            HashSet<Point3D> myPoint = new HashSet<Point3D> { pointA, pointB };
            Path myPath = new Path(myPoint);
            Console.WriteLine(myPath);
            myPath.AddPoint(pointA);
            myPath.AddPoint(pointB);
            string text = "text.txt";

            PathStorage.SavePath(myPath, text);
            myPath.ClearPoints();

            myPath = PathStorage.LoadPath(text);
            Console.WriteLine(myPath);
        }
    }
}