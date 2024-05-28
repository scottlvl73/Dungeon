using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Player
    {
        public string playerName = "";
        public int playerHealth = 50;
        public int MaxHealth = 10;
        public int playerDamage = DiceRolls.D4() + 20;
        public int armorClass = 16;
        public int gold;
        public int experience;
        public int experienceMax = 100;
        public int playerLevel = 1;

        public List<InventoryItem> Inventory = [];

        public void AccessInventory(Player player)
        {
            foreach (var item in Inventory){
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.EffectString);
                Console.WriteLine($"You have: {item.Quantity}");
                
            }
            Console.WriteLine("Do you want to use a potion? (Y/N)");
            string playerInput = Console.ReadLine().ToLower();
                //if the player tries to use a potion and has one
                if (playerInput == "y" && player.Inventory.Contains(InventoryItem.potion)){
                    player.Use(InventoryItem.potion);
                //if inventory does not contain a potion
                }else if (playerInput == "y" && !player.Inventory.Contains(InventoryItem.potion)){
                    Console.WriteLine("You do not have a potion");

                }else if(playerInput == "n"){
                    
                }
                 else {
                    Console.WriteLine("I don't understand");
                }
            Console.Read();
        }
         public void Use(InventoryItem item)
    {
        if (Inventory.Contains(item))
        {
            //Applies item effect
            item.ApplyEffect(this);
            //Removes from Inventory
            Inventory.Remove(item);
        }
        
    } 
       
    }
   
}
