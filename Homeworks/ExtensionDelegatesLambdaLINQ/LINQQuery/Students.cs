namespace LINQQuery
{
    using System;

    public class Students
    {
        #region Properties
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string City { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format(this.FirstName + " / "
                                + this.LastName + " / " 
                                + this.Age + " / "
                                + this.City);
        }
        #endregion
    }
}
