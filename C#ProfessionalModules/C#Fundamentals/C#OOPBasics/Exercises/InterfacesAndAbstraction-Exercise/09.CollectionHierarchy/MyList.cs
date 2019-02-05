public class MyList : Collection, IAddable, IRemoveable, IUseable
{
    public MyList()
        : base()
    {

    }

    public int Used
    {
        get
        {
            return base.collection.Count;
        }
    }

    public int Add(string item)
    {
        int index = 0;

        base.collection.Insert(index, item);

        return index;
    }

    public string Remove()
    {
        string item = base.collection[0];

        base.collection.RemoveAt(0);

        return item;
    }
}

