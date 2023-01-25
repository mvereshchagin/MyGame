namespace MyGame.Logging;

internal class FileLogger : ILogger
{
    private string _filePath;

    public FileLogger(string filePath)
    {
        _filePath = filePath;
    }

    public void LogError(Exception exc, string message)
    {
        SaveLine("ERR", message);
    }

    public void LogMessage(string message)
    {
        SaveLine("INFO", message);
    }

    public void LogWarning(string message)
    {
        SaveLine("WARN", message);
    }

    private void SaveLine(string tag, string message)
    {
        using var writer = new StreamWriter(_filePath, append: true);
        var formattedMessage = $"{tag} {DateTime.Now:g}: {message}";

        try
        {
            writer.WriteLine(formattedMessage);
        }
        catch { }
    }
}
