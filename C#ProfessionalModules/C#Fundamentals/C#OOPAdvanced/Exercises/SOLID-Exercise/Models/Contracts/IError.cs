public interface IError
{
    string DateTime { get; }
    string Message { get; }

    ErrorTreshholds ReportLevel { get; }
}