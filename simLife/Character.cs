using simLife.Items;
using System.Linq;
namespace simLife.Character;

public class NewCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Hunger { get; set; }
    public int Wealth { get; set; }
    public Dictionary<Item, int> Inventory { get; set; } = new();

    public void PrintStats()
    {
        Console.WriteLine($"Character is {Name}");
        Console.WriteLine($"Character has {Health} health");
        Console.WriteLine($"Character has {Hunger} hunger");
        Console.WriteLine($"Character has {Wealth} wealth");
        Console.WriteLine($"Character has the following Inventory:");
        foreach (var entry in Inventory)
        {
            Console.WriteLine($"{entry.Key.Name} x{entry.Value}");
        }
    }
    private void DrainHunger()
    {
        Hunger -= 5;
        if (Hunger <= 0)
        {
            Hunger = 0;
            Health -=10;
        }
    }
    private void SeekFood()
    {
        Console.WriteLine($"{Name} is looking for food...");

        var foodItem = Inventory
            .FirstOrDefault(entry => entry.Key.Type == ItemType.Food && entry.Value > 0);

        if (foodItem.Key != null)
        {
            Eat(foodItem.Key);
        }
        else
        {
            Console.WriteLine($"{Name} has no food!");
        }
    }
    private void CheckHunger()
    {
        if (Hunger < 30)
        {
            SeekFood();
        }
    }
    private void Eat(Item item)
    {
        Console.WriteLine($"{Name} eats {item.Name}");

        Hunger += item.Nutrition;
        if (Hunger > 100)
            Hunger = 100;

        Inventory[item]--;

        if (Inventory[item] <= 0)
            Inventory.Remove(item);
    }
    public void AddItem(Item item)
    {
        Inventory[item] = Inventory.GetValueOrDefault(item) + 1;
    }
    public void RemoveItem(Item item)
    {
        Inventory[item] = Inventory.GetValueOrDefault(item) - 1;
    }
    public void Tick()
    {
        DrainHunger();
        CheckHunger();
    }
}
