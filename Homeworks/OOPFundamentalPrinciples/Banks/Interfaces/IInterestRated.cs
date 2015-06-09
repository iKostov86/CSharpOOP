namespace Banks
{
    public interface IInterestRated
    {
        decimal InterestRate { get; }
        
        decimal CalculateInterestRateMonthly(int month);
    }
}
