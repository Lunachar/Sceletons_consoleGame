namespace Skeletons;

public class EndGameConsoleMessage // generates a console message
                                   // based on the game results including the player and enemy health,
                                   // number of enemies, and number of turns.
{
    public EndGameConsoleMessage(PlayerForGame superPlayer, Sceleton2Manager sceletonsForGame, int turns)
    {
        
    
        string separatorShort = new string('=', 27);
        
        if (sceletonsForGame._sceletons.Count < 1 && superPlayer.Health > 0 && turns > 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(separatorShort);
            Console.WriteLine($"| Player health: {superPlayer.Health.ToString(), 3}      |");
            Console.WriteLine($"| Number of enemies: {sceletonsForGame._sceletons.Count.ToString(), 2}   |");
            Console.WriteLine($"| Player win in {turns.ToString(), 3} turns.|");
            Console.WriteLine(separatorShort + "\n");
            Console.ResetColor();
            Console.ReadLine();
        }
        else if (sceletonsForGame._sceletons.Count > 0 && superPlayer.Health < 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(separatorShort);
            Console.WriteLine($"| Player health: {superPlayer.Health.ToString(), 3}      |");
            Console.WriteLine($"| Number of enemies: {sceletonsForGame._sceletons.Count.ToString(), 2}   |");
            Console.WriteLine($"| Enemy win in {turns.ToString(), 3} turns. |");
            Console.WriteLine(separatorShort + "\n");
            Console.ResetColor();
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine(separatorShort);
            Console.WriteLine($"| Player health: {superPlayer.Health.ToString(), 3}      |");
            Console.WriteLine($"| Number of enemies: {sceletonsForGame._sceletons.Count.ToString(), 2}   |");
            Console.WriteLine($"| All died in {turns.ToString(), 3} turns.  |");
            Console.WriteLine(separatorShort + "\n");
        }
    }
}