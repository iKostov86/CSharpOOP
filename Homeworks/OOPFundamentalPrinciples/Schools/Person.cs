namespace Schools
{
    using System;

    public class Person
    {
        #region Fields
        private string name;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        #endregion
    }
}
