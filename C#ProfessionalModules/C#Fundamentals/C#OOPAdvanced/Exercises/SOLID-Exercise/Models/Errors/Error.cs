public class Error : IError
{
    private ErrorTreshholds reportLevel;
    private string dateTime;
    private string message;

    public Error(ErrorTreshholds reportLevel, string dateTime, string message)
    {
        this.ReportLevel = reportLevel;
        this.DateTime = dateTime;
        this.Message = message;
    }

    public string Message
    {
        get { return message; }
        private set { message = value; }
    }
    public string DateTime
    {
        get { return dateTime; }
        private set { dateTime = value; }
    }
    public ErrorTreshholds ReportLevel
    {
        get { return reportLevel; }
        private set { reportLevel = value; }
    }
}

