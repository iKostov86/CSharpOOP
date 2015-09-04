namespace ProgramsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Space3D;

    public class Space3DTest
    {
        internal static void Main()
        {
            Console.WriteLine("This is entry point:\n{0}", Point3D.EntryPoint);

            Point3D pointA = new Point3D(1m, 3m, -5m);
            Point3D pointB = new Point3D(-9m, 4m, 5m);

            decimal distance = CalculateDistance.CalculateDistanceBetweenTwoPoints(pointA, pointB);

            Console.WriteLine("The distance is:\n{0}", distance);

            // using HashSet for prevent save the same points
            HashSet<Point3D> hashSetPoints = new HashSet<Point3D> { pointA, pointB, pointA };

            Console.WriteLine("The number of hash set members:\n{0}", hashSetPoints.Count);

            Path myPath = new Path(hashSetPoints);

            Console.WriteLine("This is my path:\n{0}", myPath);

            myPath.AddPoint(pointA);
            myPath.AddPoint(pointB);

            string text = "text.txt";

            PathStorage.SavePath(myPath, text);
            myPath.ClearPoints();

            myPath = PathStorage.LoadPath(text);

            Console.WriteLine("The points of path:\n{0}", myPath);
        }
    }
}
