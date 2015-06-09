namespace Fauna
{
    using System;

    public class Frog : Animal
    {
        #region Ctor
        public Frog()
            : base()
        {
        }

        public Frog(int age, string name, Gender sex)
            : base(age, name, sex)
        {
        }
        #endregion
        #region Methods
        public override void MakeSound()
        {
            Console.WriteLine("Croak");
        }
        #endregion
    }
}
