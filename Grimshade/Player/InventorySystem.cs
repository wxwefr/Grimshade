
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimshade.Player
{
    public class InventorySystem
    {
        private List<itemHandler> _items = new List<itemHandler>();

        public void AddItem(itemHandler itemHandler)
        {
            _items.Add(itemHandler);
            Console.WriteLine($" - {itemHandler.i_Name} added to your inventory. ");
        }

        public bool ItemLists(PlayerHandler player)
        {
            if( _items.Count == 0 ) { return false; }

            Console.WriteLine("\n --- Inventory ---");
            for (int i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                Console.WriteLine($"{i + 1}. {item.i_Name} [{item.i_Type}]");
            }
            Console.WriteLine("0 - Cancel");
            Console.Write("Choose a item");

            if(!int.TryParse(Console.ReadLine(), out var choice) || choice < 0 || choice > _items.Count)
            {
                Console.WriteLine("Invalid choice.");
                return false;
            }

            if (choice == 0)
                return false;

            itemHandler selected = _items[choice - 1];

            switch(selected.i_Type) 
            {
                case itemType.Weapon:
                    Console.Write($"Equip {selected.i_Name}? (y/n): ");
                    if(Console.ReadLine().Trim().ToLower() == "y")
                    {
                        _items.RemoveAt(choice - 1);
                        player.currentWeapon = selected;
                    }
                    break;

                case itemType.Consumable:
                    Console.Write($"Use {selected.i_Name}. ");
                    break;
            }
            return true;
        }

        public void displayInventory()
        {
            Console.WriteLine("\n =========== Inventory ===========");
            if(_items.Count == 0 ) 
            {
                Console.WriteLine("Your inventory is empty");
            }
            else
            {
                foreach (var item in _items)
                    Console.WriteLine($" - {item.i_Name} [{item.i_Type}]");
                
            }
         Console.WriteLine("===============================");

        }
    }
}
