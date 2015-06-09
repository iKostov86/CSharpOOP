namespace Figures
{
    using System;

    public class Circle : Shape
    {
        #region Constructor
        public Circle()
            : base()
        {
        }

        public Circle(double size)
            : base(size, size)
        {
        }
        #endregion

        #region Methods
        public override double CalculateSurface()
        {
            return Math.PI * this.Height * this.Width;
        }
        #endregion
    }
}
