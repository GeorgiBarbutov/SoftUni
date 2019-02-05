public class LayoutFactory
{
    public ILayout CreateLayout(string argument)
    {
        if(argument == "SimpleLayout")
        {
            return new SimpleLayout();
        }
        else if (argument == "XmlLayout")
        {
            return new XmlLayout();
        }

        return null;
    }
}

