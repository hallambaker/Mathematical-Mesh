




using Everything.Resources;

namespace Everything;

/// <summary>
/// The application.
/// </summary>
public partial class App : Application {

    Gui Gui { get; }

    /// <summary>
    /// Constructor, returns an instance with components initialized and a Gui binding snf
    /// raises the main window.
    /// </summary>
    public App() {
        InitializeComponent();
        Gui = new EverythingMaui(Sketch_resources.ResourceManager, GetDeviceDescription);

        var binding = new GuigenBinding(Gui);
        MainPage = binding.GetMain();

        }


    public DeviceDescription GetDeviceDescription() {


        var device = DeviceInfo.Current;
        // ToDo: Device specific grab of Model reaching into the registry to fetch "Baseboard Product" etc. on Windows


        var deviceDescription = new DeviceDescription() {
            Idiom = device.Idiom.AsToken(),
            Manufacturer = device.Manufacturer,
            Model = device.Model,
            Name = device.Name,
            Platform = device.Platform.AsToken(),
            Version = device.VersionString


            };

        return deviceDescription;
        }
    }
