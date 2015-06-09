namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using Interfaces;

    class Table : Furniture, ITable, IFurniture
    {
        private decimal length;
        private decimal width;

        public Table(
            string model, string materialType, decimal price, decimal height, decimal length, decimal width)
            : base(model, materialType, price, height)
        {
            this.Length = length;
            this.Width = width;
        }

        public decimal Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.length = value;
            }
        }

        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.width = value;
            }
        }

        public decimal Area
        {
            get
            {
                return this.Length * this.Width;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
                string.Format(
                    ", Length: {0}, Width: {1}, Area: {2}",
                    this.Length,
                    this.Width,
                    this.Area));

            return base.ToString() + sb.ToString();
        }
    }
}
