namespace Schools
{
    using System;

    public class Discipline : IComment
    {
        #region Fields
        private string name;
        private int numberOfLectures;
        private int numberOfExercises;
        #endregion

        #region Properties
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public int NumberOfLectures
        {
            get { return this.numberOfLectures; }
            set { this.numberOfLectures = value; }
        }

        public int NumberOfExercises
        {
            get { return this.numberOfExercises; }
            set { this.numberOfExercises = value; }
        }

        public string Comment { get; set; }
        #endregion
    }
}
