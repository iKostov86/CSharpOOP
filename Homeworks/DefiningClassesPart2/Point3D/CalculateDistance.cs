namespace Point3DSpace
{
    using System;

    public static class CalculateDistance
    {
        public static decimal CalculateDistanceBetweenTwoPoints(Point3D a, Point3D b)
        {
            decimal firstAddend = (b.X - a.X) * (b.X - a.X);
            decimal secondAddend = (b.Y - a.Y) * (b.Y - a.Y);
            decimal thirdAddend = (b.Z - a.Z) * (b.Z - a.Z);

            decimal distance = (decimal)Math.Sqrt((double)(firstAddend + secondAddend + thirdAddend));

            return distance;
        }
    }
}