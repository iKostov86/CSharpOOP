namespace Infestation
{
    using System;

    public abstract class Catalyst : Supplement, ISupplement
    {
        public Catalyst(int healthEffect, int powerEffect, int aggressionEffect)
            : base(healthEffect, powerEffect, aggressionEffect)
        {
        }
    }
}
