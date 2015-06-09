namespace GSM
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class Call
    {
        #region Fields
        private DateTime dateTime;
        private string dialedNumber;
        private uint? duration;
        #endregion

        #region Constructors
        public Call(string dialedNumber = null, uint? duration = null)
        {
            this.dateTime = DateTime.Now;
            this.DialedNumber = dialedNumber;
            this.Duration = duration;
        }
        #endregion

        #region Properties
        public string Date
        {
            get { return this.dateTime.ToShortDateString(); }
        }

        public string Time
        {
            get { return this.dateTime.ToShortTimeString(); }
        }

        public string DialedNumber
        {
            get { return this.dialedNumber; }
            set { this.dialedNumber = value; }
        }

        public uint? Duration
        {
            get { return this.duration; }
            set { this.duration = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(string.Format("Dialed phone number: {0}", this.DialedNumber));
            sb.AppendLine(string.Format("Duration: {0}s", this.Duration));
            sb.AppendLine(string.Format("Date: {0}", this.Date));
            sb.AppendLine(string.Format("Time: {0}", this.Time));

            return sb.ToString();
        }
        #endregion
    }
}
