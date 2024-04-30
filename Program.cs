using Dungeon;
using System.Runtime;

Player player = new();
Console.ForegroundColor = ConsoleColor.Green;
Console.BackgroundColor = ConsoleColor.Black;
Random rand = new Random();
Start();
Introduction();
FirstEncounter();



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

    if (player.playerName == "")
    { 
        Print("You don't even remember your name? This will be a harsh adventure.");
        player.playerName = "Dude";
    }
    else {
        Print("Go forth " + player.playerName + "! You can defeat the darkness!"); }

 }

void Introduction()
{
    player.playerLevel = 1;
    player.playerDamage = 1;
    player.playerArmorClass = 1;
    Print(player.playerName + " you were born in the slums of Pearlgate and always dreamed of the day you could escape");
    Print("You found your chance last week, but this week have found yourself wandering blackened halls wishing you were");
    Print("still hauling fish off the wool docks for the Fishmongers.");
    Print("You turn the corner and come face to face with a kobold, it's teeth gnawing at the chance for a warm meal");
}

void Print(string text, int speed = 40)
{
    foreach(char c in text)
    {
       Console.Write(c);
        System.Threading.Thread.Sleep(speed);
    }
    Console.WriteLine();
}

void FirstEncounter()
{
    Console.Clear();

    Console.WriteLine("*******************************");
    Console.WriteLine("*******************************");
    Console.WriteLine("**(A)ttack***(I)nventory*******");
    Console.WriteLine("**(D)efend***(R)un*************");
    Console.WriteLine("*******************************");
    Console.WriteLine("*******************************");

    string temp = Console.ReadLine();
   

    switch(temp)
    {
        case "a":
              Print("You lunge at the foe");
            Console.ReadKey();

            FirstEncounter();
            break;
        case "d":
            Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
            Console.ReadKey();

            FirstEncounter();
            break;
        case "i":
            Print("You scrounge your knapsack for anything that could turn the tide of battle");
            Console.ReadKey();

            FirstEncounter();
            break;
        case "r":
            Print("You try to evade the foe and live to see another day");
            var roll = rand.Next(0, 2);
                if(roll == 0)
            { Print("You fail to evade and are slashed from the back taking" + 5 + "!"); }
                if(roll == 1)
            { Print("You evade the blow of the blade and have escaped the fight!"); }
            Console.ReadKey();

            FirstEncounter();
                break;
        default: Print(temp + " is not a supported command");
            Console.ReadKey();

            FirstEncounter();
            break;
    }
}