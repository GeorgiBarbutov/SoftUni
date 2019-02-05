public abstract class Layout : ILayout
{
    private string format;  

    protected Layout(string format)
    {
        this.Format = format;
    }

    public string Format
    {
        get { return format; }
        private set { format = value; }
    }
}

