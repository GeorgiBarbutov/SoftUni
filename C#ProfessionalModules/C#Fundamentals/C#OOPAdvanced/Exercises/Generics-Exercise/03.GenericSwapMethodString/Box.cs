public class Box<T>
{
    public T Data { get; set; }

    public Box(T data)
    {
        this.Data = data;
    }

    public override string ToString()
    {
        return $"{this.Data.GetType().FullName}: {this.Data}";
    }
}

