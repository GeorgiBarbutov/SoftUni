public interface ILogFile
{
    int Size { get; }

    void Write(string log);
    void ChangePath(string newPath);
}