namespace Timer
{
    using System;

    public class TimerChangedEventArgs : EventArgs
    {
        private DateTime timeNow;

        public DateTime TimeNow
        {
            get { return this.timeNow; }
            set { this.timeNow = value; }
        }
    }
}
