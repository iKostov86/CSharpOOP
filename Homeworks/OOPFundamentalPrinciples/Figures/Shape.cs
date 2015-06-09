namespace Figures
{
    using System;

    public abstract class Shape
    {
        #region Fields
        private double height;
        private double width;
        #endregion

        #region Constructors
        public Shape()
        {
        }

        public Shape(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }
        #endregion

        #region Properties
        public double Height
        {
            get
            {
                return this.height;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Height can't be negative!");
                }

                this.height = value;
            }
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Width can't be negative!");
                }

                this.width = value; 
            }
        }
        #endregion

        #region Methods
        public abstract double CalculateSurface();
        #endregion
    }
}
