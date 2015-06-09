namespace WarMachines.Pilots
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using WarMachines.Interfaces;
    using WarMachines.Helpers;

    public class Pilot : IPilot
    {
        private string name;
        private IList<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                value.ChekStringIfNullOrEmpthy(GlobalConstants.NameIfNullErrorMsg);
                this.name = value;
            }
        }

        public void AddMachine(IMachine machine)
        {
            machine.ChekObjectIfNull();
            this.machines.Add(machine);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            var sortedMachines = this.machines
                .OrderBy(x => x.HealthPoints)
                .ThenBy(y => y.Name);

            var sortedMachinesCount = sortedMachines.Count() > 0 ? sortedMachines.Count().ToString() : "no";
            var singularOrPluralMachines = sortedMachines.Count() == 1 ? "machine" : "machines";

            sb.Append(
                string.Format(
                    "{0} - {1} {2}",
                    this.Name,
                    sortedMachinesCount,
                    singularOrPluralMachines));

            if (sortedMachinesCount != "no")
            {
                sb.AppendLine();

                foreach (var machine in sortedMachines)
                {
                    sb.Append(machine.ToString());
                }

                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
