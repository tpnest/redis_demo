namespace redis_demo_api.Services;

public interface ILoggerService
{
    void Info(string message);
    void Info(Exception exception);
    void Info(string message, object data);
    void Warn(string message, object data);
    void Debug(string message);
    void Debug(string message, object data);
    void Error(string message);
    void Error(Exception exception);
}