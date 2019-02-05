using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Bag
{
    public int Capacity { get; private set; }

    public double Load
    {
        get
        {
            return 0 + Items.Sum(x => x.Weight);
        }
    }

    protected List<Item> Items { get; }

    protected Bag(int capacity)
    {
        this.Capacity = capacity;
        this.Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        if(this.Load + item.Weight > this.Capacity)
        {
            throw new InvalidOperationException("Bag is full!");
        }

        this.Items.Add(item);
    }

    public Item GetItem(string name)
    {
        if(this.Items.Count == 0)
        {
            throw new InvalidOperationException("Bag is empty!");
        }

        Item item = Items.FirstOrDefault(i => i.GetType().Name == name);

        if (item == null)
        {
            throw new ArgumentException($"No item with name {name} in bag!");
        }

        this.Items.Remove(item);

        return item;
    }
}

