using System;

namespace RpgLab
{
    
    public class Warrior : Character, IAttackable
    {
        public int Strength { get; set; }

        public Warrior(string name, int health, int strength)
            : base(name, health)
        {
            Strength = strength;
        }

        
        public void Attack(Character target)
        {
            if (target == null || !IsAlive)
                return;

            int damage = Strength;
            Console.WriteLine($"{Name} использует скилл 'Сильный удар мечом' по {target.Name} (-{damage} HP)");

            if (target is IDamageable dmg)
            {
                dmg.TakeDamage(damage);
                AddExperience(20);
            }
        }

        
        public override void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} использует скилл 'Боевая стойка': следующий урон будет значительно уменьшен.");
        }
    }
}