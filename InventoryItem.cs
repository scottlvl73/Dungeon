namespace Dungeon
{
public class InventoryItem

{
    public string Name { get;}
    public int Quantity { get; set;}
    public string Description { get;}
    public string Effect { get;}

    public InventoryItem(string name, int quantity, string description, string effect)
    {
        Name = name;
        Quantity = quantity;
        Description = description;
        Effect = effect;
        
    }

   public void Use()
    {
        Console.WriteLine($"You use the {Name}: {Effect}");
       
    } 
    public static InventoryItem skull = new(name: "Skull", quantity: 1, description: "A weathered skull", effect: "Unknown");
    public static InventoryItem necklace = new(name:"Necklace",quantity: 1,description: "A necklace you awoke with",effect: "It has no effect");
    
    public static InventoryItem potion = new(name:"Potion", quantity: 1, description: "A small vial containing healing liquid", effect:"Heals to full");
}

}