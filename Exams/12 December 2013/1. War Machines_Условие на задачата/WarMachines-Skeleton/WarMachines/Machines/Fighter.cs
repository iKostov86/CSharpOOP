namespace WarMachines.Machines
{
    using System;
    using System.Text;

    using WarMachines.Interfaces;

    public class Fighter : Machine, IFighter
    {
        private const double InitialHealthPoint = 200;

        private bool stealthMode;

        public Fighter(string name, double attackPoints, double defencePoints, bool stealthMode)
            : base(name, InitialHealthPoint, attackPoints, defencePoints)
        {
            this.StealthMode = stealthMode;
        }

        public bool StealthMode
        {
            get { return this.stealthMode; }
            private set { this.stealthMode = value; }
        }

        public void ToggleStealthMode()
        {
            this.StealthMode = this.StealthMode ? false : true;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));

            return base.ToString() + sb.ToString();
        }
    }
}
