namespace Figures
{
    public class Rectangle : Shape
    {
        #region Constructors
        public Rectangle()
            : base()
        {
        }

        public Rectangle(double height,  double width)
            : base(height, width)
        {
        }
        #endregion

        #region Methods
        public override double CalculateSurface()
        {
            return this.Height * this.Width;
        }
        #endregion
    }
}
