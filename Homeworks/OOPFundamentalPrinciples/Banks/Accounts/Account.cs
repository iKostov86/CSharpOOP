namespace Banks
{
    public abstract class Account : IInterestRated
    {
        #region Fields
        private Customer client;
        private decimal balance;
        private decimal interestRate;
        #endregion

        #region Constructors
        public Account()
        {
        }

        public Account(Customer client, decimal balance, decimal interestRate)
        {
            this.Client = client;
            this.Balance = balance;
            this.InterestRate = interestRate;
        }
        #endregion

        #region Properties
        public Customer Client
        {
            get { return this.client; }
            set { this.client = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }

        public decimal InterestRate
        {
            get { return this.interestRate; }
            set { this.interestRate = value; }
        }
        #endregion

        #region Methods
        public virtual decimal CalculateInterestRateMonthly(int months)
        {
            return months * this.InterestRate;
        }
        #endregion
    }
}
