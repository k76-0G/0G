using System.Collections.Generic;

namespace _0G
{
    public static class ExtensionMethods
    {
        public static void Shift<T>(this List<T> list, T item, int indexDelta)
        {
            int index = list.IndexOf(item);
            list.RemoveAt(index);
            list.Insert(index + indexDelta, item);
        }
    }
}