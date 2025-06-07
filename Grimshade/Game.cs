using Grimshade.Player;
using System;

namespace Grimshade
{
    public class Game
    {
        private Player.Player _player;

        public void Start()
        {
            Console.WriteLine("=== Welcome to Grimshade ===");
            Console.Write("Enter your character's name: ");

            string playerName = Console.ReadLine();
            _player = new Player.Player(playerName);

            MainLoop();

            Console.WriteLine($"\nWelcome, {_player.playerName}!");
            _player.playerStatus();
        }

        private void MainLoop()
        {
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("1 - View Stats");
                Console.WriteLine("2 - Inventory");
                Console.WriteLine("3 - Explore");
                Console.WriteLine("0 - Exit  \n\n");
                Console.WriteLine("Choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        utils.Clear();
                        _player.playerStatus();
                        utils.Pause();
                        break;

                    case "2":
                        utils.Clear();
                        ShowInventoryMenu();
                        utils.Pause();
                        break;

                    case "3":
                        break;

                    default:

                        break;
                }
            }
        }

        private void ShowInventoryMenu()
        {
            while (true)
            {
                _player.Inventory.displayInventory();

                Console.WriteLine("\n- Inventory Actions: ");
                Console.WriteLine("1 - Select an item");
                Console.WriteLine("2 - Return to Main Menu");
                Console.WriteLine("Choice: ");

                string invChoice = Console.ReadLine();
                if (invChoice == "1")
                {
                    bool selectedItem = _player.Inventory.ItemLists(_player);

                    if (!selectedItem)
                    {
                        Console.WriteLine("No item was selected.");
                        utils.Pause();
                    }

                    utils.Clear();
                    continue;
                }
                else if (invChoice == "2")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                    utils.Pause();
                    utils.Clear();
                }
            }
        }

        public class utils
        {
            public static void Pause()
            {
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }

            public static void Clear()
            {
                Console.Clear();
            }
        }
    }
}
