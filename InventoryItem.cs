namespace Dungeon{
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

    
}


}