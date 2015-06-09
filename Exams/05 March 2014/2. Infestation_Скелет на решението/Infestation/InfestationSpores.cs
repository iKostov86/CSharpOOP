namespace Infestation
{
    using System;

    public class InfestationSpores : EffectableSupplement, ISupplement
    {
        private const int InfestationSporesHealthBonus = 0;
        private const int InfestationSporesPowerBonus = -1;
        private const int InfestationSporesAggressionBonus = 20;

        public InfestationSpores()
            : base(
            InfestationSporesHealthBonus,
            InfestationSporesPowerBonus,
            InfestationSporesAggressionBonus)
        {
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.hasEffect = false;
            }
        }
    }
}