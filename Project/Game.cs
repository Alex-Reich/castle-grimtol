using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {

        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        private List<Room> _rooms = new List<Room>();

        public void Reset()
        {
            Setup();
        }

        public void Setup()
        {
            CreateRooms();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

        }
        public void UseItem(string itemName)
        {

            System.Console.WriteLine("Whatever");

        }
        public void CreateRooms()
        {
            
            var room1 = new Room("Bedroom", "Description", ); 
            room1.Items.Add(new Item("Clothes", "The finest threads the thrift shop has to offer."));
            room1.Items.Add(new Item("Garage Door Opener", "One push and 'Whoo!'"));
            room1.Items.Add(new Item("Cell Phone", ""));
            _rooms.Add(room1);
        }
    }
}