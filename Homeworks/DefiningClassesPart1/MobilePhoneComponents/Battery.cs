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

        public Battery(string batteryModel, int? hoursIdle = null, int? hoursTalk = null, BatteryTypes batteryType = BatteryTypes.NiMH)
        {
            this.BatteryModel = batteryModel;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }
        #endregion

        #region Properties
        public string BatteryModel { get; set; }

        public int? HoursIdle { get; set; }

        public int? HoursTalk { get; set; }

        public BatteryTypes BatteryType { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BatteryModel:".PadLeft(15) + string.Format("{0, 15}", this.BatteryModel));
            sb.AppendLine("HoursIdle:".PadLeft(15) + string.Format("{0, 15}", this.HoursIdle));
            sb.AppendLine("HoursTalk:".PadLeft(15) + string.Format("{0, 15}", this.HoursTalk));
            sb.AppendLine("BatteryType:".PadLeft(15) + string.Format("{0, 15}", this.BatteryType));

            return sb.ToString();
        }
        #endregion
    }
}
