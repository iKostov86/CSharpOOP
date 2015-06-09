namespace Infestation
{
    using System;

    public class Queen : Grez
    {
        private const int QueenHealth = 30;
        private const int QueenPower = 1;
        private const int QueenAggression = 1;

        public Queen(string id)
            : base(
            id,
            UnitClassification.Psionic,
            QueenHealth,
            QueenPower,
            QueenAggression)
        {
        }
    }
}
