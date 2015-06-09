namespace Infestation
{
    using System;

    public class Weapon : EffectableSupplement, ISupplement
    {
        private const int WeaponHealthBonus = 0;
        private const int WeaponPowerBonus = 10;
        private const int WeaponAggressionBonus = 3;

        public Weapon()
            : base(
            WeaponHealthBonus,
            WeaponPowerBonus,
            WeaponAggressionBonus)
        {
            this.hasEffect = false;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.hasEffect = true;
            }
        }
    }
}
