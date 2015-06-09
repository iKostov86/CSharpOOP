namespace Infestation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }

        protected override UnitInfo GetOptimalAttackableUnit(IEnumerable<UnitInfo> attackableUnits)
        {
            var optimalAttackableUnit = new UnitInfo(null, UnitClassification.Unknown, 0, int.MaxValue, 0);

            optimalAttackableUnit = attackableUnits
                .OrderByDescending(y => y.Health)
                .FirstOrDefault();

            return optimalAttackableUnit;
        }

        protected override bool CanAttackUnit(UnitInfo unit)
        {
            bool attackUnit = false;

            if (this.Id != unit.Id)
            {
                if (this.Aggression >= unit.Power)
                {
                    attackUnit = true;
                }
            }

            return attackUnit;
        }
    }
}