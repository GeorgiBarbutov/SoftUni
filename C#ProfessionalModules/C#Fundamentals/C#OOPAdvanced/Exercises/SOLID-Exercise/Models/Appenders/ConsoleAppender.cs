using System;
using System.Text;

public class ConsoleAppender : Appender
{
    public ConsoleAppender(ILayout layout) 
        : base(layout)
    {
    }

    public ConsoleAppender(ILayout layout, ErrorTreshholds repotLevelTreshhold) 
        : base(layout, repotLevelTreshhold)
    {
    }

    public override void Append(IError error)
    {
        ErrorTreshholds errorTreshhold = error.ReportLevel;
        string dateTime = error.DateTime;
        string message = error.Message;

        if(errorTreshhold >= this.ReportLevelTreshhold)
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat(this.Layout.Format, dateTime, errorTreshhold.ToString(), message);

            Console.WriteLine(result);

            this.MessagesAppendedCount++;
        }
    }
}

