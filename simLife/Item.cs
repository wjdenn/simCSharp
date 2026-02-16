namespace simLife.Items;

public enum ItemType
{
    Food,
    Weapon,
    Tool
};
public record Item(string Name, ItemType Type, int Value, int Nutrition);
