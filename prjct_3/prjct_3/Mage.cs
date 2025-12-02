using System;

namespace RpgLab
{
    
    public class Mage : Character, IAttackable
    {
        public int Mana { get; set; }
        public int SpellPower { get; set; }

        public Mage(string name, int health, int mana, int spellPower)
            : base(name, health)
        {
            Mana = mana;
            SpellPower = spellPower;
        }

        
        public void Attack(Character target)
        {
            if (target == null || !IsAlive)
                return;

            const int spellCost = 10;

            if (Mana < spellCost)
            {
                Console.WriteLine($"{Name} не может использовать 'Файербол' — недостаточно маны! (Мана: {Mana})");
                return;
            }

            Mana -= spellCost;
            int damage = SpellPower + 5;

            Console.WriteLine($"{Name} использует скилл 'Файербол' по {target.Name} (-{damage} HP, мана теперь: {Mana})");

            if (target is IDamageable dmg)
            {
                dmg.TakeDamage(damage);
                AddExperience(25);
            }
        }

        
        public override void Defend()
        {
            IsDefending = true;
            Mana += 5;
            Console.WriteLine($"{Name} использует скилл 'Магический щит': следующий урон уменьшится, мана +5 (Мана: {Mana})");
        }
    }
}