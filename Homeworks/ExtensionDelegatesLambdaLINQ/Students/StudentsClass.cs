namespace Students
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class StudentsClass
    {
        #region Fields
        private string firstName;
        private string lastName;
        private string facNumber;
        private string tel;
        private string email;
        private MarksClass marks;
        private GroupClass group;
        #endregion

        #region Constructors
        public StudentsClass()
        {
            this.Marks = new MarksClass();
            this.Group = new GroupClass();
        }

        public StudentsClass(string firstName, string lastName, string facNumber, string tel = null, string email = null, MarksClass marks = null, GroupClass group = null)
            : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.FacNumber = facNumber;
            this.Tel = tel;
            this.Email = email;
            this.Marks = marks;
            this.Group = group;
        }
        #endregion

        #region Properties
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        public string FacNumber
        {
            get { return this.facNumber; }
            set { this.facNumber = value; }
        }

        public string Tel
        {
            get { return this.tel; }
            set { this.tel = value; }
        }

        public string Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        public MarksClass Marks
        {
            get { return this.marks; }
            set { this.marks = value; }
        }

        public GroupClass Group
        {
            get { return this.group; }
            set { this.group = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var prop = this.GetType().GetProperties();

            foreach (var item in prop)
            {
                if (item.GetValue(this) != null)
                {
                    sb.AppendLine(item.Name.PadLeft(12) + ": " + item.GetValue(this).ToString().PadRight(10));
                }
            }

            return sb.ToString();
        }
        #endregion

        public class Neshto : List<int>
        {

        }
    }
}
