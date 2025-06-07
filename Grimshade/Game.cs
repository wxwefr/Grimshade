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

            Console.WriteLine($"\nWelcome, {_player.playerName}!");
            _player.playerStatus();
        }
    }
}
