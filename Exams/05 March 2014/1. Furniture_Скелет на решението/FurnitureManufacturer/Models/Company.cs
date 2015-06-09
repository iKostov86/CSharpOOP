namespace FurnitureManufacturer.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Interfaces;
    using Common;

    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;
        private ICollection<IFurniture> furnitures;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                value.ChekStringIfNullOrEmpthy();
                value.ChekStringIfWithLessThanXSymbols(5);
                this.name = value;
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }
            private set
            {
                value.ChekStringIfNullOrEmpthy();

                long number = new int();

                if (value.Length == 10 &&
                    long.TryParse(value, out number))
                {
                    this.registrationNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(
                        "Registration number can't be null, empthy, less than 10 symbols and must contain only digits!");
                }
            }
        }

        public ICollection<IFurniture> Furnitures
        {
            get
            {
                return this.furnitures;
            }
            private set
            {
                this.furnitures = value;
            }

        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            return this.Furnitures.FirstOrDefault(x => x.Model.ToLower() == model.ToLower());
        }

        public string Catalog()
        {
            StringBuilder sb = new StringBuilder();

            var sortedFurnitures =
                this.Furnitures
                .OrderBy(x => x.Price)
                .ThenBy(y => y.Model);

            var numberOfFurniture = 
                this.Furnitures.Count > 0 ?
                this.Furnitures.Count.ToString() :
                "no";

            var singularOrPluralFurniture =
                this.Furnitures.Count == 1 ?
                "furniture" :
                "furnitures";

            sb.AppendLine(
                string.Format(
                    "{0} - {1} - {2} {3}",
                    this.Name,
                    this.RegistrationNumber,
                    numberOfFurniture,
                    singularOrPluralFurniture));

            if (this.Furnitures.Count != 0)
            {
                foreach (var furniture in sortedFurnitures)
                {
                    sb.AppendLine(furniture.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
