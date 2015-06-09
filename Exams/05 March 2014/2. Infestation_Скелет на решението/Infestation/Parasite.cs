namespace Infestation
{
    using System;

    public class Parasite : Grez
    {
        private const int ParasiteHealth = 1;
        private const int ParasitePower = 1;
        private const int ParasiteAggression = 1;

        public Parasite(string id)
            : base(
            id,
            UnitClassification.Biological,
            ParasiteHealth,
            ParasitePower,
            ParasiteAggression)
        {
        }
    }
}
