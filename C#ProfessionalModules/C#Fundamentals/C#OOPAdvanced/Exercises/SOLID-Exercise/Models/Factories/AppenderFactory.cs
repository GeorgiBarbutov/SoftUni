using System;

public class AppenderFactory
{
    private LayoutFactory layoutFactory;

    public AppenderFactory()
    {
        this.layoutFactory = new LayoutFactory();
    }

    public IAppender CreateAppender(string[] arguments)
    {
        string appenderType = arguments[0];
        string layoutType = arguments[1];

        ILayout layout = layoutFactory.CreateLayout(layoutType);

        if (appenderType == "ConsoleAppender")
        {
            if (arguments.Length == 3)
            {
                return new ConsoleAppender(layout, Enum.Parse<ErrorTreshholds>(arguments[2]));
            }
            else
            {
                return new ConsoleAppender(layout);
            }
        }
        else if (appenderType == "FileAppender")
        {
            if (arguments.Length == 3)
            {
                return new FileAppender(layout, Enum.Parse<ErrorTreshholds>(arguments[2]), new LogFile());
            }
            else
            {
                return new FileAppender(layout, new LogFile());
            }
        }

        return null;
    }
}

