using Microsoft.Extensions.Logging;

using Goedel.Everything;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Everything;
public static class MauiProgram {

    // ToDo: Work out how to get style sheet used

    public static MauiApp CreateMauiApp() {
        ThreadPool.SetMinThreads (100, 100);

        Console.WriteLine("Start");

        //var MeshMachine = new MeshMachineCore();
        //MeshMachine.MeshHost.ConfigureMesh("alice@example.com", "null");




        var components = new List<IComponent> {
#if USE_PLATFORM_WINDOWS
            new Goedel.Cryptography.Windows.ComponentCryptographyWindows()
#elif USE_PLATFORM_LINUX
#endif
            };


        using var lifecycle = new LifeCycle(components);

        //var app = new EverythingMaui();

        //var prompt = app.GetPrompt(app.Sections[0]);


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
