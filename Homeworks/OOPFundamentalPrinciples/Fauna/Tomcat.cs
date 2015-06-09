namespace Fauna
{
    public class Tomcat : Cat
    {
        #region Ctor
        public Tomcat()
            : base()
        {
        }

        public Tomcat(int age, string name)
            : base(age, name, Gender.male)
        {
        }
        #endregion
    }
}
