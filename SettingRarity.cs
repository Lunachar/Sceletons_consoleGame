namespace Skeletons;

public class SettingRarity // generates a random rarity level from a predefined list of rarity levels.
{
    private static readonly Random Rnd = new();
    
    public static string Rarity()
    {
        string[] chooseRarity = {"standart", "rare", "legend"};
        string chosenRarity = chooseRarity[Rnd.Next(0, chooseRarity.Length)];
        return chosenRarity;
    }
}