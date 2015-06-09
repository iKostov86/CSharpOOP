namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MarksClass
    {
        #region Fields
        private List<int> marksList;
        #endregion

        #region Properties
        public List<int> MarksList
        {
            get { return this.marksList; }
            set { this.marksList = value; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return string.Join(", ", this.MarksList);
        }
        #endregion
    }
}
