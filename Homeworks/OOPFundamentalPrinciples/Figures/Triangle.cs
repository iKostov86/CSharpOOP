namespace Figures
{
    public class Triangle : Shape
    {
        #region Constructors
        public Triangle()
            : base()
        {
        }

        public Triangle(double height,  double size)
            : base(height, size)
        {
        }
        #endregion
        
        #region Methods
        public override double CalculateSurface()
        {
            return (this.Height * this.Width) / 2;
        }
        #endregion
    }
}
