namespace Banks
{
    public class DepositAccount : Account, IDeposited, IDraw
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

        public void DrawMoney()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
