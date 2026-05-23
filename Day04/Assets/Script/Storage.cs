using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script
{
    public class Storage<T> where T : class
    {
        protected List<T> items = new List<T>();
        
        public int Count => items.Count;
        public void Save(T item)
        {
            items.Add(item);
        }

        public T Load()
        {
            if(items.Count == 0)
            { 
                return null;
            }
            T item = items[0];
            items.RemoveAt(0);
            return item;
        }

    }
}
