namespace MobilePhoneComponents
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class Battery
    {
        #region Constructors
        public Battery()
        {
        }

        public Battery(string model, int? hoursIdle = null, int? hoursTalk = null, BatteryTypes type = BatteryTypes.NiMH)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.Type = type;
        }
        #endregion

        #region Properties
        public string Model { get; set; }

        public int? HoursIdle { get; set; }

        public int? HoursTalk { get; set; }

        public BatteryTypes Type { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Model:".PadLeft(15) + string.Format("{0, 15}", this.Model));
            sb.AppendLine("HoursIdle:".PadLeft(15) + string.Format("{0, 15}", this.HoursIdle));
            sb.AppendLine("HoursTalk:".PadLeft(15) + string.Format("{0, 15}", this.HoursTalk));
            sb.AppendLine("Type:".PadLeft(15) + string.Format("{0, 15}", this.Type));

            return sb.ToString();
        }
        #endregion
    }
}
