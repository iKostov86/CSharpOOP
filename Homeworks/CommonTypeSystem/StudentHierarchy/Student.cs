namespace StudentHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    [Serializable]
    public class Student : ICloneable, IComparable<Student>
    {
        #region Fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private string course;
        private Specialties specialty;
        private Universities university;
        private Faculties faculty;
        #endregion

        #region Ctor
        public Student(
            string firstName = null,
            string middleName = null,
            string lastName = null,
            string ssn = null,
            string permanentAddress = null,
            string mobilePhone = null,
            string email = null,
            string course = null,
            Specialties specialty = Specialties.None,
            Universities university = Universities.None,
            Faculties faculty = Faculties.None)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }
        #endregion

        #region Prop
        public string FirstName
        {
            get { return this.firstName; }
            private set { this.firstName = value; }
        }

        public string MiddleName
        {
            get { return this.middleName; }
            private set { this.middleName = value; }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set { this.lastName = value; }
        }

        public string SSN
        {
            get { return this.ssn; }
            private set { this.ssn = value; }
        }

        public string PermanentAddress
        {
            get { return this.permanentAddress; }
            private set { this.permanentAddress = value; }
        }

        public string MobilePhone
        {
            get { return this.mobilePhone; }
            private set { this.mobilePhone = value; }
        }

        public string Email
        {
            get { return this.email; }
            private set { this.email = value; }
        }

        public string Course
        {
            get { return this.course; }
            private set { this.course = value; }
        }

        public Specialties Specialty
        {
            get { return this.specialty; }
            private set { this.specialty = value; }
        }

        public Universities University
        {
            get { return this.university; }
            private set { this.university = value; }
        }

        public Faculties Faculty
        {
            get { return this.faculty; }
            private set { this.faculty = value; }
        }
        #endregion

        #region Methods
        public static bool operator ==(Student firstStudent, Student secondStudent)
        {
            return Student.Equals(firstStudent, secondStudent);
        }

        public static bool operator !=(Student firstStudent, Student secondStudent)
        {
            return !Student.Equals(firstStudent, secondStudent);
        }

        public override bool Equals(object obj)
        {
            Student studentObj = obj as Student;

            if (studentObj == null)
            {
                return false;
            }

            Type thisType = this.GetType();
            var thisTypeProps = thisType.GetProperties();

            Type studentObjType = studentObj.GetType();
            var studentObjTypeProps = studentObjType.GetProperties();

            var thisAndObjZip = thisTypeProps.Zip(studentObjTypeProps, (t, o) => new { This = t, StudentObj = o });

            foreach (var member in thisAndObjZip)
            {
                if (thisType.GetProperty(member.This.Name).GetValue(this, null) == null &&
                    studentObjType.GetProperty(member.StudentObj.Name).GetValue(studentObj, null) == null)
                {
                }
                else if (member.This.GetValue(this).ToString() != member.StudentObj.GetValue(studentObj).ToString())
                {
                    return false;
                }
                ////else if (thisType.GetProperty(member.This.Name).GetValue(this, null).ToString() !=
                ////    studentObjType.GetProperty(member.StudentObj.Name).GetValue(studentObj, null).ToString())
            }

            return true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var thisTypeProps = this.GetType().GetProperties();

            foreach (var prop in thisTypeProps)
            {
                sb.AppendLine(prop.Name + " " + prop.GetValue(this));
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var thisProps = this.GetType().GetProperties();

            int hashCode = this.GetType().Name.GetHashCode();

            foreach (PropertyInfo prop in thisProps)
            {
                if (prop.GetValue(this) != null)
                {
                    hashCode ^= prop.GetValue(this).GetHashCode();
                }
            }

            return hashCode;
        }

        public object Clone()
        {
            object clonedStudent = new object();

            if (object.ReferenceEquals(this, null) || !this.GetType().IsSerializable)
            {
                return clonedStudent;
            }

            IFormatter formatter = new BinaryFormatter();

            using (Stream ms = new MemoryStream())
            {
                formatter.Serialize(ms, this);
                ms.Position = 0;
                clonedStudent = formatter.Deserialize(ms);
            }

            return clonedStudent;
        }

        public int CompareTo(Student other)
        {
            int comparison =
                (this.FirstName + this.MiddleName + this.LastName)
                .CompareTo(other.FirstName + other.MiddleName + other.LastName);

            if (comparison == 0)
            {
                return this.SSN.CompareTo(other.SSN);
            }

            return comparison;
        }
        #endregion
    }
}
