
internal interface IWeatherService {
    Task<IReadOnlyList<int>> GetFiveDayTemperaturesAsync();
    }