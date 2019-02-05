using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CustomList<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private T[] data;

    public CustomList()
    {
        this.data = new T[4];
    }

    public void Add(T element)
    {
        if (this.Count == this.Capacity)
        {
            IncreaseCapacity();
        }

        this.data[this.Count] = element;
        this.Count++;
    }
    public T Remove(int index)
    {
        T element = data[index];

        for (int i = index; i < this.Count; i++)
        {
            this.data[i] = this.data[i + 1];
        }
        this.data[this.Count] = default(T);

        this.Count--;

        return element;
    }
    public bool Contains(T element)
    {
        bool isContained = false;

        for (int i = 0; i < this.Count; i++)
        {
            if(this.data[i].CompareTo(element) == 0)
            {
                isContained = true;
                break;
            }
        }

        return isContained;
    }
    public void Swap(int index1, int index2)
    {
        T temp = this.data[index1];
        this.data[index1] = this.data[index2];
        this.data[index2] = temp;
    }
    public int CountGreaterThan(T element)
    {
        int count = 0;

        for (int i = 0; i < this.Count; i++)
        {
            if(this.data[i].CompareTo(element) == 1)
            {
                count++;
            }
        }

        return count;
    }
    public T Max()
    {
        T max = this.data[0];

        for (int i = 0; i < this.Count; i++)
        {
            if(this.data[i].CompareTo(max) == 1)
            {
                max = this.data[i];
            }
        }

        return max;
    }
    public T Min()
    {
        T min = this.data[0];

        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].CompareTo(min) == -1)
            {
                min = this.data[i];
            }
        }

        return min;
    }
    public void Sort()
    {
        this.data = this.data.Where(x => x != null).OrderBy(x => x).ToArray();
    }
    private void IncreaseCapacity()
    {
        T[] newData = new T[this.Capacity * 2];

        Array.Copy(this.data, newData, this.Count);

        this.data = newData;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.data[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable<T>)data).GetEnumerator();
    }

    //public override string ToString()
    //{
    //    StringBuilder stringBuilder = new StringBuilder();

    //    for (int i = 0; i < this.Count; i++)
    //    {
    //        stringBuilder.Append(this.data[i] + Environment.NewLine);
    //    }

    //    foreach (var item in data)
    //    {
    //        stringBuilder.Append(item + Environment.NewLine);
    //    }

    //    return stringBuilder.ToString();
    //}

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            return this.data[index];
        }
        set
        {
            this.data[index] = value;
        }
    }

    public int Capacity => this.data.Length;
}

