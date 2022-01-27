using System.Reflection;
using GenericHostConsoleApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

await Host.CreateDefaultBuilder(args)
    .UseContentRoot(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
    .ConfigureLogging(builder =>
        builder.ClearProviders()
            .AddColorConsoleLogger(configuration => {
                // Replace warning value from appsettings.json of "Cyan"
                configuration.LogLevels[LogLevel.Warning] = ConsoleColor.DarkCyan;
                // Replace warning value from appsettings.json of "Red"
                configuration.LogLevels[LogLevel.Error] = ConsoleColor.DarkRed;
            }))
    .ConfigureServices((hostContext, services) =>
    {
        services
            .AddHostedService<ConsoleHostedService>()
            .AddSingleton<IWeatherService, WeatherService>();

        services.AddOptions<WeatherSettings>().Bind(hostContext.Configuration.GetSection("Weather"));
    })
    .RunConsoleAsync();
