using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Room
    {
       private static bool[] roomArray = new bool[19];
       private static int playerPosition = new();

        //What does a room need? exits, interactables, examine,
        public static void RoomTutorial(Player player)
        {
            
            Room.roomArray[1] = true;
            playerPosition = 1;
            Console.Clear();
            Maps.CatacombsMap(player, Room.roomArray, playerPosition);          
            Print("As the beast falls to the ground, you start to scan your surroundings, you are in");
            Print("a large dark cooridor with two directions to progress. Either north or back the way you came.");
            string? temp = Console.ReadLine();
            
            if (temp.ToLower() == "n" || temp.ToLower() == "north")
            {
                Console.WriteLine("You move north and enter the next room");
                Console.ReadKey();
                SkullRoom(player);
            }
            else if(temp.ToLower() == "s" || temp.ToLower() == "south")
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
            Room.roomArray[2] = true;
            playerPosition = 2;
            Console.Clear();
            Maps.CatacombsMap(player, Room.roomArray, playerPosition);
            Print("The room contains large overhangs and in the corner is a ornate skull, like it was a ritual object of some sort");

            string? temp = Console.ReadLine();
            if (temp.ToLower() == "north" || temp.ToLower() == "n")
            {
                Print("The door is locked");
                Console.ReadKey();
                SkullRoom(player);
            }
            else if (temp.ToLower() == "south" || temp.ToLower() == "s")
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

            Console.Clear();
            playerPosition = 0;
            Room.roomArray[0] = true;
            Maps.CatacombsMap(player, Room.roomArray, playerPosition);

            Print("There is nothing of interest");
            string? temp = Console.ReadLine();
            if (temp.ToLower() == "north"  | temp.ToLower() == "n")
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
            Console.Clear();
            playerPosition = 1;
            Maps.CatacombsMap(player, Room.roomArray, playerPosition);

            Print("You return to where the kobolds corpse lies");
            string? temp = Console.ReadLine ();
            if (temp.ToLower() == "n" || temp.ToLower() == "north")
            {
                SkullRoom(player);
            }
            if (temp.ToLower() == "s" ||  temp.ToLower() == "south")
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
