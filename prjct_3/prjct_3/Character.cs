using System;

namespace RpgLab
{
    
    public class Character : IDamageable
    {
        
        public string Name { get; set; }

        
        protected int Health;

        
        private int experience;

        
        protected bool IsDefending { get; set; }

        public int Level { get; protected set; }

        public bool IsAlive => Health > 0;

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
            Level = 1;
            experience = 0;
            IsDefending = false;
        }

        protected void AddExperience(int amount)
        {
            if (amount < 0)
                return;

            experience += amount;

            if (experience >= 100)
            {
                Level++;
                experience = 0;
                Console.WriteLine($"{Name} повышаeт уровень! Теперь уровень: {Level}");
            }
        }

        
        public virtual void Defend()
        {
            IsDefending = true;
            Console.WriteLine($"{Name} переходит в защиту. Следующий урон будет уменьшен.");
        }

        
        public void TakeDamage(int amount)
        {
            if (amount < 0)
                return;

            int finalDamage = amount;

            if (IsDefending)
            {
                finalDamage = amount / 2;
                Console.WriteLine($"{Name} защищается, урон уменьшен с {amount} до {finalDamage}");
                IsDefending = false;
            }

            Health -= finalDamage;
            if (Health < 0)
                Health = 0;

            Console.WriteLine($"{Name} получает {finalDamage} урона. Текущий HP: {Health}");

            if (!IsAlive)
            {
                Console.WriteLine($"{Name} погиб.");
            }
        }

        public override string ToString()
        {
            return $"{Name} (HP: {Health}, LvL: {Level})";
        }
    }
}
