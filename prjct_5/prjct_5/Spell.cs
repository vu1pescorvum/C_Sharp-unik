using System;

namespace MagicAcademyLab5
{
    public class Spell
    {
       
        public string Name { get; set; }

        
        public string Element { get; set; }

        
        public int ManaCost { get; set; }

        
        public int Power { get; set; }

        
        public bool IsUltimate { get; set; }

        public override string ToString()
        {
            string ultimateText = IsUltimate ? "так" : "нi";
            return $"{Name} [{Element}] | Mana: {ManaCost}, Power: {Power}, Ultimate: {ultimateText}";
        }
    }
}