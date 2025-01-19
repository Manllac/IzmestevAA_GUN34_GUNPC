using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace UnitWeapon
{
    public class Weapon
    {
        private float _durability = 1;

        public string Name {  get; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set;}
        public float Durability => _durability;

        public Weapon (string name)
        {
            Name = name;
        }

        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
            SetDamageParams(minDamage, maxDamage);
        }

        public void SetDamageParams (int minDamage, int maxDamage)
        {
            if ( minDamage > maxDamage)
            {
                (minDamage, maxDamage) = (maxDamage, minDamage);
                Console.WriteLine("Некорректные входные данные \"{Name}\" ");
            }

            if( minDamage<1)
            {
                minDamage = 1;
                Console.WriteLine("Для оружия \"{Name}\" выставлен минимальный урон 1");
            }

            if( maxDamage<=1)
            {
                maxDamage = 10;
                Console.WriteLine("Для оружия \"{Name}\" выставлен максимальный урон 10");
            }
            minDamage =MinDamage; 
            maxDamage =MaxDamage;
        }

        public int GetDamage ()
        {
            return ((MinDamage + MaxDamage)/2);
        }
       
    }
}
