namespace WarMachines.Machines
{
    using System;
    using System.Text;

    using WarMachines.Interfaces;

    public class Tank : Machine, ITank, IMachine
    {
        private const double InitialHealthPoint = 100;
        private const double DefModeChangeAttackPoints = 40;
        private const double DefModeChangeDefencePoints = 30;

        private bool defenceMode;

        public Tank(string name, double attackPoints, double defencePoints)
            : base(name, InitialHealthPoint, attackPoints, defencePoints)
        {
            this.DefenseMode = false;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode
        {
            get { return this.defenceMode; }
            private set { this.defenceMode = value; }
        }

        public void ToggleDefenseMode()
        {
            this.DefenseMode = this.DefenseMode ? false : true;

            if (this.DefenseMode)
            {
                this.AttackPoints -= DefModeChangeAttackPoints;
                this.DefensePoints += DefModeChangeDefencePoints;
            }
            else
            {
                this.AttackPoints += DefModeChangeAttackPoints;
                this.DefensePoints -= DefModeChangeDefencePoints;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format(" *Defense: {0}", this.DefenseMode ? "ON" : "OFF"));

            return base.ToString() + sb.ToString();
        }
    }
}
