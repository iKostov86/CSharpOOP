namespace PersonHierarchy
{
    using System;
    using System.Text;

    public class Person
    {
        #region Props
        public string Name { get; set; }

        public int? Age { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Format(
                "{0}, {1}",
                this.Name,
                this.Age == null ? "Age isn't specified!" : this.Age.ToString());
        }
        #endregion
    }
}
