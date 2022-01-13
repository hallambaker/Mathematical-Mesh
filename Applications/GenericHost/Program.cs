#region // Copyright - MIT License
//  Copyright © 2015 by Comodo Group Inc.
//  Copyright © 2019-2021 by Phill Hallam-Baker
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
#endregion


using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

internal sealed class Program {
    private static async Task Main(string[] args) {
        await Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) => {
                services.AddHostedService<ConsoleHostedService>();
                services.AddSingleton<IWeatherService, WeatherService>();
            })
            .RunConsoleAsync();
        }
    }

internal sealed class ConsoleHostedService : IHostedService {
    private readonly ILogger _logger;
    private readonly IHostApplicationLifetime _appLifetime;
    private readonly IWeatherService _weatherService;

    public ConsoleHostedService(
            ILogger<ConsoleHostedService> logger,
            IHostApplicationLifetime appLifetime,
            IWeatherService weatherService) {
        _logger = logger;
        _appLifetime = appLifetime;
        }

    public Task StartAsync(CancellationToken cancellationToken) {
        _logger.LogDebug($"Starting with arguments: {string.Join(" ", Environment.GetCommandLineArgs())}");

        _appLifetime.ApplicationStarted.Register(() => {
            Task.Run(async () => {
                try {
                    _logger.LogInformation("Hello World!");

                    // Simulate real work is being done
                    await Task.Delay(1000);
                    }
                catch (Exception ex) {
                    _logger.LogError(ex, "Unhandled exception!");
                    }
                finally {
                    // Stop the application once the work is done
                    _appLifetime.StopApplication();
                    }
            });
        });

        return Task.CompletedTask;
        }

    public Task StopAsync(CancellationToken cancellationToken) {
        return Task.CompletedTask;
        }
    }


internal sealed class WeatherSettings {
    public string Unit { get; set; }
    }

internal sealed class WeatherService : IWeatherService {
    private readonly IOptions<WeatherSettings> _weatherSettings;

    public WeatherService(IOptions<WeatherSettings> weatherSettings) {
        _weatherSettings = weatherSettings;
        }

    public Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync() {
        int[] temperatures = new[] { 76, 76, 77, 79, 78 };
        if (_weatherSettings.Value.Unit.Equals("C", StringComparison.OrdinalIgnoreCase)) {
            for (int i = 0; i < temperatures.Length; i++) {
                temperatures[i] = (int)Math.Round((temperatures[i] - 32) / 1.8);
                }
            }

        return Task.FromResult<IReadOnlyList<int>>(temperatures);
        }
    }
