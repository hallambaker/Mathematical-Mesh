﻿using Microsoft.Extensions.Logging;

using Goedel.Everything;
using Goedel.Mesh;
using Goedel.Cryptography;

namespace Everything;
public static class MauiProgram {
    public static MauiApp CreateMauiApp() {

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


