namespace People
{
    using System;

    public abstract class Human
    {
        #region Fields
        private string firstName;
        private string lastName;
        #endregion

        #region Ctor
        public Human()
        {
        }

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        #endregion

        #region Prop
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format("{0} {1}", this.FirstName, this.LastName);
        }
        #endregion
    }
}
