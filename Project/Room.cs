using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
            Items = new List<Item>();
        }

        public Dictionary<string, Room> exits = new Dictionary<string, Room>();

        public Room Go(string direction)
        {
            if (exits.ContainsKey(direction)) {
                return exits[direction];
            }
            return null;
        }

        public void UseItem(Item item)
        {
            throw new System.NotImplementedException();
        }
    }
}