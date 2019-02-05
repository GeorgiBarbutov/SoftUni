public abstract class Appender : IAppender
{
    private const ErrorTreshholds DEFAULT_TRESHHOLD = ErrorTreshholds.INFO;

    private ILayout layout;
    private ErrorTreshholds reportLevelTreshhold;
    private int messagesAppendedCount;

    protected Appender(ILayout layout)
    {
        this.Layout = layout;
        this.ReportLevelTreshhold = DEFAULT_TRESHHOLD;
        this.MessagesAppendedCount = 0;
    }
    protected Appender(ILayout layout, ErrorTreshholds reportLevelTreshhold) 
        : this(layout)
    {
        this.ReportLevelTreshhold = reportLevelTreshhold;
    }

    public abstract void Append(IError error);

    public override string ToString()
    {
        return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout}, Report level: {this.ReportLevelTreshhold}, Messages appended: {this.MessagesAppendedCount}";
    }

    public ILayout Layout
    {
        get { return layout; }
        private set { layout = value; }
    }
    public ErrorTreshholds ReportLevelTreshhold
    {
        get { return reportLevelTreshhold; }
        private set { reportLevelTreshhold = value; }
    }
    public int MessagesAppendedCount
    {
        get { return messagesAppendedCount; }
        protected set { messagesAppendedCount = value; }
    }
}

