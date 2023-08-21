namespace Skeletons;

public class ColorDependingOnRarity  // sets the console foreground color based on a string rarity input.
{
    public static void GetColorForRarity(string rarity)
    {
        switch (rarity)
        {
            case "standart":
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case "rare":
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            case "legend":
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Gray;
                break;
        }
    }
}