namespace TradeAndTravel.Helpers
{
    using System;
    using System.Linq;

    public static class HelpPerson
    {
        public static bool HasItemInInventary(this Person actor, ItemType requiredItemType)
        {
            return actor.ListInventory().Exists(x => x.ItemType == requiredItemType);
        }
    }
}
