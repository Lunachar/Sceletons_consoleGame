namespace Skeletons;

public class Skeleton
{
    public int health = 100;
    public string rarity = "standart";
    public int level = 0;
    public int damage = 10;
    public int armor = 0;
    static Random rnd = new();

    #region Constructors
    public Skeleton() : this(rnd.Next(50, 150), rnd.Next(1, 11), 0) { }

    public Skeleton(int _health, string _rarity, int _level, int _damage, int _armor) 
    {
        health = _health;
        rarity = _rarity;
        level = _level;
        damage = _damage;
        armor = _armor;
    }

    public Skeleton(int _health, int _damage, int _armor)
    {
        health = _health;
                
        armor = _armor;

                
        level = rnd.Next(1, 21);

        if (level < 9)
        {
            rarity = "standart";
        }
        else if (level < 17)
        {
            rarity = "rare";
            damage = _damage + 5 + rnd.Next(1, 11);
        }
        else
        {
            rarity = "legend";
            damage = _damage + 10 + rnd.Next(1, 21);
        }
    }
    #endregion   

    public void Print(int count)
    {
        Console.WriteLine($"  Skeleton {count} \n Health: {health} \n Rarity: {rarity} \n" +
                          $" Level: {level} \n Damage + Attack: {EnemyManager.DoDamage()} \n Armor: {armor}");

        Console.ReadLine();
    }

}