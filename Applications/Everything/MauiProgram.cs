using Microsoft.Extensions.Logging;

using Goedel.Everything;
using Goedel.Mesh;
using Goedel.Mesh.Client;
using Goedel.Cryptography;
using Goedel.Cryptography.Core;

namespace Everything;
public static class MauiProgram {
    static IMeshMachine MeshMachine;

    static MauiProgram() => Goedel.Cryptography.Windows.Initialization.Initialized.AssertTrue(
    Goedel.Mesh.Internal.Throw);


    public static MauiApp CreateMauiApp() {




        var components = new List<IComponent> {
#if USE_PLATFORM_WINDOWS
            new Goedel.Cryptography.Windows.ComponentCryptographyWindows()
#elif USE_PLATFORM_LINUX
#endif
            };
        KeyCollectionCore.SetPlatformDirect(@"C:\\Users\\hallam\\Test\\Deterministic");
        MeshMachine = new MeshMachineCore();
        using var lifecycle = new LifeCycle(components);

        var app = new EverythingMaui();

        var prompt = app.GetPrompt(app.Sections[0]);


        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
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


