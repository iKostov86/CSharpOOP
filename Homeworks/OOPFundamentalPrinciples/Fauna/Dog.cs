namespace Fauna
{
    using System;

    public class Dog : Animal
    {
        #region Ctor
        public Dog()
            : base()
        {
        }

        public Dog(int age, string name, Gender sex)
            : base(age, name, sex)
        {
        }
        #endregion

        #region Methods
        public override void MakeSound()
        {
            Console.WriteLine("Bau");
        }
        #endregion
    }
}
