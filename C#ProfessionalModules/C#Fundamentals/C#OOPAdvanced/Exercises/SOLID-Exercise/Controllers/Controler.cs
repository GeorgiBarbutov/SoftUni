using System;
using System.Collections.Generic;

public class Controler
{
    private AppenderFactory appenderFactory;

    public Controler()
    {
        this.appenderFactory = new AppenderFactory();
    }

    public void ReadInput()
    {
        int n = int.Parse(Console.ReadLine());

        ICollection<IAppender> appenders = new List<IAppender>();

        for (int i = 0; i < n; i++)
        {
            string[] appenderInfo = Console.ReadLine().Split(' ');

            appenders.Add(appenderFactory.CreateAppender(appenderInfo));
        }

        ILogger logger = new Logger(appenders);

        string[] errorsInfo;

        while ((errorsInfo = Console.ReadLine().Split('|'))[0] != "END")
        {
            IError error = new Error(Enum.Parse<ErrorTreshholds>(errorsInfo[0]), errorsInfo[1], errorsInfo[2]);

            logger.Log(error);
        }

        Console.WriteLine(logger);
    }
}

