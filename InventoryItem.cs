namespace Dungeon
{
public class InventoryItem

{
    public string Name { get;}
    public int Quantity { get; set;}
    public string Description { get;}
    public string EffectString { get;}

    public int Effect { get; set;}
    public static InventoryItem skull = new(name: "Skull", quantity: 1, description: "A weathered skull", effectString: "Unknown", effect: 1);
    public static InventoryItem necklace = new(name:"Necklace",quantity: 1,description: "A necklace you awoke with", effectString: "It has no effect", effect: 1);
    
    public static InventoryItem potion = new(name:"Potion", quantity: 1, description: "A small vial containing healing liquid", effectString:"Heals to full", effect: 10);


    public InventoryItem(string name, int quantity, string description, string effectString, int effect)
    {
        Name = name;
        Quantity = quantity;
        Description = description;
        EffectString = effectString;
        Effect = effect;

        
    }

  
   
    
    public void ApplyEffect(Player player)
    {
    // Check if the player's health is not already at max
        if (player.playerHealth < player.MaxHealth)
        {
            // Apply the effect to the player, e.g., healing
            player.playerHealth += 100; 
            // Ensure player's health does not exceed max health
            player.playerHealth = Math.Min(player.playerHealth, player.MaxHealth);
        }
        else
        {
            // Handle the case when the player's health is already at max
            Console.WriteLine("Your already at full health");
            
        }
    }

    }

}