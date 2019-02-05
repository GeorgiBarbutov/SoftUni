using System;
using System.Collections;
using System.Collections.Generic;

public class Stack<T> : IEnumerable<T>
{
    private T[] data;

    public Stack()
    {
        this.data = new T[4];
        this.Count = 0;
    }

    public void Push(params T[] elements)
    { 
        foreach (var element in elements)
        {
            if(this.Capacity == this.Count)
            {
                IncreaseCapacity();
            }

            this.data[this.Count] = element;
            this.Count++;
        }
    }

    public T Pop()
    {
        if(this.Count == 0)
        {
            throw new IndexOutOfRangeException("No elements");
        }

        T popedElement = this.data[this.Count - 1];

        this.data[this.Count - 1] = default(T);
        this.Count--;

        return popedElement;
    }

    private void IncreaseCapacity()
    {
        T[] newData = new T[this.Capacity * 2];
        Array.Copy(this.data, newData, this.Capacity);

        this.data = newData;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Count - 1; i >= 0; i--)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count { get; private set; }
    private int Capacity => data.Length;
}

