using MyGame;

var project = Project.Instance;

var manager = new ContainerManager();

project.Logger = manager.Logger;
project.SettingsService = manager.SettingsService;

project.Run();


