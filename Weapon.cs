namespace Skeletons;

public abstract class Weapon  // Weapon system
                              // consisting of an abstract Weapon class and three subclasses -
                              // MeleeWeapon, RangedWeapon, and MagicWeapon,
                              // each with their own properties and ToString methods.
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public string Rarity { get; set; }
    
    public int Id = 2;
    
    public Weapon(string _rarity, int _id)
    {
        Rarity = _rarity;
        Id = _id;
    }
    public override string ToString()
    {
        return $"Weapon: {Name}, rarity: {Rarity}, damage: {Damage}";
    }
}

public class MeleeWeapon : Weapon
{
   private int CritChance{ get; }
   private int CritDamage{ get; }
   private static int id = 1;
   private static readonly Random Rnd = new();
   
   public MeleeWeapon(string rarity)
        : base(rarity, id)
   {
       Name = Rnd.Next(0, 2) == 1 ? "spear" : "stick";
       
       if (rarity=="standart")
       {
           Damage = Rnd.Next(10, 21);
           CritChance = Rnd.Next(0, 21);
           CritDamage = Rnd.Next(5, 11);
       }
       else if (rarity=="rare")
       {
           Damage = Rnd.Next(21, 36);
           CritChance = Rnd.Next(21, 61);
           CritDamage = Rnd.Next(11, 21);
       }
       else if (rarity=="legend")
       {
           Damage = Rnd.Next(36, 51);
           CritChance = Rnd.Next(61, 101);
           CritDamage = Rnd.Next(21, 31);
       }
       else
       {
           throw new NotImplementedException("Data Error");
       }
   }
   public override string ToString()
   {
       ColorDependingOnRarity.GetColorForRarity(Rarity);
       return $"Weapon: {Name}, rarity: {Rarity}, damage: {Damage},\n| critChance: {CritChance}, " +
              $"critDamage: {CritDamage}";
   }
}
public class RangedWeapon : Weapon
{
    public int AttackDistance{ get; }
    public static int id = 2;
    private static readonly Random Rnd = new();
    
    public RangedWeapon(string rarity)
        : base(rarity, id)
    {
        Name = Rnd.Next(0, 2) == 1 ? "bow" : "stone";
       
        if (rarity=="standart")
        {
            Damage = Rnd.Next(10, 21);
            AttackDistance = Rnd.Next(10, 21);
        }
        else if (rarity=="rare")
        {
            Damage = Rnd.Next(21, 36);
            AttackDistance = Rnd.Next(21, 31);
        }
        else if (rarity=="legend")
        {
            Damage = Rnd.Next(36, 51);
            AttackDistance = Rnd.Next(31, 41);
        }
        else
        {
            throw new NotImplementedException("Data Error");
        }
    }
    
    public override string ToString()
    {
        ColorDependingOnRarity.GetColorForRarity(Rarity);
        return $"Weapon: {Name}, rarity: {Rarity}, damage: {Damage},\n| attack distance: {AttackDistance}";
    }
}

public class MagicWeapon : Weapon
{
    public static int id = 3;
    private static readonly Random Rnd = new();
    public int HealthBonus = 0;
    public int ArmorBonus = 0;
    
    public MagicWeapon(string rarity)
        : base(rarity, id)
    {
        Name = Rnd.Next(0, 4) == 0 ? "armor bonus" : "first aid kit";
        
        if (rarity=="standart")
        {
            HealthBonus = 30;
            ArmorBonus = 10;
        }
        else if (rarity=="rare")
        {
            HealthBonus = 50;
            ArmorBonus = 20;
        }
        else if (rarity=="legend")
        {
            HealthBonus = Rnd.Next(56, 81);
            ArmorBonus = Rnd.Next(31, 41);
        }
        else
        {
            throw new NotImplementedException("Data Error");
        }
    }

    public override string ToString()
    {
        string toReturn;
        if (Name == "first aid kit")
        {
            ColorDependingOnRarity.GetColorForRarity(Rarity);
            toReturn = $"Weapon: {Name}, rarity: {Rarity}, Health Bonus: {HealthBonus}";

        }
        else
        {
            ColorDependingOnRarity.GetColorForRarity(Rarity);
            toReturn = $"Weapon: {Name}, rarity: {Rarity}, Armor Bonus: {ArmorBonus}";
        }
        
        return toReturn;
    }
    
    public void ApplyHealthBonus(Sceleton2 scel)
    {
        scel.Health += HealthBonus;
    }
}