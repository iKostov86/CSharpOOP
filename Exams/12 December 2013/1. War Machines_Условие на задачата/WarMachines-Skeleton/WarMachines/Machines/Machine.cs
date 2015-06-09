namespace WarMachines.Machines
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;
    using WarMachines.Pilots;
    using WarMachines.Helpers;

    public abstract class Machine : IMachine
    {
        private string name;
        private double healthPoints;
        private double attackPoints;
        private double defensePoints;
        private IPilot pilot;
        private IList<string> targets;

        protected Machine(
            string name,
            double healthPoints,
            double attackPoints,
            double defensePoints)
        {
            this.Name = name;
            this.HealthPoints = healthPoints;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                value.ChekStringIfNullOrEmpthy(GlobalConstants.NameIfNullErrorMsg);
                this.name = value;
            }
        }

        public double HealthPoints
        {
            get
            {
                return this.healthPoints;
            }
            set
            {
                value.ChekValueForNegative("Health can't be negative!");
                this.healthPoints = value;
            }
        }

        public double AttackPoints
        {
            get { return this.attackPoints; }
            protected set { this.attackPoints = value; }
        }

        public double DefensePoints
        {
            get { return this.defensePoints; }
            protected set { this.defensePoints = value; }
        }

        public IPilot Pilot
        {
            get
            {
                return this.pilot;
            }
            set
            {
                value.ChekObjectIfNull("Pilot can't be null!");
                this.pilot = value;
            }
        }

        public IList<string> Targets
        {
            get
            {
                return this.targets;
            }
            private set
            {
                this.targets = value;
            }
        }

        public void Attack(string target)
        {
            target.ChekStringIfNullOrEmpthy("Target can't be null or empthy!");
            this.Targets.Add(target);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("- {0}", this.Name));
            sb.AppendLine(string.Format(" *Type: {0}", this.GetType().Name));
            sb.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            sb.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            sb.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));

            if (this.Targets.Count == 0)
            {
                sb.AppendLine(" *Targets: None");

            }
            else
            {
                sb.Append(" *Targets: ");
                sb.AppendLine(string.Join(", ", this.Targets));
            }

            return sb.ToString();
        }
    }
}
