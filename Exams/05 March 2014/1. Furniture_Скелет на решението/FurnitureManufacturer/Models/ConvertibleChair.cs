namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using Interfaces;

    public class ConvertibleChair : Chair, IConvertibleChair, IChair, IFurniture
    {
        private const decimal ConvertedHeight = 0.10m;

        private bool isConverted;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
            this.IsConverted = false;
        }
        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }
            private set
            {
                this.isConverted = value;
            }
        }

        public override decimal Height
        {
            get
            {
                if (this.IsConverted)
                {
                    return ConvertedHeight;
                }

                return base.Height;
            }
            protected set
            {
                base.Height = value;
            }
        }

        public void Convert()
        {
            this.IsConverted = !this.IsConverted;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
                string.Format(
                    ", State: {0}",
                    this.IsConverted ?
                        "Converted" :
                        "Normal"));

            return base.ToString() + sb.ToString();
        }
    }
}
