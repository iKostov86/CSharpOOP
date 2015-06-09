namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Grez : Unit
    {
        public Grez(
            string id, UnitClassification unitType, int health, int power, int aggression)
            : base(id,
            unitType,
            health,
            power,
            aggression)
        {
        }

        public override Interaction DecideInteraction(IEnumerable<UnitInfo> units)
        {
            IEnumerable<UnitInfo> attackableUnits = units.Where((unit) => this.CanAttackUnit(unit));

            UnitInfo optimalAttackableUnit = GetOptimalAttackableUnit(attackableUnits);

            if (optimalAttackableUnit.Id != null)
            {
                return new Interaction(new UnitInfo(this), optimalAttackableUnit, InteractionType.Infest);
            }

            return Interaction.PassiveInteraction;
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            optimalAttackableUnit = attackableUnits
                .OrderBy(y => y.Health)
                .FirstOrDefault();

            return optimalAttackableUnit;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            if (this.Id != unit.Id &&
                InfestationRequirements.RequiredClassificationToInfest(unit.UnitClassification) == this.UnitClassification)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}