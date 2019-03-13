using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public static class ADTExtensions
    {
        public static void ForEach<T>(this MyLinkedList<T> tList, Action<T> action)
        {
            foreach (T t in tList)
            {
                action(t);
            }
        }
    }
}
