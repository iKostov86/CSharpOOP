namespace MobilePhoneComponents
{
    using System;
    using System.Text;
    using System.Threading.Tasks;

    public class Display
    {
        #region Constructors
        public Display()
        {
        }

        public Display(decimal? displaySize, int? numberOfColors)
        {
            this.DisplaySize = displaySize;
            this.NumberOfColors = numberOfColors;
        }
        #endregion

        #region Properties
        public decimal? DisplaySize { get; set; }

        public int? NumberOfColors { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("DisplaySize:".PadLeft(15) + string.Format("{0, 15}", this.DisplaySize));
            sb.AppendLine("NumberOfColors:".PadLeft(15) + string.Format("{0, 15}", this.NumberOfColors));
            return sb.ToString();
        }
        #endregion
    }
}
