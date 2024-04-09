namespace CreationalPatterns.Singleton.Problem;

// Problem: We have a class that is responsible for logging. 
// We want to make sure that we have only one instance of this class in the application.
public class LogConfig
{
    // This instanceIndex is used to present the instance of the class
    // This maybe any business stuffs in real life
    private int instanceIndex;
    private static LogConfig _logInstance;

    // This constructor is used to set the instanceIndex
    private LogConfig(int index)
    {
        instanceIndex = index;
    }

    public static LogConfig GetLogInstance()
    {
        if (_logInstance == null)
        {
            var randomIndex = new Random();
            _logInstance = new LogConfig(randomIndex.Next(1, 100));
        }
        return _logInstance;
    }

    public void LogInstanceNotification()
    {
        Console.WriteLine("Log Instance Created: " + instanceIndex);
    }

}

public class Program
{
    static void Main(string[] args)
    {
        var thread1 = new Thread(() => LogConfig.GetLogInstance().LogInstanceNotification());
        var thread2 = new Thread(() => LogConfig.GetLogInstance().LogInstanceNotification());

        thread1.Start();
        thread2.Start();

        // Output:
        /** 
        Log Instance Created: 75
        Log Instance Created: 92
        ----------
        Log Instance Created: 42
        Log Instance Created: 82
        */
        // Conclusion:
        // The output shows that we have two instances of the LogConfig class
        // It creates a new instance of the LogConfig class every time we call the GetLogInstance method
        // and This is NOT what we expected. This in real life may cause a problem related to data racing (race condition)
        // We want to have only one instance of the LogConfig class, it mean to have the same instanceIndex
    }
}
