
namespace MagicAcademyLab
{
    class Spell
    {
        public string Name { get; set; }
        public string Element { get; set; }      
        public int ManaCost { get; set; }        
        public int LevelRequired { get; set; }   

        public override string ToString()
        {
            return $"{Name} | Елемент: {Element}, Мана: {ManaCost}, Рiвень: {LevelRequired}";
        }
    }
}