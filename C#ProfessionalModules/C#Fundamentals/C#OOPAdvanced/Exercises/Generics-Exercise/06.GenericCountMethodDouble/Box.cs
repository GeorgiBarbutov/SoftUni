using System;
using System.Collections.Generic;

public class Box<T>
    where T : IComparable
{
    public T Data { get; private set; }

    public Box(T data)
    {
        this.Data = data;
    }

    public int Count(ICollection<T> list, T element)
    {
        int count = 0;

        foreach (var item in list)
        {
            if (item.CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}

