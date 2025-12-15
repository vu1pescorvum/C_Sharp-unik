using System.Collections.Generic;
using System.Linq;

namespace MagicAcademyLab5
{
    
    public class Repository<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
        }

        public void Remove(T item)
        {
            _items.Remove(item);
        }

        
        public List<T> GetAll()
        {
            return _items.ToList();
        }
    }
}