namespace Schools
{
    using System;
    using System.Collections.Generic;

    public class Teacher : Person, IComment
    {
        #region Fields
        private HashSet<Discipline> disciplines;
        #endregion

        #region Properties
        public HashSet<Discipline> Disciplines
        {
            get { return this.disciplines; }
            set { this.disciplines = value; }
        }

        public string Comment { get; set; }
        #endregion
    }
}
