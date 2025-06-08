using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grimshade.Player;

namespace Grimshade.npcs
{
    public class npcHandler
    {
        public string npcName {  get; set; }
        public string Dialogue {  get; set; }
        public bool hasMetBefore { get; set; }

        public string customReply {  get; set; }
        //todo - Questing System


        public npcHandler(string npcName, string Dialogue) 
        {
            this.npcName = npcName;
            this.Dialogue = Dialogue;
            //todo - Add Quests
        }

        public void npcInteract(PlayerHandler player) 
        {
            if(hasMetBefore == false)
            {
                Console.WriteLine($"Hello my name is {npcName}, What is your name wanderer ");
                return;
            }
            else
            {
                Console.WriteLine($"Hello {customReply} what brings you to me today");
                return;
            }
        }
    }
}
