namespace Infestation
{
    using System;

    public abstract class EffectableSupplement : Supplement, ISupplement
    {
        protected bool hasEffect;

        public EffectableSupplement(int healthEffect, int powerEffect, int aggressionEffect)
            : base(healthEffect, powerEffect, aggressionEffect)
        {
            this.hasEffect = true;
        }

        public override int HealthEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return base.HealthEffect;
                }
                else
                {
                    return 0;
                }
            }
            protected set
            {
                base.HealthEffect = value;
            }
        }

        public override int PowerEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return base.PowerEffect;
                }
                else
                {
                    return 0;
                }

            }
            protected set
            {
                base.PowerEffect = value;
            }
        }

        public override int AggressionEffect
        {
            get
            {
                if (this.hasEffect)
                {
                    return base.AggressionEffect;
                }
                else
                {
                    return 0;
                }
            }
            protected set
            {
                base.AggressionEffect = value;
            }
        }
    }
}