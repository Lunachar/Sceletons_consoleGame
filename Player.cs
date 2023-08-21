using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeletons
{

    public class Player
    {
        private readonly Random rnd = new Random();
        public int health;

        public Player()
        {            
            health = 1000;            
        }

        public int Damage()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            return rnd.Next(10, 21);            
        }

        public void PlayerGetDamage(int skeletonsDamage) // Player take damege from all skeletons
        {
            health -= skeletonsDamage;
        }

        public void Print()
        {
            Console.WriteLine($"-== Player health: {health} ==- \n == Damage: {Damage()}==");
        }

    }
}
