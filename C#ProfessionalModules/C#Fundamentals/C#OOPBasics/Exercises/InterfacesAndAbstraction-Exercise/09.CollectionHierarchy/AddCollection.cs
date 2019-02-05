public class AddCollection : Collection, IAddable
{
    public AddCollection()
        : base()
    {

    }

    public int Add(string item)
    {
        int index = base.collection.Count;

        base.collection.Add(item);

        return index;
    }
}

