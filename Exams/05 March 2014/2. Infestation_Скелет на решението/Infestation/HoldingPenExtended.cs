namespace Infestation
{
    using System;

    public class HoldingPenExtended : HoldingPen
    {
        protected override void ProcessSingleInteraction(Interaction interaction)
        {
            Unit targetUnit = this.GetUnit(interaction.TargetUnit);
            ISupplement supplement = null;

            switch (interaction.InteractionType)
            {
                case InteractionType.Infest:
                    supplement = new InfestationSpores();
                    break;
                default:
                    base.ProcessSingleInteraction(interaction);
                    break;
            }

            if (targetUnit != null && supplement != null)
            {
                targetUnit.AddSupplement(supplement);
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            ISupplement supplement = null;

            switch (commandWords[1])
            {
                case "Weapon":
                    supplement = new Weapon();
                    break;
                case "HealthCatalyst":
                    supplement = new HealthCatalyst();
                    break;
                case "PowerCatalyst":
                    supplement = new PowerCatalyst();
                    break;
                case "AggressionCatalyst":
                    supplement = new AggressionCatalyst();
                    break;
                default:
                    break;
            }

            var unit = GetUnit(commandWords[2]);

            if (unit != null)
            {
                unit.AddSupplement(supplement);
            }
        }

        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            Unit unit = null;

            switch (commandWords[1])
            {
                case "Tank":
                    unit = new Tank(commandWords[2]);
                    break;
                case "Marine":
                    unit = new Marine(commandWords[2]);
                    break;
                case "Parasite":
                    unit = new Parasite(commandWords[2]);
                    break;
                case "Queen":
                    unit = new Queen(commandWords[2]);
                    break;
                default:
                    base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }

            if (unit != null)
            {
                this.InsertUnit(unit);
            }
        }
    }
}
