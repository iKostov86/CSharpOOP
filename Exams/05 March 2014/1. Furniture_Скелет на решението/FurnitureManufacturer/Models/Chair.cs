namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using Interfaces;

    public class Chair : Furniture, IChair
    {
        private int numberOfLegs;

        public Chair(
            string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height)
        {
            this.NumberOfLegs = numberOfLegs;
        }

        public int NumberOfLegs
        {
            get
            {
                return this.numberOfLegs;
            }
            private set
            {
                this.numberOfLegs = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
                string.Format(
                    ", Legs: {0}",
                    this.NumberOfLegs));

            return base.ToString() + sb.ToString();
        }
    }
}
