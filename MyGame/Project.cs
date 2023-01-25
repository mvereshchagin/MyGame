using MyGame.Logging;
using MyGame.Settings;

namespace MyGame;

internal class Project
{
    #region standalone
    private static Project? _instance;

    private Project()
    { }

    public static Project Instance
    {
        get
        {
            if (_instance is null)
                _instance = new Project();
            return _instance;
        }
    }
    #endregion

    public ILogger Logger { get; set; }

    public ISettingsService SettingsService { get; set; }

    public void Run()
    {
        Logger.LogMessage("Start application");

        Logger.LogMessage("Read settings");
        var settings = SettingsService.Read();
        Console.WriteLine($"settings: {settings}");

        Logger.LogMessage("Change settings");

        settings.Speed = 100;

        Console.WriteLine("Please, endter your name");
        var name = Console.ReadLine();
        settings.UserName = name;

        Logger.LogMessage("Update settings");
        SettingsService.Update(settings);

        Logger.LogMessage("Read settings again");
        settings = SettingsService.Read();
        Console.WriteLine($"settings: {settings}");

        // app logic

        int a = 4, b = 0;
        try
        {
            var c = a / b;
            Logger.LogMessage($"c = {c}");
        }
        catch(Exception ex)
        {
            Logger.LogError(ex, "Something goes wrong when dividing");
        }

        int d = 20, e = 5;
        var f = d / e;
        Logger.LogMessage($"{d} / {e} = {f}");

        Logger.LogWarning("Simple warning");


        Logger.LogMessage("End application");
    }
}
