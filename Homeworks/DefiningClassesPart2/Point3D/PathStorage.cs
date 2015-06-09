namespace Point3DSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class PathStorage
    {
        #region Methods
        public static void SavePath(Path path, string filePath)
        {
            File.WriteAllText(filePath, path.ToString());
        }

        public static Path LoadPath(string filePath)
        {
            Path path = new Path();

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                decimal[] coordinates = line
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => decimal.Parse(s))
                    .ToArray();

                path.AddPoint(new Point3D(coordinates[0], coordinates[1], coordinates[2]));
            }

            return path;
        }
        #endregion
    }
}