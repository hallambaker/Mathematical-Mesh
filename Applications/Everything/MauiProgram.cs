




using Everything.Resources;

namespace Everything;


/// <summary>
/// The main Maui application.
/// </summary>
public static class MauiProgram {


    // ToDo: Work out how to get style sheet used

    /// <summary>
    /// Create an initialize a new <see cref="MauiApp"/> instance.
    /// </summary>
    /// <returns></returns>
    public static MauiApp CreateMauiApp() {
        ThreadPool.SetMinThreads(100, 100);

        ResourceResolver.SetResourceManager(Sketch_resources.ResourceManager, Sketch_resources.Culture);

        var components = new List<IComponent> {

#if USE_PLATFORM_WINDOWS
            new Goedel.Cryptography.Windows.ComponentCryptographyWindows()
#elif USE_PLATFORM_LINUX
#endif
            };

        using var lifecycle = new LifeCycle(components);

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCameraView()
            .ConfigureFonts(fonts => {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
        }
    }
