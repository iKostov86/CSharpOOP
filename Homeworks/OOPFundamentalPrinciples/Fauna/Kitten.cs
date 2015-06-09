namespace Fauna
{
    public class Kitten : Cat
    {
        #region Ctor
        public Kitten()
            : base()
        {
        }

        public Kitten(int age, string name)
            : base(age, name, Gender.female)
        {
        }
        #endregion
    }
}
