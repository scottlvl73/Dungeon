﻿using Dungeon;
using System.Media;
using System.Runtime;
using System.Xml.Xsl;

internal class Program
{
    public static void Main(string[] args)
    {
        Player player = new();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;
        player.Inventory.Add(InventoryItem.necklace);
        Start();
        Introduction(); 
        Encounter.FirstEncounter(player);
        Room.RoomTutorial(player);
       


        void Start()
        {
            Console.WriteLine("||****************Welcome to Dungeon!****************************************************||");
            Console.WriteLine("||****************___********************************************************************||");
            Console.WriteLine("||***************/   \\*******************************************************************||");
            Console.WriteLine("||**********/\\\\ | . . \\\\*****************************************************************||");
            Console.WriteLine("||********////\\\\|     || ****************************************************************||");
            Console.WriteLine("||*******////   \\\\ ___//\\ ***************************************************************||");
            Console.WriteLine("||******///      \\\\      \\ **************************************************************||");
            Console.WriteLine("||*****///       |\\\\      |**************************************************************||");
            Console.WriteLine("||*****//        | \\\\  \\   \\*************************************************************||");
            Console.WriteLine("||*****/         |  \\\\  \\   \\************************************************************||");
            Console.WriteLine("||************** |   \\\\ /   /************************************************************||");
            Console.WriteLine("||************** |    \\ /   /************************************************************||");
            Console.WriteLine("||************** |     \\\\/|**************************************************************||");
            Console.WriteLine("||************** |      \\\\|**************************************************************||");
            Console.WriteLine("||************** |       \\\\**************************************************************||");
            Console.WriteLine("||***************|        |**************************************************************||");
            Console.WriteLine("||***************|_________\\*************************************************************||");
            Console.WriteLine("||***************************************************************************************||");
            Console.WriteLine("||***************************************************************************************||");

            Print("What is your name Adventurer?");
            player.playerName = Console.ReadLine();

            if (player.playerName == "" || player.playerName == null)
            {
                Print("You don't even remember your name? This will be a harsh adventure.");
                player.playerName = "Dude";
            }
            else
            {
                Print("Go forth " + player.playerName + "! You can defeat the <insert boss here>!");
            }

        }

        void Introduction()
        {
            Print(player.playerName + " you were born in the slums of Pearlgate and always dreamed of the day you could escape");
            Print("You found your chance last week, but this week have found yourself wandering blackened halls wishing you were");
            Print("still hauling fish off the wool docks for the Fishmongers.");
            Print("You turn the corner and come face to face with a kobold, it's teeth gnawing at the chance for a warm meal");
        }

        void Print(string text, int speed = 5)
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