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
            Enemies kobold = Enemies.CreateKoboldEncounter();

            while (kobold.hitPoints > 0)
            {
                Console.Clear();

                Console.WriteLine("***************************************************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("**(A)ttack*********************(I)nventory*********");
                Console.WriteLine("**(D)efend**********************(Analyze)*************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("***HitPoints: " + player.playerHealth + " *******Enemy Health: " + kobold.hitPoints + " ****************");

                string temp = Console.ReadLine();


                switch (temp.ToLower())
                {
                    case "a": 
                        int roll = DiceRolls.D20();
                        if (roll >= kobold.armorClass)
                        {
                            Print("You lunge at the foe dealing " + player.playerDamage + " damage to the snarling beast");
                            kobold.hitPoints -= player.playerDamage;
                            Console.WriteLine("Player Success: D20 rolled " + roll + " enemy Armor class was " + kobold.armorClass);

                            Console.ReadKey();
                        }
                        else
                        {
                            Print("The enemy dodges the blow and prepares an assault of it's own!");
                            Console.WriteLine("Player Failed Condition: D20 rolled " + roll + " enemy Armor class was " + kobold.hitPoints);
                            Console.ReadKey();
                        }

                        break;


                    case "d":
                        Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
                        kobold.hitPoints--;
                        Console.ReadKey();

                        break;

                    case "i":
                        Print("You scrounge your knapsack for anything that could turn the tide of battle");
                        player.AccessInventory(player);
                        Console.ReadKey();

                        break;

                    case "r":
                        Print("There is no escape!");
                        Console.ReadKey();
                        break;
                    
                    case "analyze":
                        kobold.DisplayEnemyInfo();
                        break;

                    default:
                        Print(temp + " is not a supported command");
                        Console.ReadKey();

                        break;
                }

                if (kobold.hitPoints > 0)
                {
                    int roll = DiceRolls.D20();
                    if (roll >= player.armorClass)
                    {
                        Random rng = new();
                        
                        if (rng.Next(0,2) == 0){
                        Print(kobold.attackOneDesc + " Dealing " + kobold.attackOneDamage + " damage!");
                        player.playerHealth -= kobold.attackOneDamage;
                        } 
                        else 
                        {
                        Print(kobold.attackTwoDesc + " Dealing " + kobold.attackTwoDamage + " damage!");
                        player.playerHealth -= kobold.attackTwoDamage;
                        }
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
            
            player.gold += kobold.gold;
            player.experience += kobold.experience;
            Print("You defeated the " + kobold.name + " and won your freedom");
            Print("You gained " + kobold.gold + " gold and " + kobold.experience + " experience");


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

      public static void MiniBoss(Player player)
      {
        
        Enemies zombie = Enemies.CreateZombieEncounter();
        zombie.hitPoints = DiceRolls.D8()+DiceRolls.D8()+DiceRolls.D8()+9; 

           while (zombie.hitPoints >= 0)
            {
                Console.Clear();

                Console.WriteLine("***************************************************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("**(A)ttack*********************(I)nventory*********");
                Console.WriteLine("**(D)efend**********************(Analyze)**********");
                Console.WriteLine("***************************************************");
                Console.WriteLine("***HitPoints: " + player.playerHealth + " ******* Enemy Health: " + zombie.hitPoints + " ****************");

                string temp = Console.ReadLine();


                switch (temp.ToLower())
                {
                    case "a": 
                    case "attack":
                        int roll = DiceRolls.D20();
                        if (roll >= zombie.armorClass)
                        {
                            Print("You lunge at the foe dealing " + player.playerDamage + " damage to the snarling beast");
                            zombie.hitPoints -= player.playerDamage;
                            Console.WriteLine("Player Success: D20 rolled " + roll + " enemy Armor class was " + zombie.armorClass);

                            Console.ReadKey();
                        }
                        else
                        {
                            Print("The enemy dodges the blow and prepares an assault of it's own!");
                            Console.WriteLine("Player Failed Condition: D20 rolled " + roll + " enemy Armor class was " + zombie.armorClass);
                            Console.ReadKey();
                        }

                        break;


                    case "d":
                    case "defend":
                        Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
                        zombie.hitPoints--;
                        Console.ReadKey();

                        break;
                    //Menus
                    case "analyze":
                        zombie.DisplayEnemyInfo();
                        break;
                    case "i":
                    case "inventory":
                        Print("You scrounge your knapsack for anything that could turn the tide of battle");
                        player.AccessInventory(player);
                        Console.ReadKey();

                        break;

                    case "r":
                    case "run":
                        Print("There is no escape!");
                        Console.ReadKey();
                        break;

                    default:
                        Print(temp + " is not a supported command");
                        Console.ReadKey();

                        break;
                }

                if (zombie.hitPoints > 0)
                {
                    int roll = DiceRolls.D20();
                    if (roll >= player.armorClass)
                    {
                        Random rng = new();
                        
                        if (rng.Next(0,2) == 0){
                        Print(zombie.attackOneDesc + " Dealing " + zombie.attackOneDamage + " damage!");
                        player.playerHealth -= zombie.attackOneDamage;
                        } 
                        else 
                        {
                            Print(zombie.attackTwoDesc + " Dealing " + zombie.attackTwoDamage + " damage!");
                        player.playerHealth -= zombie.attackTwoDamage;
                        }
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
            
            player.gold += zombie.gold;
            player.experience += zombie.experience;
            Print("You defeated the " + zombie.name + " and won your freedom");
            Print("You gained " + zombie.gold + " gold and " + zombie.experience + " experience");


            Console.Read();
      }

    public static void ChanceEncounter(Player player){
        var chanceRoll = DiceRolls.D20();
        if (chanceRoll <= 8){
            Print("An enemy appears!");
            
            
            Enemies enemy =  RandomEnemy();
 
        {
    
            while (enemy.hitPoints > 0 || player.playerHealth < 0)
            {
                Console.Clear();

                Console.WriteLine("***************************************************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("**(A)ttack*********************(I)nventory*********");
                Console.WriteLine("**(D)efend**********************(Analyze)*************");
                Console.WriteLine("***************************************************");
                Console.WriteLine("***HitPoints: " + player.playerHealth + " *******Enemy Health: " + enemy.hitPoints + " ****************");

                string temp = Console.ReadLine();


                switch (temp.ToLower())
                {
                    case "a": 
                    case "attack":
                        int roll = DiceRolls.D20();
                        if (roll >= enemy.armorClass)
                        {
                            Print("You lunge at the foe dealing " + player.playerDamage + " damage to the snarling beast");
                            enemy.hitPoints -= player.playerDamage;
                            Console.WriteLine("Player Success: D20 rolled " + roll + " enemy Armor class was " + enemy.armorClass);

                            Console.Read();
                        }
                        else
                        {
                            Print("The enemy dodges the blow and prepares an assault of it's own!");
                            Console.WriteLine("Player Failed Condition: D20 rolled " + roll + " enemy Armor class was " + enemy.armorClass);
                            Console.Read();
                        }

                        break;


                    case "d":
                    case "defend":
                        Print("You cautiously approach the enemy swiping cleanly as it closes the distance");
                        enemy.hitPoints--;
                        Console.Read();

                        break;
                    case "analyze":
                        enemy.DisplayEnemyInfo();
                        break;
                    case "i":
                    case "inventory":
                        Print("You scrounge your knapsack for anything that could turn the tide of battle");
                        player.AccessInventory(player);
                        Console.Read();

                        break;

                    case "r":
                    case "run":
                        Print("There is no escape!");
                        Console.Read();
                        break;

                    default:
                        Print(temp + " is not a supported command");
                        Console.Read();

                        break;
                }

                if (enemy.hitPoints > 0)
                {
                    int roll = DiceRolls.D20();
                    if (roll >= player.armorClass)
                    {
                        Random rng = new();
                        
                        if (rng.Next(0,2) == 0)
                        {
                        Print(enemy.attackOneDesc + " Dealing " + enemy.attackOneDamage + " damage!");
                        player.playerHealth -= enemy.attackOneDamage;
                        } 
                        else 
                        {
                        Print(enemy.attackTwoDesc + " Dealing " + enemy.attackTwoDamage + " damage!");
                        player.playerHealth -= enemy.attackTwoDamage;
                        }
                        Console.WriteLine("Enemy Success: D20 rolled " + roll + " player Armor class was" + player.armorClass);
                        Console.ReadKey();
                    }
                    else
                    {
                        Print("You deftly dodge the blow and ready your sword");
                        Console.WriteLine("Enemy Failed Condition: D20 rolled " + roll + " player Armor class was " + player.armorClass);

                        Console.Read();
                       

                    }
                    if (player.playerHealth <= 0)
                    {
                        Encounter.GameOver();
                    }
                }
            }
            
            player.gold += enemy.gold;
            player.experience += enemy.experience;
            Print("You defeated the "+ enemy.name + " and won your freedom!");
            Print("You gained " + enemy.gold + " gold and " + enemy.experience + " experience");


            Console.Read();

            
        }
        }
        else{
            Print("You proceed unhindered");
        }
    }
 public static Enemies RandomEnemy()
    {
        Random rng = new Random();
        var roll = rng.Next(0, 3);
        Enemies enemy;

    if(roll == 0){
        enemy = Enemies.CreateBowmanEncounter(); //  Bowman is a subclass of Enemies
    } else if (roll == 1){
        enemy = Enemies.CreateKoboldEncounter(); //  Kobold is a subclass of Enemies
    } else {
        enemy = Enemies.CreateGoblinEncounter(); //  Goblin is a subclass of Enemies
    }

    return enemy;
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
