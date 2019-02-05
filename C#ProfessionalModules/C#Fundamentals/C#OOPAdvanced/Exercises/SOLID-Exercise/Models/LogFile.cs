using System;
using System.IO;

public class LogFile : ILogFile
{
    private const string DEFAULT_PATH = "log.txt";

    private int size;
    private string path;

    public LogFile()
    {
        this.Size = 0;
        this.path = DEFAULT_PATH;
    }

    public void Write(string log)
    {
        IncreaseSize(log);

        File.AppendAllText(this.path, log + Environment.NewLine);
    }
    public void ChangePath(string newPath)
    {
        this.path = newPath;
    }
    private void IncreaseSize(string log)
    {
        for (int i = 0; i < log.Length; i++)
        {
            if ((int)log[i] >= (int)'A' && (int)log[i] <= (int)'Z' || (int)log[i] >= (int)'a' && (int)log[i] <= (int)'z')
            {
                this.Size += (int)log[i];
            }
        }
    }

    public int Size
    {
        get { return size; }
        private set { size = value; }
    }
}

