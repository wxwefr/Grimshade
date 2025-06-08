using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimshade.Player
{
    public class PlayerHandler
    {
        //Public player details
        public string playerName { get; set; }                      //Players Name
        public int playerHealth { get; set; }                             //Health points
        public int playerMaxHp { get; set; }                          //Max HP
        public int PlayerXp { get; set; } = 0;
        public int PlayerXpMax { get; set; }
        public int playerLevel { get; set; } = 0;

        //Public Weapon Shit
        public itemHandler currentWeapon { get; set; }

        //Inventory
        public InventorySystem Inventory { get; private set; }

        //Private player details
        private int BaseAttackPower = 5;                            //Attack power

        public int AttackPower
        {
            get
            {
                return BaseAttackPower + (currentWeapon?.i_AttackBonus ?? 0);
            }
        }

        //Setting Player details its public so the code can read and access it out side of the namespace/class
        public PlayerHandler(string pName)
        {
            playerName = pName;
            playerHealth = 5;
            playerMaxHp = 5;
            Inventory = new InventorySystem();
        }

        public void GetXP(int xp)
        {
            PlayerXp += xp;
            Console.WriteLine($"You gained {xp} XP! Total XP: {PlayerXp}/{PlayerXpMax}");

            if(PlayerXp >= PlayerXpMax)
            {
                LevelUp();
                PlayerXp -= PlayerXpMax;
            }
        }

        private void LevelUp()
        {
            BaseAttackPower += 2;
            playerMaxHp += 5;
            playerHealth = playerMaxHp;
            playerLevel += 1;
            Console.WriteLine($"You have leveled up to {playerLevel}");
        }

        public void Healable()
        {
            playerHealth = playerMaxHp;
            Console.WriteLine($"You have been healed to {playerHealth}/{playerMaxHp} HP.");
        }

        public void playerStatus()
        {
            Console.WriteLine($"| ================ {playerName}'s Stats ================ |");

            Console.WriteLine($" - LVL: {playerLevel}");
            Console.WriteLine($" - XP: {PlayerXp}/{PlayerXpMax}");
            Console.WriteLine($"\n");
            Console.WriteLine($" - HP: {playerHealth}/{playerMaxHp}");
            Console.WriteLine($" - AP: {AttackPower} (Base {BaseAttackPower} + Weapon {(currentWeapon?.i_AttackBonus ?? 0)})");

            //If player has a weapon Equipped
            if (currentWeapon != null)
            {
                Console.WriteLine($" - Equipped: {currentWeapon.i_Name}"); // Equipped weapons name i_Name short for item name.
            }
            else // If they dont
            {
                Console.WriteLine($" - Equipped: Fists");
                Console.WriteLine($"\n");
            }
            Console.WriteLine($"| ====================================================== |");
        }
    }
}
