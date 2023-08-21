namespace Skeletons;

public static class BonusController  // is a static class that controls the selection
                                     // and usage of bonuses in a game, keeping track of
                                     // whether a bonus has been used or not.
{
    public static bool BonusUsed;
    private static int _bonusSelect = 0;

    public static int BonusSelect
    {
        get { return _bonusSelect; }
        set { _bonusSelect = (value != 0 && BonusUsed) ? 0 : value; }
    }
}