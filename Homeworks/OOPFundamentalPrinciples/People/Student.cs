namespace People
{
    public class Student : Human
    {
        #region Fields
        private int grade;
        #endregion

        #region Ctor
        public Student()
            : base()
        {
        }

        public Student(string firstName, string lastName, int grade)
            : base(firstName, lastName)
        {
            this.Grade = grade;
        }
        #endregion

        #region Prop
        public int Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return base.ToString() + string.Format(" {0}", this.Grade);
        }
        #endregion
    }
}
