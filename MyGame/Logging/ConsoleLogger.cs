namespace MyGame.Logging;

internal class ConsoleLogger : ILogger
{
    public void LogError(Exception exc, string message)
    {
        var resMessage = $"{exc.StackTrace}\r\n{message}";
        SaveLine("ERR", resMessage, ConsoleColor.Red);
    }

    public void LogMessage(string message)
    {
        SaveLine("INFO", message);
    }

    public void LogWarning(string message)
    {
        SaveLine("WARN", message, ConsoleColor.Yellow);
    }

    private string CreateFormattedMessage(string tag, string message)
    {
        return $"{tag} {DateTime.Now:g}: {message}";
    }

    private void SaveLine(string tag, string message, ConsoleColor? fgColor = null)
    {
        fgColor ??= Console.ForegroundColor;
        var formattedMessage = $"{tag} {DateTime.Now:g}: {message}";

        var prevFgColor = Console.ForegroundColor;

        Console.ForegroundColor = fgColor.Value;
        Console.WriteLine(formattedMessage);
        Console.ForegroundColor = prevFgColor;
    }
}
