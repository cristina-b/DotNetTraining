using System;
using System.Collections.Generic;

namespace DotNet3
{    
    class MyList<T>
    {
        T[] value;
        public void Add(T[] t)
        {
            value = t;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T t in value)
                yield return t;
        }
    }
}
