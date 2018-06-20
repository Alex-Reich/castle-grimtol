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
                System.Console.Write("What would you like to do? ");
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
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}. {CurrentRoom.Description}");
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
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}. {CurrentRoom.Description}");
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
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}. {CurrentRoom.Description}");
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
                                System.Console.WriteLine($"You are now in the {CurrentRoom.Name}. {CurrentRoom.Description}");
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
                        System.Console.WriteLine($"You are in the {CurrentRoom.Name}: {CurrentRoom.Description}.");
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
                            System.Console.WriteLine($"You are in the {CurrentRoom.Name}: {CurrentRoom.Description}.");
                            System.Console.WriteLine("There are no items currently in this room.");
                        }
                        break;
                    case "help":
                        Console.Clear();
                        System.Console.WriteLine(@"
        Possible Actions
Look - Examines your current surroundings
Go <Direction> - Moves the player from room to room
Use <ItemName> - Uses an item in a room or from your inventory
Take <ItemName> - Places an item into the player inventory and removes it from the room
i - Lists items in your inventory
Quit - Quits the Game");
                        break;
                    case "take":
                        Console.Clear();
                        TakeItem(input[1]);
                        break;
                    case "use":
                        Console.Clear();
                        if (input[1] != null)
                        {
                            UseItem(input[1]);
                        }
                        else
                        {
                            System.Console.WriteLine("You must enter an item name alongside the 'use' command");
                        }
                        break;
                    case "i":
                        if (CurrentPlayer.Inventory.Count > 0)
                        {
                            Console.WriteLine("You are currently holding:");
                            foreach (var i in CurrentPlayer.Inventory)
                            {
                                Console.WriteLine(i.Name);
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Your inventory is empty! Take something!");
                        }
                        break;
                    case "quit":
                        playing = false;
                        Console.Clear();
                        System.Console.WriteLine("Thanks for playing!");
                        break;
                    case "sleep":
                        playing = false;
                        Console.Clear();
                        System.Console.WriteLine("You decide to go back to sleep, dismissing the troubles and stresses of the day. The consequences of your actions will certainly be a problem for 'future you,' but for now, you choose to return to seize the day and return to sleep. YOU ARE A WINNER!");
                        break;
                    default:
                        System.Console.WriteLine("Please enter a proper action. Type 'help' if you are stuck");
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
            Console.WriteLine(@"
With a jolt, you awake. You open your eyes and find yourself knotted in blankets on your bed. Light fills your bedroom through the window, it is morning, and once again you've slept through your alarm. You're late! 
            
You hear a buzzing sound coming from your phone located on the floor across the room, next to a pile of your clothes and the garage door opener. You had better check your phone!

Goal: Get dressed and do all the other 'prepare for the day' tasks, get in your car, and drive away
For a list of possible actions type 'help'
            ");
        }
        public void TakeItem(string itemName)
        {
            var item = CurrentRoom.Items.Find(i => i.Name.ToLower().Contains(itemName));

            if (CurrentRoom.Items.Contains(item))
            {
                CurrentPlayer.Inventory.Add(item);
                CurrentRoom.Items.Remove(item);
                System.Console.WriteLine($"You picked up {item.Name}");
            }
            else
            {
                System.Console.WriteLine("There is nothing to pick up by that name.");
            }


        }
        public void UseItem(string itemName)
        {

            var item = CurrentPlayer.Inventory.Find(i => i.Name.ToLower().Contains(itemName));
            if (CurrentPlayer.Inventory.Contains(item))
            {
                if (item.Name == "Car Keys" && CurrentRoom.Name == "Car")
                {
                    Console.WriteLine("You insert the keys into the ignition and fire up the engine. You throw it into reverse and gun it, leaving tire marks in your garage. You're on your way; mission accomplished!");
                    System.Console.WriteLine("YOU WIN!!");
                    System.Console.WriteLine("But did you complete all the daily tasks before you left?? Play again to try and finish everything before leaving the house.");
                    System.Console.WriteLine("Start over? y/n");
                    // if (Console.Read() == 'n') {var playing = false; };
                    return;
                }
                System.Console.WriteLine($"{item.Description}");
            }
            else
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

            bedroom.Items.Add(new Item("Clothes", "You put on your favorite shirt and shorts... for the fifth day in a row."));
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

            car.Items.Add(new Item("Taco Bell Doritos Locos Taco", "You eat the taco and then realize that you haven't ordered taco bell for over a month!"));
            car.exits.Add("e", garage);
            _rooms.Add(car);

            CurrentRoom = bedroom;
            Player player1 = new Player("player1");
            CurrentPlayer = player1;
        }
    }
}