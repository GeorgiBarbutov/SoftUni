using System.Text;

public class FileAppender : Appender, IFileApender
{
    private ILogFile logFile;

    public FileAppender(ILayout layout, ILogFile file) 
        : base(layout)
    {
        this.LogFile = file;
    }

    public FileAppender(ILayout layout, ErrorTreshholds reportLevelTreshhold, ILogFile file) 
        : base(layout, reportLevelTreshhold)
    {
        this.LogFile = file;
    }

    public override void Append(IError error)
    {
        ErrorTreshholds errorTreshhold = error.ReportLevel;
        string dateTime = error.DateTime;
        string message = error.Message;

        if (errorTreshhold >= this.ReportLevelTreshhold)
        {
            StringBuilder result = new StringBuilder();

            result.AppendFormat(this.Layout.Format, dateTime, errorTreshhold.ToString(), message);

            this.LogFile.Write(result.ToString());

            this.MessagesAppendedCount++;
        }
    }

    public override string ToString()
    {
        return base.ToString() + $", File size {this.LogFile.Size}";
    }

    public ILogFile LogFile
    {
        get { return logFile; }
        private set { logFile = value; }
    }
}

