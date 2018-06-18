using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Room(string name, string description, List<Item> Items)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }

        public void PickUpItem(Item item)
        {
            Items.Add(item);
        }
        public void UseItem(Item item)
        {
            
        }
    }
}