namespace redis_demo_api.Services;

public class FileLoggerService : ILoggerService
{
    private static FileLoggerService _instance = null;

    private static readonly object SyncObj = new();

    /// <summary>
    /// 单例对象
    /// </summary>
    /// <returns></returns>
    public static FileLoggerService Instance
    {
        get
        {
            if (_instance == null)
            {
                lock (SyncObj)
                {
                    _instance ??= new FileLoggerService();
                }
            }

            return _instance;
        }
    }

    //private readonly string _path = Path.Combine(Environment.CurrentDirectory, @"\Log\");
    private readonly string _path = Environment.CurrentDirectory + @"\Log\";


    public void Info()
    {
        throw new NotImplementedException();
    }

    public void Warn()
    {
        throw new NotImplementedException();
    }

    public void Debug()
    {
        throw new NotImplementedException();
    }

    public void Info(string message)
    {
        try
        {
            if (!Directory.Exists($@"{_path}Info\"))
            {
                Directory.CreateDirectory($@"{_path}Info\");
            }

            var fileName = $@"{_path}Info\Log_Info{DateTime.Now:yyyyMMdd}.txt";
            File.AppendAllText(fileName,
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  Info:  {message}\r\n \r\n");
        }
        catch (Exception e)
        {
            var msg = e.Message;
        }
    }

    public void Info(Exception exception)
    {
        try
        {
            if (!Directory.Exists($@"{_path}Info\"))
            {
                Directory.CreateDirectory($@"{_path}Info\");
            }

            var fileName = $@"{_path}Info\Log_Info{DateTime.Now:yyyyMMdd}.txt";
            File.AppendAllText(fileName,
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  Info:  {exception.Message} \r\n{exception.StackTrace}\r\n \r\n");
        }
        catch (Exception e)
        {
            var msg = e.Message;
        }
    }

    public void Info(string message, object data)
    {
        throw new NotImplementedException();
    }

    public void Warn(string message, object data)
    {
        throw new NotImplementedException();
    }

    public void Debug(string message)
    {
        throw new NotImplementedException();
    }

    public void Debug(string message, object data)
    {
        throw new NotImplementedException();
    }

    public void Error(string message)
    {
        try
        {
            if (!Directory.Exists($@"{_path}Error\"))
            {
                Directory.CreateDirectory($@"{_path}Error\");
            }

            var fileName = $@"{_path}Error\Log_Error{DateTime.Now:yyyyMMdd}.txt";
            File.AppendAllText(fileName, $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  INFO:  {message}");
        }
        catch (Exception e)
        {
            var msg = e.Message;
        }
    }

    public void Error(Exception exception)
    {
        try
        {
            if (!Directory.Exists($@"{_path}Error\"))
            {
                Directory.CreateDirectory($@"{_path}Error\");
            }

            var fileName = $@"{_path}Error\Log_Error{DateTime.Now:yyyyMMdd}.txt";
            File.AppendAllText(fileName,
                $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}  Error:  {exception.Message} \r\n{exception.StackTrace}\r\n \r\n");
        }
        catch (Exception e)
        {
            var msg = e.Message;
        }
    }
}