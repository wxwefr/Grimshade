using Grimshade.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grimshade.Locations
{
    public class LocationHandler
    {
        public string locName {  get; set; }
        public string locDescription { get; set; }
        public List<itemHandler> itemHandlers { get; set; }

        public LocationHandler(string locName, string locDescription,
            List<itemHandler> itemHandlers
            //Implement npcSystem
            //EnemyTemplates
            )
        {
            this.locName = locName;
            this.locDescription = locDescription;
            this.itemHandlers = itemHandlers ?? new List<itemHandler>();
        }

    }
}
