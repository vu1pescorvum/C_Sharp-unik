using System;

namespace RpgLab
{
    
    public class Archer : Character, IAttackable
    {
        public int Agility { get; set; }
        public double CritChance { get; set; } // 0.0–1.0

        private static readonly Random random = new Random();

        public Archer(string name, int health, int agility, double critChance)
            : base(name, health)
        {
            Agility = agility;
            CritChance = critChance;
        }

        
        public void Attack(Character target)
        {
            if (target == null || !IsAlive)
                return;

            int damage = Agility;
            bool isCrit = random.NextDouble() < CritChance;

            if (isCrit)
            {
                damage *= 2;
                Console.WriteLine($"{Name} использует скилл 'Критический выстрел' по {target.Name} (-{damage} HP)");
            }
            else
            {
                Console.WriteLine($"{Name} использует скилл 'Точный выстрел' по {target.Name} (-{damage} HP)");
            }

            if (target is IDamageable dmg)
            {
                dmg.TakeDamage(damage);
                AddExperience(isCrit ? 30 : 15);
            }
        }

        
        public override void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} использует скилл 'Уклонение': следующий урон может быть значительно снижен.");
        }
    }
}