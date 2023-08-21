namespace Skeletons;

public static class weaponManager // That class has a RandomWeapon method
                                  // that returns a random Weapon object
                                  // of either a MeleeWeapon, RangedWeapon, or MagicWeapon type
                                  // with a random rarity assigned to it.
{
    private static readonly Random Rnd = new();

    public static Weapon RandomWeapon()
    {
        Weapon[] weapon =
        {
            new MeleeWeapon(SettingRarity.Rarity()),
            new RangedWeapon(SettingRarity.Rarity()), 
            new MagicWeapon(SettingRarity.Rarity())
        };
        
        return weapon[Rnd.Next(0, 3)];
    }
}

