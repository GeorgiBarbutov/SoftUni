using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> data;
    private int index;

    public ListyIterator(T[] elements)
    {
        this.data = elements;
        this.index = 0;
    }

    public bool Move()
    {
        if(this.index == this.data.Count - 1)
        {
            return false;
        }
        else
        {
            this.index++;
            return true;
        }
    }

    public bool HasNext()
    {
        if (this.index == this.data.Count - 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Print()
    {
        if(this.data.Count == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        else
        {
            Console.WriteLine(this.data[this.index]);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < data.Count; i++)
        {
            yield return data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

