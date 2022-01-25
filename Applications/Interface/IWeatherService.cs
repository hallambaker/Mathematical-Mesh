namespace GenericHostConsoleApp;

public interface IWeatherService
{
    Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync(CancellationToken cancellationToken);
}