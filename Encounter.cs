using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Encounter
    {
        static void Print(string text, int speed = 40)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                System.Threading.Thread.Sleep(speed);
            }
            Console.WriteLine();
        }

        public static void FirstEncounter(Player player)
        {
           List<string> kobold = Enemies.Kobold();
           
           int enemyHitPoints = Convert.ToInt32(kobold[0]);
           int enemyArmorClass = Convert.ToInt32(kobold[1]);
           int enemyWeaponDamage = Convert.ToInt32(kobold[2]);

            while (enemyHitPoints > 0)
            {
                Random rand = new();
                Console.Clear();

                Console.WriteLine("**********************************************");
                Console.WriteLine("**********************************************");
                Console.WriteLine("**(A)ttack***(I)nventory**********************");
                Console.WriteLine("**(D)efend***(R)un****************************");
                Console.WriteLine("**********************************************");
                Console.WriteLine("***HitPoints: "+ player.playerHealth + " *******Enemy Health: " + enemyHitPoints + " *********************");

                string temp = Console.ReadLine();


                switch (temp)
                {
                    case "a":
                        Print("You lunge at the foe");
                        enemyHitPoints = - 2;
                        Console.ReadKey();

                  
                        break;
                    case "d":
                        Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
                        enemyHitPoints--;
                        Console.ReadKey();

                      
                        break;
                    case "i":
                        Print("You scrounge your knapsack for anything that could turn the tide of battle");
                        Print("I have not figured out how to do this yet, Dev's please fix");
                        Console.ReadKey();

                     
                        break;
                    case "r":
                        Print("You try to evade the foe and live to see another day");
                        var roll = rand.Next(0, 2);
                        if (roll == 0)
                        { Print("You fail to evade and are slashed from the back taking 1 damage!"); }
                        player.playerHealth--;
                        if (roll == 1)
                        { Print("You evade the blow of the blade and have escaped the fight!"); }
                        Console.ReadKey();
                        break;

                    default:
                        Print(temp + " is not a supported command");
                        Console.ReadKey();
                        break;
                }
            }
            Print("You defeated the Kobold and won your freedom");
        }
    }
}
