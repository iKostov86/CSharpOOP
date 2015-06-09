namespace TradeAndTravel
{
    using System;
    using System.Collections.Generic;

    public class Weapon : Item
    {
        const int GeneralWeaponValue = 10;

        public Weapon(string name, Location location = null)
            : base(name, Weapon.GeneralWeaponValue, ItemType.Weapon, location)
        {
        }
        
        public static List<ItemType> GetComposingItems()
        {
            return new List<ItemType>() { ItemType.Iron, ItemType.Wood };
        }
    }
}
