using System.Security.Cryptography.X509Certificates;

namespace simLife.Character;

public class NewCharacter
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Hunger { get; set; }

    public void PrintStats()
    {
        Console.WriteLine($"Character is {Name}");
        Console.WriteLine($"Character has {Health} health");
        Console.WriteLine($"Character has {Hunger} hunger");
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
    }
    private void CheckHunger()
    {
        if (Hunger < 30)
        {
            SeekFood();
        }
    }
    public void Tick()
    {
        DrainHunger();
        CheckHunger();
    }
}
