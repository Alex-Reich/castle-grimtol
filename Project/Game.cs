using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {

        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        private List<Room> _rooms = new List<Room>();

        public void Play()
        {
            Setup();

            bool playing = true;
            while (playing)
            {
                // Console.WriteLine("You win... until the DLC comes out and you find out it was all a dream!");
                // System.Console.WriteLine("Start over? y/n");
                // if (Console.Read() == 'n') { playing = false; };
                System.Console.Write("What would you like to do?");
                string userInput = Console.ReadLine();
                string[] input = userInput.ToLower().Split(" ");

                switch (input[0])
                {
                    case "go":
                        if (input[1] == "n")
                        {
                            var validRoom = CurrentRoom.Go(input[1]);
                            if (validRoom != null)
                            {
                                CurrentRoom = CurrentRoom.Go(input[1]);
                                Console.Clear();
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                            }
                            else
                            {
                                Console.Clear();
                                System.Console.WriteLine("That is not a valid direction from this room.");
                                System.Console.WriteLine($"You are currently in the {CurrentRoom.Name}: {CurrentRoom.Description}");
                            }
                        }
                        if (input[1] == "e")
                        {
                            var validRoom = CurrentRoom.Go(input[1]);
                            if (validRoom != null)
                            {
                                CurrentRoom = CurrentRoom.Go(input[1]);
                                Console.Clear();
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                            }
                            else
                            {
                                Console.Clear();
                                System.Console.WriteLine("That is not a valid direction from this room.");
                                System.Console.WriteLine($"You are currently in the {CurrentRoom.Name}: {CurrentRoom.Description}.");
                            }
                        }
                        if (input[1] == "s")
                        {
                            var validRoom = CurrentRoom.Go(input[1]);
                            if (validRoom != null)
                            {
                                CurrentRoom = CurrentRoom.Go(input[1]);
                                Console.Clear();
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                            }
                            else
                            {
                                Console.Clear();
                                System.Console.WriteLine("That is not a valid direction from this room.");
                                System.Console.WriteLine($"You are currently in the {CurrentRoom.Name}: {CurrentRoom.Description}");
                            }
                        }
                        if (input[1] == "w")
                        {
                            var validRoom = CurrentRoom.Go(input[1]);
                            if (validRoom != null)
                            {
                                CurrentRoom = CurrentRoom.Go(input[1]);
                                Console.Clear();
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}");
                            }
                            else
                            {
                                Console.Clear();
                                System.Console.WriteLine("That is not a valid direction from this room.");
                                System.Console.WriteLine($"You are currently in the {CurrentRoom.Name}: {CurrentRoom.Description}");
                            }
                        }
                        // else
                        // {
                        //     System.Console.WriteLine("That is not a valid direction. Possible directions are n e s w.");
                        // }
                        break;
                    case "look":
                        Console.Clear();
                        System.Console.WriteLine($"{CurrentRoom.Name}: {CurrentRoom.Description}.");
                        System.Console.WriteLine("In the room you find:");
                        if (CurrentRoom.Items.Count > 0)
                        {

                            foreach (var i in CurrentRoom.Items)
                            {
                                Console.WriteLine(i.Name);
                            }
                        }
                        else
                        {
                            Console.Clear();
                            System.Console.WriteLine("There are no items currently in this room.");
                        }
                        break;
                    case "help":
                        System.Console.WriteLine(@"
Go <Direction> Moves the player from room to room
Use <ItemName> Uses an item in a room or from your inventory
Take <ItemName> Places an item into the player inventory and removes it from the room
Quit Quits the Game");
                        break;
                    case "take":
                        Console.Clear();
                        TakeItem(input[1]);
                        break;
                    case "use":
                        UseItem(input[1]);
                        break;
                    case "quit":
                        playing = false;
                        Console.Clear();
                        System.Console.WriteLine("Thanks for playing!");
                        break;
                    default:
                        System.Console.WriteLine("Please enter a proper action. Type 'help' if you are stuck.");
                        break;
                }

            }
        }
        public void Reset()
        {
            Setup();
        }

        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            CreateRooms();
        }
        public void TakeItem(string itemName)
        {
            foreach (var i in CurrentRoom.Items.ToArray())
            {
                var name = i.Name.ToLower();
                if (name.Contains(itemName))
                {
                    CurrentPlayer.Inventory.Add(i);
                    CurrentRoom.Items.Remove(i);
                    System.Console.WriteLine($"You picked up {i.Name}");
                    break;
                }
                else
                {
                    System.Console.WriteLine("There is nothing to pick up by that name.");
                }
            }

        }
        public void UseItem(string itemName)
        {
          
                var item = CurrentPlayer.Inventory.Find(i => i.Name.Contains(itemName));

                if (CurrentPlayer.Inventory.Contains(item))
                {
                    System.Console.WriteLine($"{item.Description}");
                }
                if (!CurrentPlayer.Inventory.Contains(item))
                {
                    System.Console.WriteLine("You don't have the item you are trying to use.");
                }
            
        }
        public void CreateRooms()
        {
            var bedroom = new Room("Bedroom", "Kinda messy, but also kinda clean.    Exits: e -> bathroom, s -> kitchen");
            var bathroom = new Room("Bathroom", "Don't forget your phone!   Exits: w -> bedroom");
            var kitchen = new Room("Kitchen", "There is a distinct lack of Cap'n Crunch in here. How sad.   Exits: n -> bedroom, w -> garage");
            var garage = new Room("Garage", "Cold, damp. Boxes of assorted junk line the walls.  Exits: e -> kitchen, w -> car");
            var car = new Room("Car", "It still runs... Sometimes.   Exits: e -> garage");

            bedroom.Items.Add(new Item("Clothes", "You put on your clothes... for the fourth day in a row."));
            bedroom.Items.Add(new Item("Garage Door Opener", "A garage door opens somewhere."));
            bedroom.Items.Add(new Item("Cell Phone", "5 missed calls, 6 unread messages. All mention you needing to be somewhere fast!"));
            bedroom.exits.Add("e", bathroom);
            bedroom.exits.Add("s", kitchen);
            _rooms.Add(bedroom);

            bathroom.Items.Add(new Item("Toothpaste & Toothbrush", "You brush your teeth.   Flavor: BubbleGum. 'Thanks Mom...'"));
            bathroom.Items.Add(new Item("Deoderant", "You apply deoderant.  Kinda-Sorta Newish Spice: Cilantro scent."));
            bathroom.exits.Add("w", bedroom);
            _rooms.Add(bathroom);

            kitchen.Items.Add(new Item("Orange Juice", "You drink the OJ.   Freshly squeezed, extra pulp, extra peel."));
            kitchen.Items.Add(new Item("Car Keys", "You jingle the keys.   The first step in being super fast and super furious."));
            kitchen.exits.Add("n", bedroom);
            kitchen.exits.Add("w", garage);
            _rooms.Add(kitchen);

            garage.exits.Add("e", kitchen);
            garage.exits.Add("w", car);
            _rooms.Add(garage);

            car.Items.Add(new Item("Taco Bell Doritos Locos Taco", "You eat the taco and then realize, 'I haven't ordered taco bell for over a month!"));
            car.exits.Add("e", garage);
            _rooms.Add(car);

            CurrentRoom = bedroom;
            Player player1 = new Player("player1");
            CurrentPlayer = player1;
        }
    }
}