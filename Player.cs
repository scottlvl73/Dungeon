using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon
{
    public class Player
    {
        public string? playerName = "";
        public int playerHealth = 10;
        public int playerLevel = 1;
        public int playerDamage = DiceRolls.D4() + 3;
        public int armorClass = 16;
        public int gold;
        public int experience;

        public List<InventoryItem> Inventory = new List<InventoryItem>();

        public void AccessInventory()
        {
            foreach (var item in Inventory){
                Console.WriteLine(item.Name);
                Console.WriteLine(item.Description);
                Console.WriteLine(item.Effect);
                Console.WriteLine($"You have: {item.Quantity}");
                Console.ReadKey();
            }
        }
    }
   
}
