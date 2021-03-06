using System;
using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public bool playing { get; set; } = true;
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }
        private List<Room> _rooms = new List<Room>();

        public void Play()
        {
            Setup();

            // playing = true;
            while (playing)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.Write("What would you like to do? ");
                Console.ForegroundColor = ConsoleColor.White;
                string userInput = Console.ReadLine();
                string[] input = userInput.ToLower().Split(" ");
                Console.ForegroundColor = ConsoleColor.Blue;
                switch (input[0])
                {
                    case "go":
                        if (input.Length == 1)
                        {
                            Console.Clear();
                            System.Console.WriteLine("You must enter a direction alongside the 'go' command");
                        }
                        else
                        {

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
                        }
                        break;
                    case "look":
                        Console.Clear();
                        System.Console.WriteLine($"You are in the {CurrentRoom.Name}: {CurrentRoom.Description}.");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        System.Console.WriteLine("In the room you find:");
                        if (CurrentRoom.Items.Count > 0)
                        {

                            foreach (var i in CurrentRoom.Items)
                            {
                                Console.WriteLine(i.Name);
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
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
Goal - Displays objective of game
Quit - Quits the Game");
                        break;
                    case "take":
                        Console.Clear();
                        if (input.Length == 1)
                        {
                            System.Console.WriteLine("You must enter an item name alongide the 'take' command");
                        }
                        else
                        {
                            TakeItem(input[1]);
                        }
                        break;
                    case "use":
                        Console.Clear();
                        if (input.Length == 1)
                        {
                            System.Console.WriteLine("You must enter an item name alongside the 'use' command");
                        }
                        else
                        {
                            UseItem(input[1]);
                        }
                        break;
                    case "i":
                        if (CurrentPlayer.Inventory.Count > 0)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("You are currently holding:");
                            foreach (var i in CurrentPlayer.Inventory)
                            {
                                Console.WriteLine(i.Name);
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
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
                        if (CurrentRoom.Name == "Bedroom")
                        {
                            playing = false;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Red;
                            System.Console.WriteLine("You decide to go back to sleep, dismissing the troubles and stresses of the day. The consequences of your actions will certainly be a problem for 'future you,' but for now, you choose to seize the day and return to sleep.");
                            System.Console.WriteLine("----------YOU ARE A WINNER!----------");
                            System.Console.WriteLine("Start over? y/n");
                            string again = Console.ReadLine().ToLower();
                            if (again == "y") { Console.Clear(); Reset(); };
                            if (again == "n") { playing = false; };
                        }
                        else
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            System.Console.WriteLine("So you know the secret command, eh? Well too bad for you, you can't sleep in this room!");
                        }
                        break;
                    case "goal":
                        Console.Clear();
                        System.Console.WriteLine(@"Goal: Get dressed and do all the other 'prepare for the day' tasks. Then get in your car and drive away
For a list of possible actions type 'help'");
                        break;
                    default:
                        System.Console.WriteLine("Please enter a proper action. Type 'help' if you are stuck");
                        break;
                }

            }
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Reset()
        {
            Play();
        }

        public void Setup()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            CreateRooms();
            playing = true;
            Console.WriteLine(@"
With a jolt, you awake. You open your eyes and find yourself knotted in blankets on your bed. Light fills your bedroom through the window, it is morning, and once again you've slept through your alarm. You're late! 
            
You hear a buzzing sound coming from your phone located on the floor across the room, next to a pile of your clothes and the garage door opener. You had better check your phone!

Goal: Get dressed and do all the other 'prepare for the day' tasks. Then get in your car and drive away
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
                    Console.Write(@"You insert the keys into the ignition and fire up the engine. You throw it into reverse and gun it, leaving tire marks in your garage. You're on your way; mission accomplished!
                    ----------YOU WIN----------");
                    System.Console.WriteLine("");
                    System.Console.WriteLine("But did you complete all the daily tasks before you left?? (i.e. Getting dressed, brushing your teeth, etc.) Play again to try and finish everything before leaving the house.");
                    System.Console.WriteLine("Start over? y/n");
                    string input = Console.ReadLine().ToLower();
                    if (input == "y") { Console.Clear(); Reset(); };
                    if (input == "n") { playing = false; };
                    return;
                }
                if (item.Name == "Taco Bell Doritos Locos Taco")
                {
                    System.Console.WriteLine(item.Description);
                    System.Console.WriteLine((@"
                    UH-OH...
                    
                    You immediately regret your decision to eat this random taco as your stomach begins to grumble. 
                    
                    Before you have time to think, you double over in pain and slowly stumble your way to the bathroom. 
                    
                    You don't make it out of the house, you don't pass go, and you don't collect $200.
                    
                    --------YOU LOSE!--------
                    Start over? y/n"));
                    string input = Console.ReadLine().ToLower();
                    if (input == "y") { Console.Clear(); Reset(); };
                    if (input == "n") { playing = false; };
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
            bedroom.Items.Add(new Item("Cell Phone", "5 missed calls, 6 unread messages. All notifications mention you needing to be somewhere an hour ago!"));
            bedroom.exits.Add("e", bathroom);
            bedroom.exits.Add("s", kitchen);
            _rooms.Add(bedroom);

            bathroom.Items.Add(new Item("Toothpaste & Toothbrush", "You brush your teeth and feel fresh.   Flavor: BubbleGum. 'Thanks Mom...'"));
            bathroom.Items.Add(new Item("Deoderant", "You apply deoderant and your odor improves.  Kinda-Sorta Newish Spice: Cilantro scent."));
            bathroom.exits.Add("w", bedroom);
            _rooms.Add(bathroom);

            kitchen.Items.Add(new Item("Orange Juice", "You drink some OJ straight from the jug, like a real man does.   Freshly squeezed, extra pulp, extra peel."));
            kitchen.Items.Add(new Item("Car Keys", "You jingle the keys. Nothing happens..."));
            kitchen.exits.Add("n", bedroom);
            kitchen.exits.Add("w", garage);
            _rooms.Add(kitchen);

            garage.exits.Add("e", kitchen);
            garage.exits.Add("w", car);
            _rooms.Add(garage);

            car.Items.Add(new Item("Taco Bell Doritos Locos Taco", "You don't know where it came from or how long it's been in your car, but you eat the mysterious, random taco anyway."));
            car.exits.Add("e", garage);
            _rooms.Add(car);

            CurrentRoom = bedroom;
            Player player1 = new Player("player1");
            CurrentPlayer = player1;
        }
    }
}