namespace Skeletons;

public class BonusMenu  // That class displays a menu of three different bonus options
                        // and an option to skip, which can be chosen once per game.
{
    public static string MenuDisplay(PlayerForGame superPlayer)
    {
        return "You can choose one bonus. Remember it`s once a game.\n" +
              $"1. Increase {superPlayer.Name}`s damage twice for next turn.\n" +
              $"2. Decrease most healthiest sceleton health for half. \n" +
              $"3. Increase {superPlayer.Name}`s health +100.\n" +
              $"or just press Enter";
    }
}