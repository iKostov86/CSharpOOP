namespace FurnitureManufacturer.Models
{
    using System;
    using System.Text;

    using Interfaces;
    using Common;

    public abstract class Furniture : IFurniture
    {
        private string model;
        private string material;
        private decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                value.ChekStringIfNullOrEmpthy();
                value.ChekStringIfWithLessThanXSymbols(3);
                this.model = value;
            }
        }

        public string Material
        {
            get
            {
                return this.material;
            }
            private set
            {
                this.material = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                value.ChekValueIfLessThanXOrEqual<decimal>(0m);
                this.price = value;
            }
        }

        public virtual decimal Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                value.ChekValueIfLessThanXOrEqual<decimal>(0m);
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(
                string.Format(
                    "Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}",
                    this.GetType().Name,
                    this.Model,
                    this.Material,
                    this.Price,
                    this.Height));

            return sb.ToString();
        }
    }
}
