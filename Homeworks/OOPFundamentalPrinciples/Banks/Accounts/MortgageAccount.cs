namespace Banks.Accounts
{
    public class MortgageAccount : Account, IDeposited
    {
        #region Methods
        public override decimal CalculateInterestRateMonthly(int months)
        {
            return base.CalculateInterestRateMonthly(months);
        }

        public void DepositeMoney()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
