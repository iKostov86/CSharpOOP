namespace Fauna
{
    using System;
    using System.Linq;

    public abstract class Animal : ISound
    {
        #region Fields
        private int age;
        private string name;
        private Gender sex;
        #endregion

        #region Ctor
        public Animal()
        {
        }

        public Animal(int age, string name, Gender sex)
        {
            this.Age = age;
            this.Name = name;
            this.Sex = sex;
        }
        #endregion

        #region Prop
        public int Age
        {
            get { return this.age; }
            private set { this.age = value; }
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public Gender Sex
        {
            get { return this.sex; }
            private set { this.sex = value; }
        }
        #endregion

        #region Methods
        public static double AverageAge(Animal[] zoo)
        {
            return zoo.Average(x => x.Age);
        }

        public abstract void MakeSound();
        #endregion
    }
}
