using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Grimshade.Player
{
    //Setting Item Types will item be equipable or not etc
    public enum itemType
    {
        Weapon,
        Consumable,
        NotConsumable,   // generic “loot” / crafting / quest items
        currency
    }


    public class itemHandler
    {
        public string i_Name { get; private set; }
        public itemType i_Type { get; private set; }

        // Only for weapons:
        public int i_AttackBonus { get; private set; }

        // Only for consumables:
        public bool Healable { get; private set; }

        // Only for generic/trade items:
        public int i_Value { get; private set; }

        // Weapon constructor
        public itemHandler(string name, int attackBonus)
        {
            i_Name = name;
            i_Type = itemType.Weapon;
            i_AttackBonus = attackBonus;
            Healable = false;
            i_Value = 0;
        }

        public itemHandler(string name, bool healable)
        {
            i_Name = name;
            i_Type = itemType.Consumable;
            Healable = false;
            i_Value = 0;
        }

        public itemHandler(string name, int value, itemType type = itemType.NotConsumable)
        {
            i_Name = name;
            i_Type = type;
            i_Value = value;
            Healable = false;
        }

        public void UseItem(Player player)
        {
            //Returning if not a healable
            if (i_Type != itemType.Consumable)
                return;

            if (Healable)
            {
                player.Healable();
            }

        }

    }

}