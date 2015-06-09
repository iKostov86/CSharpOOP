namespace Timer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Windows.Forms;

    public delegate void TimerChangedEventHandler(object sender, TimerChangedEventArgs e);

    public class TimerClass
    {
        #region Constants
        private static readonly int MSeconds = 1000;
        #endregion

        #region Fields
        #endregion

        #region Constructors
        #endregion

        #region Events
        public event TimerChangedEventHandler TimerChanged;
        #endregion

        #region Properties
        #endregion

        #region Methods
        public void Run()
        {
            while (Console.ReadLine() == null)
            {
                TimerChangedEventArgs e = new TimerChangedEventArgs();
                e.TimeNow = DateTime.Now;
                this.OnTimerChanged(e);
                Thread.Sleep(MSeconds);
            }
        }

        protected virtual void OnTimerChanged(TimerChangedEventArgs e)
        {
            if (this.TimerChanged != null)
            {
                this.TimerChanged(this, e);
            }
        }
        #endregion
    }
}
