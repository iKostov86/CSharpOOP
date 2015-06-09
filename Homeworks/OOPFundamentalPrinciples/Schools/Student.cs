namespace Schools
{
    using System;

    public class Student : Person, IComment
    {
        #region Fields
        private string classNumber;
        #endregion

        #region Properties
        public string ClassNumber
        {
            get { return this.classNumber; }
            set { this.classNumber = value; }
        }

        public string Comment { get; set; }
        #endregion
    }
}
