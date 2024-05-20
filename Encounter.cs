using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Encounter
    {
        static void Print(string text, int speed = 5)
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
                Console.Clear();

                Console.WriteLine("***************************************************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("**(A)ttack*********************(I)nventory*********");
                Console.WriteLine("**(D)efend***********************(R)un*************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("***HitPoints: " + player.playerHealth + " *******Enemy Health: " + enemyHitPoints + " ****************");

                string? temp = Console.ReadLine();


                switch (temp)
                {
                    case "a": 
                        int roll = DiceRolls.D20();
                        if (roll >= enemyArmorClass)
                        {
                            Print("You lunge at the foe dealing " + player.playerDamage + " damage to the snarling beast");
                            enemyHitPoints -= player.playerDamage;
                            Console.WriteLine("Player Success: D20 rolled " + roll + " enemy Armor class was " + enemyArmorClass);

                            Console.ReadKey();
                        }
                        else
                        {
                            Print("The enemy dodges the blow and prepares an assault of it's own!");
                            Console.WriteLine("Player Failed Condition: D20 rolled " + roll + " enemy Armor class was " + enemyArmorClass);
                            Console.ReadKey();
                        }

                        break;


                    case "d":
                        Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
                        enemyHitPoints--;
                        Console.ReadKey();

                        break;

                    case "i":
                        Print("You scrounge your knapsack for anything that could turn the tide of battle");
                        player.AccessInventory();
                        Console.ReadKey();

                        break;

                    case "r":
                        Print("There is no escape!");
                        Console.ReadKey();
                        break;

                    default:
                        Print(temp + " is not a supported command");
                        Console.ReadKey();

                        break;
                }

                if (enemyHitPoints > 0)
                {
                    int roll = DiceRolls.D20();
                    if (roll >= player.armorClass)
                    {

                        Print("The enemy recoils and returns a slice from it's dagger dealing " + enemyWeaponDamage + "damage!");
                        player.playerHealth -= enemyWeaponDamage;
                        Console.WriteLine("Enemy Success: D20 rolled " + roll + " player Armor class was" + player.armorClass);

                        Console.ReadKey();
                    }
                    else
                    {
                        Print("You deftly dodge the blow and ready your sword");
                        Console.WriteLine("Enemy Failed Condition: D20 rolled " + roll + " player Armor class was " + player.armorClass);

                        Console.ReadKey();
                       

                    }
                    if (player.playerHealth <= 0)
                    {
                        Encounter.GameOver();
                    }
                }
            }
            
            player.gold += Convert.ToInt32(kobold[3]);
            player.experience += Convert.ToInt32(kobold[4]);
            Print("You defeated the Kobold and won your freedom");
            Print("You gained " + kobold[3] + " gold and " + kobold[4] + " experience");


            Console.ReadKey();

            
        }

        static void GameOver()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("**********************");
            Console.WriteLine("**********************");
            Console.WriteLine("You Died!");
            Console.WriteLine("Do you want to start over? too bad, I haven't coded that in yet.");
            Console.ReadKey();
            Environment.Exit(0);
        }

    }
  
}
// runaway method
//Print("You try to evade the foe and live to see another day");
//var roll = rand.Next(0, 2);
//if (roll == 0)
//{ Print("You fail to evade and are slashed from the back taking 1 damage!"); }
//player.playerHealth--;
//if (roll == 1)
//{ Print("You evade the blow of the blade and have escaped the fight!"); }
//Console.ReadKey();
