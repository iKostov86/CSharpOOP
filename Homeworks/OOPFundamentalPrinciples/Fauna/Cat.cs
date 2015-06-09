namespace Fauna
{
    using System;

    public class Cat : Animal
    {
        #region Ctor
        public Cat()
            : base()
        {
        }

        public Cat(int age, string name, Gender sex)
            : base(age, name, sex)
        {
        }
        #endregion
        #region Methods
        public override void MakeSound()
        {
            Console.WriteLine("Miau");
        }
        #endregion
    }
}
