namespace MyGame.Logging;

internal interface ILogger
{
    void LogError(Exception exc, string message);

    void LogWarning(string message);

    void LogMessage(string message);
}
