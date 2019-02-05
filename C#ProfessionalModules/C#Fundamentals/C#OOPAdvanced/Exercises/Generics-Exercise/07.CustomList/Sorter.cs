using System;
using System.Linq;

public class Sorter<T>
    where T : IComparable<T>
{
    public static T[] Sort(T[] array)
    {
        return array.Where(x => x != null).OrderBy(x => x).ToArray();
    }
}

