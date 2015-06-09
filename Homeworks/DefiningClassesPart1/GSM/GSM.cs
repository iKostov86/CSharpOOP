namespace GSM
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
        private string gsmModel;
        private string manufacturer;
        private decimal? price;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;
        private List<Call> callHistory;
        #endregion

        #region Constructors
        static GSM()
        {
            iPhone4S = new GSM("iPhone 4S", "Apple", 1000.0m, "Not me", new Battery(), new Display());
        }

        public GSM()
        {
            this.CallHistory = new List<Call>();
        }

        public GSM(string gsmModel, string manufacturer)
            : this()
        {
            this.GsmModel = gsmModel;
            this.Manufacturer = manufacturer;
        }

        public GSM(string gsmModel, string manufacturer, decimal? price, string owner)
            : this(gsmModel, manufacturer)
        {
            this.Price = price;
            this.Owner = owner;
        }

        public GSM(string gsmModel, string manufacturer, decimal? price, string owner, Battery gsmBattery, Display gsmDisplay)
            : this(gsmModel, manufacturer, price, owner)
        {
            this.GsmBattery = gsmBattery;
            this.GsmDisplay = gsmDisplay;
        }
        #endregion

        #region Properties
        public static GSM IPhone4S
        {
            get { return iPhone4S; }
        }

        public string GsmModel
        {
            get
            {
                return this.gsmModel;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The model field can't be empthy!");
                }
                else
                {
                    this.gsmModel = value;
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
                return this.price;
            }

            private set
            {
                if (value < 0 || value == null)
                {
                    throw new ArgumentOutOfRangeException("The price can't be negative or empthy!");
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
                return this.owner;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The owner field can't be empthy!");
                }
                else
                {
                    this.owner = value;
                }
            }
        }

        public Battery GsmBattery
        {
            get
            {
                return this.gsmBattery;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The battery info can't be empthy!");
                }

                this.gsmBattery = value;
            }
        }

        public Display GsmDisplay
        {
            get
            {
                return this.gsmDisplay;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The display info can't be empthy!");
                }

                this.gsmDisplay = value;
            }
        }

        public List<Call> CallHistory
        {
            ////get { return this.callHistory; }
            get { return new List<Call>(this.callHistory); }
            private set { this.callHistory = value; }
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
            ulong totalDuration = 0;
            foreach (Call call in this.callHistory)
            {
                totalDuration += (ulong)call.Duration;
            }

            return PricePerMinute * ((decimal)totalDuration / 60);
        }

        public GSM ShallowCopy()
        {
            return (GSM)this.MemberwiseClone();
        }

        public GSM DeepCopy()
        {
            return new GSM(this.GsmModel, this.manufacturer, this.Price, this.Owner, this.GsmBattery, this.GsmDisplay);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Model:".PadLeft(15) + string.Format("{0, 15}", this.GsmModel));
            sb.AppendLine("Manufacturer:".PadLeft(15) + string.Format("{0, 15}", this.Manufacturer));
            sb.AppendLine("Price:".PadLeft(15) + string.Format("{0, 14}$", this.Price));
            sb.AppendLine("Owner:".PadLeft(15) + string.Format("{0, 15}", this.Owner));
            sb.AppendLine("GsmBattery:".PadLeft(15) + Environment.NewLine + string.Format("{0, 15}", this.GsmBattery));
            sb.AppendLine("GsmDisplay:".PadLeft(15) + Environment.NewLine + string.Format("{0, 15}", this.GsmDisplay));

            return sb.ToString();
        }
        #endregion
    }
}
