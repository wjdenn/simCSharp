using simLife.Character;
using simLife.NameBuilder;
class Program{
    static List<NewCharacter> worldCharacters = new();
    public static void Main()
    {
        int maxCharacterCount = 5;
        int characterCount = 0;

        //Populate the world
        while(characterCount < maxCharacterCount){
            var (adjective, name) = NameBuilder.GenerateName();
            CreateCharacter(adjective, name);
            characterCount += 1;
        }

        //Simulate the world, hunger drain
        while (true)
        {
            foreach (var character in worldCharacters)
            {
                character.Tick();
                character.PrintStats();
            }
            Thread.Sleep(2000);
        }
    }
    public static void CreateCharacter(string adjective, string name)
    {
        Console.WriteLine("Creating new character...");
        var character = new NewCharacter
        {
            Name = $"{adjective} {name}",
            Health = 100,
            Hunger = 100,
            Wealth = 100,
        };
        worldCharacters.Add(character);
        character.PrintStats();
    }
}