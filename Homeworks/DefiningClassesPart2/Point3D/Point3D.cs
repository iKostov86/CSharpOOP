namespace Point3DSpace
{
    using System;

    public struct Point3D
    {
        #region Fields
        private decimal x;
        private decimal y;
        private decimal z;
        #endregion

        #region Constructors
        public Point3D(decimal x, decimal y, decimal z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }
        #endregion

        #region Properties
        public static Point3D StartPoint { get; private set; }

        public decimal X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public decimal Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public decimal Z
        {
            get { return this.z; }
            set { this.z = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.X, this.Y, this.Z);
        }
        #endregion
    }
}