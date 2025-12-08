using System.Collections.Generic;

namespace MagicAcademyLab
{
    
    class Repository<T>
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public List<T> GetAll()
        {
            
            return new List<T>(items);
        }
    }
}