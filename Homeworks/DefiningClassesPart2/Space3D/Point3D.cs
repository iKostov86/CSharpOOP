namespace Space3D
{
    using System;

    public struct Point3D
    {
        #region Fields
        private static readonly Point3D entryPoint;
        #endregion

        #region Constructors
        static Point3D()
        {
            entryPoint = new Point3D(0, 0, 0);
        }

        public Point3D(decimal x, decimal y, decimal z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        #endregion

        #region Properties
        public static Point3D EntryPoint
        {
            get
            {
                return entryPoint;
            }
        }

        public decimal X { get; set; }

        public decimal Y { get; set; }

        public decimal Z { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("p({0}, {1}, {2})", this.X, this.Y, this.Z);
        }
        #endregion
    }
}