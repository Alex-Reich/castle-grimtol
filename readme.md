# Console Game Checkpoint

### The Setup

As you begin working on a console game the basic requirements of any good console game will allow users to:
  - Move about a set of rooms
  - Get a description of the room they are in
  - Get Help - Shows a list of all available commands
  - Use Items
  - Give Up 
  - Restart
  
To help you out with some of these basic features will notice that you already have some interfaces that have been built. These interfaces are designed to help ensure you implement the basic requirements of a console game. 

### Step 1 -  Satisfy the Interfaces 

To satisfy the interfaces you will need to ensure that your classes implement all of the features of the provided interfaces... You cannot remove anything from any of the interfaces. 
  The Basic Features of the game:
  - `Go <Direction>` Moves the player from room to room
  - `Use <ItemName>` Uses an item in a room or from your inventory
  - `Take <ItemName>` Places an item into the player inventory and removes it from the room
  - `Help` Shows a list of commands and actions
  - `Quit` Quits the Game

### Step 2 - Control the Game Loop

We have provided a basic story and map if you are not creative or simply don't want to spend your time thinking of a story to play your game. Following the provided story is not required however creating some sort of experience is. 

Your Game must implement the following features
  - At least 4 rooms
  - At least 1 usable item
  - At least 1 item that can be taken (can be the same as the usable item)
  - At least 1 room that changes based on an item use
  - When the player enters a room they get the room description
  - Players can see the items in their inventory
  - Players lose the game due to a bad decision
  - Players can win the game
  
  
 ## Functionality: 
 - Players can move room to room with the `go <direction>` command
 - Players can `use` items to change the state of the room (use key or use light)
 - Items exist for the player to `take` from rooms (not required for these to be used in a room)
 - `quit` ends the game
 - At least 4 rooms, 1 usable item, and 1 takeable item
 - Players can lose the game due to a bad decision
 - The game is winnable 

## Visualization: 
 - `help` Provides the user a list of commands for your game
 - `look` Re-prints the room description
 - `inventory` prints a list of the items in the players inventory
 -  When the player enters a room they get the room description
  
### BONUS IDEAS - Some enhancing features
- Try changing the console color or adding some beeps for dramatic effect
- Clear the console when appropriate
- The user should know when its their turn try formatting the users input with something like this everytime its the users turn to type
  - What do you do: __________________ // <- Their Answer on the same line
- Add some riddles or puzzles for users to solve to get from room to room

### Finished?
When You are finished please submit the url for your github repo to the gradebook.


### Alex's Plan
Goal: Get dressed and do all other "prepare for the day" tasks, get in car, and drive away
Items: Car key, clothes, cell phone; other everyday task objects
Rooms:
    -Bedroom
    -Bathroom
    -Kitchen
    -Garage
    -Car
Uses: 
  -Car Key, use at car: found in kitchen. unlocks door, player enters. 
  -Car Key: use inside car. Starts engine and drives away. Wins game.
  -Clothes: found in bedroom. use anywhere. Player gets dressed.
  -Remote Garage Door Opener: found in bedroom, opens garage door. 
  -Deoderant: found in bathroom. use anywhere. Player applies deoderant.
  -Toothpaste & toothbrush: use in bathroom. Player brushes teeth.
  -Orange Juice: found in kitchen. If drank after brushing teeth player loses 1 health.
  -Taco Bell Doritos Locos Taco: found in car. use anywhere. Player gains 1 health, then later loses 5 health. 
  -Cell Phone: found in bedroom. use anywhere. Tells current time, 5 missed calls, 6 unread messages. All mention you needing to be somewhere fast! Player puts phone away after using.

Start:
It's dark. There is a strange scent in the air, a loud buzzing sound, and you feel as though you are wrapped up tightly, unable to move your extremities. Panic begins to set in.     -Eyes closed, need to open eyes

You open your eyes and find yourself knotted in blankets on your bed. Light fills your bedroom through the window, it is morning. You determine the buzzing sound to be from your phone located on the floor across the room, next to a pile of your clothes you removed before falling asleep and a garage door opener. As you begin to fully awaken, you realize the strange scent is your own body odor. 

What do you do?
Objects: Clothes, phone, remote garage door opener
Rooms: East - Bathroom, South - downstairs to kitchen

Bathroom:


Objects: Toothpaste & toothbrush, deoderant
Rooms: West - Bedroom


Kitchen:


Objects: Car Keys, OJ
Rooms: North - Bedroom, West - Garage


Garage:



Objects: 
Rooms: East - Kitchen, West - Car




Car:



Objects: Taco Bell Doritos Locos Taco
Rooms: East - Garage



Jump to end:
Type "Go back to sleep"
  -Player goes back to sleep and wakes up the next day, which is Saturday. No need to rush anywhere, you win!