namespace Space3D
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Path
    {
        #region Fields
        private ICollection<Point3D> points;
        #endregion

        #region Constructor
        public Path()
        {
            this.Points = new List<Point3D>();
        }

        public Path(ICollection<Point3D> points)
        {
            this.Points = points;
        }
        #endregion

        #region Properties
        public ICollection<Point3D> Points
        {
            get
            {
                return this.points;
            }
            private set
            {
                this.points = value;
            }
        }
        #endregion

        #region Methods
        public void AddPoint(Point3D point)
        {
            this.points.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.points.Remove(point);
        }

        public void ClearPoints()
        {
            this.points.Clear();
        }

        public override string ToString()
        {
            ////return string.Join(", ", this.points);

            StringBuilder sb = new StringBuilder();

            foreach (Point3D point in this.points)
            {
                sb.AppendLine(point.ToString());
            }

            return sb.ToString().TrimEnd();
        }
        #endregion
    }
}