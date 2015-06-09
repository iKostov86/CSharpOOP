namespace TradeAndTravel.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HelpInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    return item;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    return item;
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    return item;
                default:
                    return base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
            }
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "mine":
                    location = new Mine(locationName);
                    return location;
                case "forest":
                    location = new Forest(locationName);
                    return location;
                default:
                    return base.CreateLocation(locationTypeString, locationName);
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            switch (personTypeString)
            {
                case "merchant":
                    return new Merchant(personNameString, personLocation);
                default:
                    return base.CreatePerson(personTypeString, personNameString, personLocation);
            }
        }
        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    this.HandleGatherInteraction(actor, commandWords[2]);
                    break;
                case "craft":
                    this.HandleCraftInteraction(actor, commandWords[2], commandWords[3]);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        public void HandleGatherInteraction(Person actor, string itemName)
        {
            if (actor.Location is IGatheringLocation)
            {
                var gatheringLocation = actor.Location as IGatheringLocation;

                if (actor.HasItemInInventary(gatheringLocation.RequiredItem))
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(itemName));
                }
            }
        }

        public void HandleCraftInteraction(Person actor, string itemType, string itemName)
        {
            switch (itemType)
            {
                case "armor":
                    HandleItemCrafting(actor, ItemType.Armor, itemName);
                    break;
                case "weapon":
                    HandleItemCrafting(actor, ItemType.Weapon, itemName);
                    break;
                default:
                    break;
            }
        }

        public void HandleItemCrafting(Person actor, ItemType itemType, string itemName)
        {
            if (itemType == ItemType.Armor)
            {
                var requiredItem = ItemType.Iron;

                if (actor.HasItemInInventary(requiredItem))
                {
                    AddToPerson(actor, new Armor(itemName));
                }
            }
            else
            {
                var requiredItems = Weapon.GetComposingItems();
                bool chek = true;

                foreach (var requiredItem in requiredItems)
                {
                    if (!actor.HasItemInInventary(requiredItem))
                    {
                        chek = false;
                    }
                }

                if (chek == true)
                {
                    AddToPerson(actor, new Weapon(itemName));
                }
            }
        }
    }
}
