namespace Infestation
{
    using System;

    public abstract class Supplement : ISupplement
    {
        private int healthEffect;
        private int powerEffect;
        private int aggressionEffect;

        public Supplement(
            int healthEffect, int powerEffect, int aggressionEffect)
        {
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
            this.AggressionEffect = aggressionEffect;
        }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }

        public virtual int HealthEffect
        {
            get
            {
                return this.healthEffect;
            }
            protected set
            {
                this.healthEffect = value;
            }
        }

        public virtual int PowerEffect
        {
            get
            {
                return this.powerEffect;
            }
            protected set
            {
                this.powerEffect = value;
            }
        }

        public virtual int AggressionEffect
        {
            get
            {
                return this.aggressionEffect;
            }
            protected set
            {
                this.aggressionEffect = value;
            }
        }
    }
}
