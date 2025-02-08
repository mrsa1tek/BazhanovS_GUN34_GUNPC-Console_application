using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
    public class Unit
    {
        private float _health;
        private float _armor;
        private int _damage;
        public string Name { get; }
        public float Health => _health;
        public int Damage => _damage;
        public float Armor
        {
            get { return (float)Math.Round(_armor, 2); }
            set
            {
                if (value >= 0 || value <= 1)
                {
                    _armor = value;
                }
                else { }
            }
        }

        public Unit() : this("Unknown Unit")
        {

        }

        public Unit(string name)
        {
            Name = name;
            _damage = 5;
            _armor = 0.6f;
        }


        public float GetRealHealth()
        {
            return _health * (1f + _armor);
        }

        /// <summary>
        /// Получить урон
        /// </summary>
        /// <returns> true - юнит погиб, false - юнит жив;</returns>
        public bool SetDamage(float value)
        {
            _health -= value * (1 - _armor);
            return _health <= 0f;
        }
    }
    public class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; private set; }
        public int MaxDamage { get; private set; }
        public float Durability { get; }

        public Weapon(string name)
        {
            Name = name;
            Durability = 1f;
        }
        public Weapon(string name, int minDamage, int maxDamage) : this(name)
        {
        
            SetDamageParams(minDamage, maxDamage);
        }

        private void SetDamageParams(int minDamage, int maxDamage)
        {
            if (minDamage > maxDamage)
            {
                int temp = minDamage;
                minDamage = maxDamage;
                maxDamage = temp;
                Console.WriteLine($"Incorrect input data for the weapon '{Name}'. The Min Damage was set to MaxDamage.");
            }

            if (minDamage < 1)
            {
                MinDamage = 1;
                Console.WriteLine($"For the weapon '{Name}', the minimum damage has been set to a forced value: '{MinDamage}'");
            }
            else
            {
                MinDamage = minDamage;
            }
            MaxDamage = minDamage <= 1 ? 10 : MaxDamage;
        }
        private int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }
    }
}
