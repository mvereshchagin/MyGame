using MyGame.Logging;
using MyGame.Settings;

namespace MyGame;

internal class ContainerManager
{
    public ILogger Logger { get; private set; }

    public ISettingsService SettingsService { get; private set; }

    public ContainerManager()
    {
        Logger = new FileLogger("logs.txt"); // new ConsoleLogger();
        SettingsService = new XmlSettingsService("settings.xml"); // new JsonSettingsService("settings.json");
    }
}
