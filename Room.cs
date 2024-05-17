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
        
       private static bool[] roomArray = new bool[19];
       private static int playerPosition = new();

       private static string[] commands = new string[4] { " ", " ", " ", " "};
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
            string? temp = Console.ReadLine();
            
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
        }

        static void SkullRoom(Player player)
        {
            Array.Clear(Room.commands, 0 , Room.commands.Length);
            Room.commands[0] = "North";
            Room.commands[2] = "South";
            Room.commands[1] = "Take Skull";
            Room.roomArray[2] = true;
            playerPosition = 2;
            Console.Clear();
            Maps.CatacombsMap(player, Room.roomArray, playerPosition, commands);
            Print("The room contains large overhangs and in the corner is a ornate skull, like it was a ritual object of some sort");

            string? temp = Console.ReadLine();
            if (temp.Equals("north", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                Print("The door is locked");
                Console.ReadKey();
                SkullRoom(player);
            }
            else if (temp.Equals("south", StringComparison.CurrentCultureIgnoreCase) || temp.Equals("s", StringComparison.CurrentCultureIgnoreCase))
            {
                Print("You head south");
                Console.ReadKey();
                RoomTutorialSecond(player);
            }
            else
            {
                Print("That command is not recognized");
                SkullRoom(player);
            }
            
        }
        static void BackToStartRoom(Player player)
        {
            Array.Clear(Room.commands, 0 , Room.commands.Length);
            Room.commands[0] = "North";
            
            Console.Clear();
            playerPosition = 0;
            Room.roomArray[0] = true;
            Maps.CatacombsMap(player, Room.roomArray, playerPosition, commands);

            Print("There is nothing of interest");
            string? temp = Console.ReadLine();
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
            
        }
        static void RoomTutorialSecond(Player player)
        {
            Array.Clear(Room.commands, 0 , Room.commands.Length);
            Room.commands[0] = "North";
            Room.commands[2] = "South";
            Console.Clear();
            playerPosition = 1;
            Maps.CatacombsMap(player, Room.roomArray, playerPosition, commands);

            Print("You return to where the kobolds corpse lies");
            string? temp = Console.ReadLine ();
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
