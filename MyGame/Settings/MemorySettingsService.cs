namespace MyGame.Settings;

internal class MemorySettingsService : ISettingsService
{
    private readonly AppSettings _settings;

    public MemorySettingsService()
    {
        _settings = new AppSettings();
    }

    public AppSettings Read()
    {
        return _settings;
    }

    public void Update(AppSettings settings)
    {
        _settings.Speed = settings.Speed;
        _settings.UserName = settings.UserName;
    }
}
