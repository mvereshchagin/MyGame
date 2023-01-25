using System.Xml.Serialization;

namespace MyGame.Settings;

internal class XmlSettingsService : ISettingsService
{
    private string _filePath;

    public XmlSettingsService(string filePath)
    {
        if (Path.GetExtension(filePath) != ".xml")
            throw new ArgumentException(nameof(filePath), "Should end with .json");

        _filePath = filePath;
    }

    public AppSettings Read()
    {
        try
        {
            var serializer = new XmlSerializer(typeof(AppSettings));
            using var fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            var obj = serializer.Deserialize(fs);
            if (obj is AppSettings settings)
                return settings;

            return new AppSettings();
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
            var serializer = new XmlSerializer(typeof(AppSettings));
            using var fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            serializer.Serialize(fs, settings);
            fs.Flush();
        }
        catch
        { }
    }
}
