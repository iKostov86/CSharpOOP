namespace Exceptions
{
    using System;

    public class InvalidRangeException<T> : ApplicationException
    {
        #region Fields
        private T start;
        private T end;
        #endregion

        #region Ctor
        public InvalidRangeException()
            : base()
        {
        }

        public InvalidRangeException(T start, T end)
        {
            this.Start = start;
            this.End = end;
        }
        #endregion

        #region Prop
        public T Start
        {
            get { return this.start; }
            private set { this.start = value; }
        }

        public T End
        {
            get { return this.end; }
            private set { this.end = value; }
        }

        public override string Message
        {
            get
            {
                return string.Format(
                    "{0} is out of the allowed range [{1}, {2}]",
                    typeof(T).Name,
                    this.Start,
                    this.End);
            }
        }
        #endregion
    }
}
