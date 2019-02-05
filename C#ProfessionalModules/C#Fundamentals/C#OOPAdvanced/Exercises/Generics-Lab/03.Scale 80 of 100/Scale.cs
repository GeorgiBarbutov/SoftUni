using System;

public class Scale<T>
    where T : IComparable
{
    public T Left { get; }
    public T Right { get; }

    public Scale(T left, T right)
    {
        this.Left = left;
        this.Right = right;
    }

    public T GetHeavier()
    {
        if(this.Left.CompareTo(this.Right) == 1)
        {
            return this.Left;
        }
        else if (this.Left.CompareTo(this.Right) == -1)
        {
            return this.Right;
        }
        else
        {
            return default(T);
        }

    }
}

