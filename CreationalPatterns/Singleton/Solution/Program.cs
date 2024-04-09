namespace CreationalPatterns.Singleton.Solution;
public class LogConfig
{
    private int instanceIndex;
    // The "volatile" keyword is used to indicate that 
    // a field might be modified by multiple threads that are executing at the same time
    // By using the volatile keyword, we can ensure that the instance is always up-to-date
    private static volatile LogConfig _logInstance;
    // This lockObject is used to lock Thread when creating the instance
    private static readonly object lockObject = new object();

    private LogConfig(int index)
    {
        instanceIndex = index;
    }

    // The GetLogInstance method is used to create the instance of the LogConfig class
    public static LogConfig GetLogInstance()
    {
        // Check if the instance is null, then lock the thread
        if (_logInstance == null)
        {
            // this will lock the thread when creating the instance
            // this mean only one thread can create the instance at a time
            lock (lockObject)
            {
                // Lock again to make sure that the instance is still null, not created by another thread
                if (_logInstance == null)
                {
                    var randomIndex = new Random();
                    _logInstance = new LogConfig(randomIndex.Next(1, 100));
                }
            }
        }
        // Return the instance when the instance is created already
        return _logInstance;

        // Note: This is the double-check locking pattern, it's used to prevent
        // the overhead of locking the thread every time we call the GetLogInstance method
        // Because when the lockObject is locked, the other threads will wait until the lockObject is unlocked
        // This may cause a performance issue when we have many threads
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
        Log Instance Created: 75
        */
        // Conclusion:
        // The output shows that we have only one instance of the LogConfig class
        // It creates a new instance of the LogConfig class only one time when we call the GetLogInstance method
        // and This is what we expected. This is the Singleton pattern
    }
}
