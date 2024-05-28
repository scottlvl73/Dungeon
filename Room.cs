using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Room
    {
        private static bool chestOpened1 = new();
        private static bool roomswitch = new();
       private static readonly bool[] roomArray = new bool[19];
       private static int playerPosition = new();
        private static bool takenSkull = false; 
       private static readonly string[] commands = [" ", " ", " ", " "];
       
        //What does a room need? exits, interactables, examine,
        public static void RoomTutorial(Player player)
        {
            Array.Clear(Room.commands, 0 , Room.commands.Length);
            Room.commands[0] = "North";
            Room.commands[2] = "South";
            Room.roomArray[1] = true;
            playerPosition = 1;
            Console.Clear();
            Maps.CatacombsMap(player, Room.roomArray, playerPosition, commands);          
            Print("As the beast falls to the ground, you start to scan your surroundings, you are in");
            Print("a large dark cooridor with two directions to progress. Either north or back the way you came.");
            string temp = Console.ReadLine();
           
            if (temp != null)
            {
            
            if (temp.Equals("n", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("north", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("You move north and enter the next room");
                Console.Read();
                SkullRoom(player);
            }
            else if(temp.Equals("s", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("south", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("You head back the way you came to see if anything is interesting");
                Console.Read();
                BackToStartRoom(player);
            } else
            {
                Print("That command is not supported");
                RoomTutorial(player);
            }
            }else
            {
                RoomTutorial(player);
            }
        }

        static void SkullRoom(Player player)
        {
           
            Array.Clear(commands, 0 , commands.Length);
            commands[0] = "North";
            commands[3] = "West";
            commands[2] = "South";
            if (player.Inventory.Contains(InventoryItem.skull))
            {
                commands[1] = " ";
            }
            else
            {
            commands[1] = "Take Skull";
            }
            roomArray[2] = true;
            playerPosition = 2;
            Console.Clear();
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            if (takenSkull == true)
            {
            Print("The room contains large overhangs and in the corner was a ornate skull, like it was a ritual object of some sort. \n Now it rests in your backpack though");
            } 
            else
            Print("The room contains large overhangs and in the corner is a ornate skull, like it was a ritual object of some sort");

            string temp = Console.ReadLine();
            //Switch statement with possbile choices North, South, Take Skull, Inventory
            switch (temp.ToLower())
            {
                case "n" :
                case "north": 
                Print("You head north");
                Console.Read();
                RoomAltar(player);
                break;

                case "west" :
                case "w":
                    Print("You head west");
                    Room.RoomChance(player);
                    break;

                case "s":
                case "south":
                Print("You head south");
                Console.Read();
                RoomTutorialSecond(player);
                break;

                case "take":
                case "take skull":
                if(takenSkull == false)
                {
                Print("You stuff the skull into your backpack, maybe it will be useful later");
                player.Inventory.Add(InventoryItem.skull);
                takenSkull = true;}
                else {
                    Print("You already have it");
                }
                SkullRoom(player);
                break;

                case "i":
                case "inventory":
                player.AccessInventory(player);
                SkullRoom(player);
                break;

                default:
                Print("That command is not recognized");
                SkullRoom(player);
                break;
            }

        }
        static void BackToStartRoom(Player player)
        {
            Array.Clear(commands, 0 , commands.Length);
            commands[0] = "North";
            
            Console.Clear();
            playerPosition = 0;
            roomArray[0] = true;
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);

            Print("There is nothing of interest");
            string temp = Console.ReadLine();
            if (temp != null)
            {
            if (temp.Equals("north", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                Print("You head north");
                RoomTutorialSecond(player);
            }
            else
            {
                Print("That command is not recognized");
                BackToStartRoom(player);
            }
            } else {
                BackToStartRoom(player);
            }
        }
        static void RoomTutorialSecond(Player player)
        {
            Array.Clear(commands, 0 , commands.Length);
            commands[0] = "North";
            commands[1] = "South";
            Console.Clear();
            playerPosition = 1;
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);

            Print("You return to where the kobolds corpse lies");
            string temp = Console.ReadLine ();
            if (temp != null)
            {
            if (temp.Equals("n", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("north", StringComparison.CurrentCultureIgnoreCase))
            {
                SkullRoom(player);
            }
            if (temp.Equals("s", StringComparison.CurrentCultureIgnoreCase) ||  temp.Equals("south", StringComparison.CurrentCultureIgnoreCase))
            {
                Print("You head south");
                BackToStartRoom(player);
            }
            else
            {
                Print("I dont understand");
                RoomTutorialSecond(player);
            }
            } else {
                RoomTutorialSecond(player);
            }
        }
 static void RoomAltar (Player player)
    {
        Array.Clear(commands, 0 , commands.Length);
            //Defines what can be done in each room.
            commands[0] = "South";
            commands[1] = "Use";
            if (roomswitch == true)
                commands[2] = "East";
                else 
                commands[2] = "";
            commands[3] = "";
            Console.Clear();
            //Set's player;s location on map
            playerPosition = 3;
            //Room array flags explored room
             roomArray[3] = true;
            //Calls Mapping
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            
            if (roomswitch == false){
            Print("The air within the catacombs is stale and musty as you step into the room");
            Print("The walls faded were once filled with burning lamps, now all snuffed out from the passage of time");
            Print("In the heart of the chamber stands an altar curiously with an empty skull shaped fitting");
            } else {
                Print("The skull fit cleanly into the altar. This ritual was performed many times in the past");
                }
            string temp = Console.ReadLine();
            
            switch (temp.ToLower())
            {
                case "south": 
                case "s":
                    Print("You head back the way you came");
                    Console.ReadKey();
                    SkullRoom(player);
                    break;
                case "use":
                    Print("Use what?");
                    Console.ReadKey();
                    RoomAltar(player);
                    break;
                case "use skull":
                if (player.Inventory.Contains(InventoryItem.skull)){
                    Print("You slot the skull into the recess and you hear a crumbling in the distance");
                    Print("A wall opened to reveal a path to the east");
                    player.Inventory.Remove(InventoryItem.skull);
                    roomswitch = true;
                } else 
                { 
                   Print("You don't have anything that fits");     
                }
                    Console.Read();
                    RoomAltar(player);
                    break;
                case "east":
                case "e":
                    if (roomswitch == true){
                    Print("You head through the newly opened passage");
                    RoomSecret(player);
                    } else {
                        Print("There is just a wall");
                    }
                    break;
                case "i":
                case "inventory":
                    player.AccessInventory(player);
                    RoomAltar(player);
                    break;
                default:
                    Print("I don't understand");
                    RoomAltar(player);
                break;
            }           
    }

        static void RoomSecret (Player player)
    {
        Array.Clear(commands, 0 , commands.Length);
            //Defines what can be done in each room.
            
            commands[0] = "(W)est";
            commands[1] = "(O)pen";
            commands[2] = "";
            commands[3] = "";
           
            Console.Clear();
            //Set's player's location on map
            playerPosition = 4;
            //Room array flags explored room
             roomArray[4] = true;
            //Calls Mapping
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            //Room Decription
            Print("As you step into the room, you notice a single chest with a few trinkets of no importance lying around");
            string temp = Console.ReadLine();
            switch (temp.ToLower()) {
                case "west":
                case "w":
                    Print("You head back the way you came");
                    RoomAltar(player);
                    break;
                case "open chest":
                case "o":
                case "open":
                if (chestOpened1 == false){
                    Print("You pry open the lock on the chest and find two healing potions and 300 gold");
                   
                    player.gold += 300;
                    player.Inventory.Add(InventoryItem.potion);
                    
                    chestOpened1 = true;
                    Console.Read();
                } else {
                    Print("The chest has already been looted");
                }
                     RoomSecret(player);
                    break;

                case "i":
                case "inventory":
                    player.AccessInventory(player);
                    RoomSecret(player);
                    break;
                default:
                    Print("I don't understand");
                    RoomSecret(player);
                break;
                
            }      
    }
      static void RoomChance (Player player)
    {
        Array.Clear(commands, 0 , commands.Length);
            //Defines what can be done in each room.
            commands[0] = "East";
            commands[1] = "West";
            commands[2] = "North";
            commands[3] = "";
            Console.Clear();
            //Set's player's location on map
            playerPosition = 5;
            //Room array flags explored room
             roomArray[5] = true;
            //Calls Mapping
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            //Room Description
            Print("Going west there is a dank smell in the air from the necrosis setting in.");
            Print("You really do not like this place.");
            Encounter.ChanceEncounter(player);
            //
            string temp = Console.ReadLine();
            switch (temp.ToLower()) {
                case "east":
                case "e":
                 Print("You head back to the east");
                // Room.
                Room.SkullRoom(player);
                    break;
                case "west":
                case "w":
                    Print("You head to the west");
                  //  Room.SkullRoom(player);
                    break;
                case "n":
                case "north":
                    Print("You head north");
                    Room.RoomMiniBoss(player);
                    break;
                case "i":
                case "inventory":
                    player.AccessInventory(player);
                    Room.RoomChance(player);
                    break;
                default:
                    Print("I don't understand");
                    Room.RoomChance(player);
                break;
            }      
    }
    static void RoomCutout (Player player)
    {
        Array.Clear(commands, 0 , commands.Length);
            //Defines what can be done in each room.
            commands[0] = "";
            commands[1] = "";
            commands[2] = "";
            commands[3] = "";
            
            Console.Clear();
            //Set's player's location on map
            playerPosition = 0;
            //Room array flags explored room
             roomArray[0] = true;
            //Calls Mapping
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            //Room Description
            Print("");
            //
            string temp = Console.ReadLine();
            switch (temp.ToLower()) {
                //Commands
                case "":
                    break;
                //Menus
                case "i":
                case "inventory":
                    player.AccessInventory(player);
                   // Room(player);
                    break;
                default:
                    Print("I don't understand");
                   // Room(player);
                break;
            }      
    }
static void RoomMiniBoss (Player player)
    {
        Array.Clear(commands, 0 , commands.Length);
            //Defines what can be done in each room.
            commands[0] = "(S)outh";
            commands[1] = "(E)xamine";
            commands[2] = "";
            commands[3] = "";
            Print("North of this room is a library. This seems seriously out of place in the catacombs." + 
            " The smell still exists, but the furnishings are suspect. The walls are lined with bookcases filled with books.");
            
            // When the player reaches to examine a title, the necromancer appears.
            //(Lvl 1 mini boss) 
            //After the battle there is a book on the lectern that catches your eye, you can take it. There is a key inside.
            Console.Clear();
            //Set's player's location on map
            playerPosition = 6;
            //Room array flags explored room
             roomArray[6] = true;
            //Calls Mapping
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            //Room Description
            //
            string temp = Console.ReadLine();
            switch (temp.ToLower()) {
                //Commands
                case "s":
                case "south":
                Print("You head back south the way you came");
                Room.RoomChance(player);
                break;

                case "e":
                case "examine":
                Print("When you reach to examine the book on the lectern, you hear a voice " + 
                "Welcome to my Archives. Unfortunately, you will not have the time to take in the sights.");
                Console.Read();
                Encounter.MiniBoss(player);
                RoomMiniBoss(player);
                break;


                //Menus
                case "i":
                case "inventory":
                    player.AccessInventory(player);
                    Room.RoomMiniBoss(player);
                    break;
                default:
                    Print("I don't understand");
                   RoomMiniBoss(player);
                break;
            }      
    }

        static void Print(string text, int speed = 5)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
           
        }

    }
}
