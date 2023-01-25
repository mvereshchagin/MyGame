namespace MyGame.Settings;

internal interface ISettingsService
{
    AppSettings Read();

    void Update(AppSettings settings);
}
