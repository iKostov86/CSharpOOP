namespace Schools
{
    using System;
    using System.Collections.Generic;

    public class Class : IComment
    {
        #region Fields
        private HashSet<Teacher> teachers;
        private string textIdentifier;
        #endregion

        #region Properties
        public HashSet<Teacher> Teachers
        {
            get { return this.teachers; }
            set { this.teachers = value; }
        }

        public string TextIdentifier
        {
            get { return this.textIdentifier; }
            set { this.textIdentifier = value; }
        }

        public string Comment { get; set; }
        #endregion
    }
}
