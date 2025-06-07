using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimshade.Player
{
    public class Player
    {
        //Public player details
        public string playerName { get; set; }                      //Players Name
        public int playerHealth { get; set; }                             //Health points
        public int playerMaxHp { get; set; }                          //Max HP
        public int PlayerXp { get; set; } = 0;
        public int PlayerXpMax { get; set; }

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
        public Player(string pName)
        {
            playerName = pName;
            playerHealth = playerMaxHp;
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
            throw new NotImplementedException();
        }

        public void Healable()
        {
            playerHealth = playerMaxHp;
            Console.WriteLine($"You have been healed to {playerHealth}/{playerMaxHp} HP.");
        }
    }
}
