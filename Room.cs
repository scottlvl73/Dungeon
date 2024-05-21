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
                Console.ReadKey();
                SkullRoom(player);
            }
            else if(temp.Equals("s", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("south", StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine("You head back the way you came to see if anything is interesting");
                Console.ReadKey();
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
            commands[2] = "South";
            commands[1] = "Take Skull";
            roomArray[2] = true;
            playerPosition = 2;
            Console.Clear();
            Maps.CatacombsMap(player, roomArray, playerPosition, commands);
            if (player.Inventory.Contains(InventoryItem.skull))
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
                Console.ReadKey();
                RoomAltar(player);
                break;

                case "s":
                case "south":
                Print("You head south");
                Console.ReadKey();
                RoomTutorialSecond(player);
                break;

                case "take":
                case "take skull":
                Print("You stuff the skull into your backpack, maybe it will be useful later");
                //var skull = new InventoryItem(name: "Skull", quantity: 1, description: "A weathered skull", effect: "Unknown");
                player.Inventory.Add(InventoryItem.skull);
                SkullRoom(player);
                break;

                case "i":
                case "inventory":
                player.AccessInventory();
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
                    Console.ReadKey();
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
                    player.AccessInventory();
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
                if (chestOpened1 == false){
                    Print("You pry open the lock on the chest and find two healing potions and 300 gold");
                   
                    player.gold += 300;
                    player.Inventory.Add(InventoryItem.potion);
                    player.Inventory.Add(InventoryItem.potion);
                    chestOpened1 = true;
                } else {
                    Print("The chest has already been looted");
                }
                     RoomSecret(player);
                    break;

                case "i":
                case "inventory":
                    player.AccessInventory();
                    RoomSecret(player);
                    break;
                default:
                    Print("I don't understand");
                    RoomSecret(player);
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
                case "":
                    break;
                case "i":
                case "inventory":
                    player.AccessInventory();
                   // Room(player);
                    break;
                default:
                    Print("I don't understand");
                   // Room(player);
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
