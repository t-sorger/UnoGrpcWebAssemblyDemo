using System.Windows.Input;
using BlazorGrpcWebApp.Shared;
using Count;

namespace UnoBlazorApp1;

public class MainPageViewModel
{
    private readonly WeatherForecasts.WeatherForecastsClient _weatherClient;

    public ICommand IncrementCounter { get; set; }

    public WeatherForecasts.WeatherForecastsClient WeatherClient => _weatherClient;

    public MainPageViewModel(WeatherForecasts.WeatherForecastsClient weatherClient)
    {
        _weatherClient = weatherClient;
    }
}