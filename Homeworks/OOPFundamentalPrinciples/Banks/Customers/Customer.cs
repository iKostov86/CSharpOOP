namespace Banks
{
    public abstract class Customer
    {
        #region Fields
        private string fullName;
        #endregion

        #region Properties
        public string FullName
        {
            get { return this.fullName; }
            set { this.fullName = value; }
        }
        #endregion
    }
}
