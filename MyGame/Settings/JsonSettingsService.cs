using System.Text.Json;

namespace MyGame.Settings;

internal class JsonSettingsService : ISettingsService
{
    private string _filePath;

    public JsonSettingsService(string filePath)
    {
        if (Path.GetExtension(filePath) != ".json")
            throw new ArgumentException(nameof(filePath), "Should end with .json");

        _filePath = filePath;
    }

    public AppSettings Read()
    {
        try
        {
            var jsonString = File.ReadAllText(_filePath);
            var seettings = JsonSerializer.Deserialize<AppSettings>(jsonString);
            return seettings ?? new AppSettings();
        }
        catch
        {
            return new AppSettings();
        }
    }

    public void Update(AppSettings settings)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize<AppSettings>(settings);
            File.WriteAllText(_filePath, jsonString);
        }
        catch
        { }
    }
}
