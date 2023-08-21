using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeletons
{
    public class EnemyManager: IEnumerable
    {
        public static readonly List<Skeleton> enemies = new();
        //private static readonly Random Rnd = new();
       

        static EnemyManager()
        {
            enemies.Add(new Skeleton());
            enemies.Add(new Skeleton(100, "standart", 1, 15, 33));
            enemies.Add(new Skeleton(150, 30, 40));
            enemies.Add(new Skeleton(150, 30, 30));
            
        }

        public static int Count() { return enemies.Count; }


        public static void SkeletonGetDamage(int playerDamage)  // Taking damage from player and checking skeleton health 
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].health -= playerDamage;
                if (enemies[i].health < 1)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }
        
        // public static int RandomBonusToSceletonDamage()  // Random bonus to skeleton damage
        // {
        //     return rnd.Next(1, 11);
        // }
        public static int DoDamage() // Overall (damage + bonus) skeleton damage 
        {
            int damageFromAll = 0;
            foreach (Skeleton skeleton in enemies)
                damageFromAll += skeleton.damage;
            return damageFromAll;
        }

        public static void Print(Skeleton skeleton)
        {
            Console.WriteLine(
                $"Skeleton: {enemies.IndexOf(skeleton) + 1}\n Health: {skeleton.health} \n" +
                $" Rarity: {skeleton.rarity} \n Level: {skeleton.level} \n Damage: {skeleton.damage} \n" +
                $" Armor: {skeleton.armor} \n"
                );
        }

        public IEnumerator GetEnumerator()
        {
            yield return new EnemyEnumerator(enemies);
        }

        



  
    }
        class EnemyEnumerator// : IEnumerator
        {
            private readonly List<Skeleton> _skeletons;
            private int _index = -1;
            public EnemyEnumerator(List<Skeleton> skeletons)
            {
                _skeletons = skeletons;
            }
            public bool MoveNext()
            {
                _index++;
                return _index < _skeletons.Count;
            }

            public void Reset()
            {
                _index = -1;
            }

            public object Current => _skeletons[_index];
        }
        
        
        
        
        


}
