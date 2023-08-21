namespace Skeletons;

public class Sceleton2 // This is a class representing a Sceleton with its properties
                       // including health, rarity, armor, weapon and attack state.
{
    private int health;
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health < 1)
            {
                isDead = true;
            }
            else
            {
                isDead = false;
            }
        }
    }
    public string Rarity = "standart";
    public int Armor = 0;
    public Weapon weapon;
    public bool isDead;
    
    private static readonly Random Rnd = new();
    
    public Sceleton2(/*int health,*/ string rarity /*,int armor, Weapon weapon*/)
    {
        Rarity = rarity;
        
        if (rarity == "standart")
        {
            Health = Rnd.Next(30, 51);
            Armor = Rnd.Next(5,11);
        }
        else if (rarity == "rare")
        {
            Health = Rnd.Next(45, 71);
            Armor = Rnd.Next(11,21);
        }
        else if (rarity == "legend")
        {
            Health = Rnd.Next(65, 101);
            Armor = Rnd.Next(21,31);
        }
        else
        {
            throw new NotImplementedException("Sceleton rarity error");
        }
        weapon = GenerateWeapon();
    }

    public string Attack()
    {
        int isAttacking = Rnd.Next(0, 2);
        
        return isAttacking==1 ? "attacking": "not attacking";
    }

    public void GetDamage()
    {
        
    }
    public Weapon GenerateWeapon()
    {
        return weaponManager.RandomWeapon();
    }

    public override string ToString()
    {
        return $"| Skeleton {(weapon.Id == 1 ? "melee warrior" : "ranged warrior")}\n| health: {Health}, rarity: {Rarity}, armor: {Armor}\n| {weapon}, " +
               $"\n| attack state: {Attack()}";
    }
}