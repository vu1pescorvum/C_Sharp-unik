
namespace MagicAcademyLab
{
    class Mage
    {
        public string Name { get; set; }
        public string Rank { get; set; }            
        public string Specialization { get; set; }  

        public override string ToString()
        {
            return $"{Name} | Ранг: {Rank}, Спецiалiзацiя: {Specialization}";
        }
    }
}