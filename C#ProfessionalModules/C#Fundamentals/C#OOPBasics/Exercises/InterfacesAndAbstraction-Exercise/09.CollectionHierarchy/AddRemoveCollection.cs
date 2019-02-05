public class AddRemoveCollection : Collection, IAddable, IRemoveable
{
    public AddRemoveCollection()
        : base()
    {

    }

    public int Add(string item)
    {
        int index = 0;

        base.collection.Insert(index, item);

        return index;
    }

    public string Remove()
    {
        string item = collection[collection.Count - 1];

        base.collection.RemoveAt(collection.Count - 1);

        return item;
    }
}

