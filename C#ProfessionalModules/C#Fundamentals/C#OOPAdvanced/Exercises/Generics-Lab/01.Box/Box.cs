using System.Collections.Generic;

public class Box<T>
{
    private IList<T> List { get; }
    public int Count => this.List.Count;

    public Box()
    {
        this.List = new List<T>();
    }

    public void Add(T element)
    {
        this.List.Add(element);
    }
    public T Remove()
    {
        T element = this.List[this.List.Count - 1];
        this.List.RemoveAt(this.List.Count - 1);

        return element;
    }

    
}

