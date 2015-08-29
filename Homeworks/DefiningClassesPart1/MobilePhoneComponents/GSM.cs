namespace MobilePhoneComponents
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class GSM
    {
        #region Fields
        private const decimal PricePerMinute = 0.37m;
        private static readonly GSM iPhone4S;
        private string model;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory;
        #endregion

        #region Constructors
        static GSM()
        {
            iPhone4S = new GSM("iPhone 4S", "Apple", 1000.0m, "Not me", new Battery(), new Display());
        }

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
            this.CallHistory = new List<Call>();
        }
        #endregion

        #region Properties
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model field can't be empthy!");
                }
                else
                {
                    this.model = value;
                }
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The manufacturer field can't be empthy!");
                }
                else
                {
                    this.manufacturer = value;
                }
            }
        }

        public decimal? Price
        {
            get
            {
                if (this.price == null)
                {
                    throw new NullReferenceException("The price can't be found!");
                }

                return this.price;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The price can't be negative!");
                }
                else
                {
                    this.price = value;
                }
            }
        }

        public string Owner
        {
            get
            {
                if (this.owner == null)
                {
                    throw new NullReferenceException("The owner can't be found!");
                }

                return this.owner;
            }

            private set
            {
                this.owner = value;
            }
        }

        public Battery Battery
        {
            get
            {
                if (this.battery == null)
                {
                    throw new NullReferenceException("The battery can't be found!");
                }

                return this.battery;
            }

            private set
            {
                this.battery = value;
            }
        }

        public Display Display
        {
            get
            {
                if (this.display == null)
                {
                    throw new NullReferenceException("The display can't be found!");
                }

                return this.display;
            }

            private set
            {
                this.display = value;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return new List<Call>(this.callHistory);
            }

            private set
            {
                this.callHistory = value;
            }
        }
        #endregion

        #region Methods
        public void AddCall(Call call)
        {
            this.callHistory.Add(call);
        }

        public void DeleteCall(Call call)
        {
            this.callHistory.Remove(call);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public decimal CalculateTotalCost()
        {
            uint totalDuration = 0;

            foreach (Call call in this.callHistory)
            {
                totalDuration += (uint)call.Duration;
            }

            return PricePerMinute * (totalDuration / 60m);
        }

        public GSM ShallowCopy()
        {
            return (GSM)this.MemberwiseClone();
        }

        public GSM DeepCopy()
        {
            return new GSM(this.Model, this.manufacturer, this.Price, this.Owner,
                new Battery(this.Battery.Model, this.Battery.HoursIdle, this.Battery.HoursTalk, this.Battery.Type),
                new Display(this.Display.Size, this.Display.NumberOfColors));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string currencySign = string.Empty;

            if (this.Price != null)
            {
                currencySign = "$";
            }

            sb.AppendLine("/GSM specifications/".PadLeft(30));
            sb.AppendLine("Model:".PadLeft(15) + string.Format("{0, 15}", this.Model));
            sb.AppendLine("Manufacturer:".PadLeft(15) + string.Format("{0, 15}", this.Manufacturer));

            if (this.Price != null)
            {
                sb.AppendLine("Price:".PadLeft(15) + string.Format("{0, 14}{1}", this.Price, currencySign));
            }

            if (this.Owner != null)
            {
                sb.AppendLine("Owner:".PadLeft(15) + string.Format("{0, 15}", this.Owner) + Environment.NewLine);
            }

            if (this.Battery != null)
            {
                sb.AppendLine("/Battery/".PadLeft(30) + Environment.NewLine + string.Format("{0, 15}", this.Battery));
            }

            if (this.Display != null)
            {
                sb.AppendLine("/Display/".PadLeft(30) + Environment.NewLine + string.Format("{0, 15}", this.Display));
            }

            return sb.ToString();
        }
        #endregion
    }
}
