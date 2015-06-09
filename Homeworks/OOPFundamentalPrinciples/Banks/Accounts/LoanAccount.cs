namespace Banks
{
    public class LoanAccount : Account
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
