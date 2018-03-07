using System;

public interface ILogger
{
    void Log(string message);
    void LogWarning(string message);
    void LogError(Exception ex, string message);
}