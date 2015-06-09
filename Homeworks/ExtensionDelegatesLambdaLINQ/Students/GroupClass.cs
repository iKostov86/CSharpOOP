namespace Students
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class GroupClass
    {
        #region Properties
        public string GroupNumber { get; set; }

        public string DepartmentName { get; set; }
        #endregion

        #region Methods
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var prop = this.GetType().GetProperties();

            foreach (var item in prop)
            {
                sb.Append(string.Format("{0}: {1} ", item.Name, item.GetValue(this)));
            }

            return sb.ToString();
        }
        #endregion
    }
}
