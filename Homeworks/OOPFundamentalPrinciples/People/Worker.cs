namespace People
{
    public class Worker : Human
    {
        #region Fields
        private int weekSalary;
        private int workHoursPerDay;
        #endregion

        #region Ctor
        public Worker()
            : base()
        {
        }

        public Worker(string firstName, string lastName, int weekSalary, int workHoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.WorkHoursPerDay = workHoursPerDay;
        }
        #endregion

        #region Prop
        public int WeekSalary
        {
            get { return this.weekSalary; }
            set { this.weekSalary = value; }
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set { this.workHoursPerDay = value; }
        }
        #endregion

        #region Methods
        public decimal MoneyPerHour()
        {
            return (decimal)this.WeekSalary / 7 / this.WorkHoursPerDay;
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" {0:F2} $", this.MoneyPerHour());
        }
        #endregion
    }
}
