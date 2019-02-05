using System;
using System.Collections.Generic;
using System.Text;

public class Logger : ILogger
{
    private ICollection<IAppender> appenders;

    public Logger(ICollection<IAppender> appenders)
    {
        this.appenders = appenders;
    }

    public void Log(IError error)
    {
        foreach (var appender in appenders)
        {
            appender.Append(error);
        }
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder("Logger info" + Environment.NewLine);

        foreach (var appender in appenders)
        {
            result.Append(appender + Environment.NewLine);
        }

        return result.ToString();
    }

    public IReadOnlyCollection<IAppender> Appenders
    {
        get { return (IReadOnlyCollection<IAppender>)appenders; }
    }

}

