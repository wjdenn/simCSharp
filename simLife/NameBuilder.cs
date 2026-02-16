namespace simLife.NameBuilder;

public class NameBuilder
{
    private static Random rnd = new();
    public static (string adjective, string name) GenerateName()
    {
        string[] adjectives = ["Able", "Adept", "Acclaimed", "Adorable", "Amused", "Apt"];
        string[] names = ["Arthur", "Andy", "Alfalfa", "Adolf", "Amy", "Amelia"];

        int adjectivesNum = rnd.Next(0, 5);
        int namesNum = rnd.Next(0,5);

        return (adjectives[adjectivesNum], names[namesNum]);
    }
}