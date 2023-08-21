namespace Skeletons;

public class PlayerForGame // defines a class for a player in a game
                           // that randomly generates the player's name,
                           // health, and weapon with associated stats,
                           // and allows the player's damage to be reset.
{
    public event Action OnPlayerDeath;
    public string Name;
    private int _health;

    public int Health
    {
        get => _health;
        set
        {
            _health = value;
            if (_health <= 0)
            {
                OnPlayerDeath?.Invoke();
            }
        }
    }
    public Weapon weapon;
    private int initialDamage;

    private static readonly Random Rand = new();
    

    public PlayerForGame()
    {
        Name = PlayerName();
        Health = Rand.Next(500, 1001);
        weapon = WeaponRandomSelect();
    }

    private string PlayerName()
    { 
        string[] NameFirstPart = {"Da", "Po", "Mi"}; 
        string[] NameSecondPart = {"nk", "nn", "ro"};
        
        int randomOne = Rand.Next(0, 3);
        int randomTwo = Rand.Next(0, 3);
        
        Name = String.Concat(NameFirstPart[randomOne], NameSecondPart[randomTwo]);
        return Name;
    }

    private Weapon WeaponRandomSelect()
    {
        weapon = Rand.Next(0,2) == 1 ? new MeleeWeapon(SettingRarity.Rarity()): new RangedWeapon(SettingRarity.Rarity());
        initialDamage = weapon.Damage; // saving the initial value of damage
        return weapon;
    }

    public void ResetDamage()
    {
        weapon.Damage = initialDamage;
    }

    public void PlayerDeathDelegate()
    {
            Console.WriteLine("Player die");
    }

    public override string ToString()
    {
        ColorDependingOnRarity.GetColorForRarity(weapon.Rarity);
        return $"| Player {Name} with a {weapon.Name} in his hand has {Health} health point.\n" +
               $"| Weapon stats\n" +
               $"| Rarity: {weapon.Rarity}\n" +
               $"| Damage: {weapon.Damage}";
    }
}