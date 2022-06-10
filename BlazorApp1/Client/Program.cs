using BlazorGrpcWebApp.Shared;
using Count;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;


namespace BlazorApp1.Client;

public class Program
{
    private static GrpcChannel _channel;

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        // builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

        var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
        //var baseUri = services.GetRequiredService<NavigationManager>().BaseUri;
        var baseUri = "https://localhost:44366";
        _channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient });

        builder.Services.AddSingleton(services =>
        {
            return new WeatherForecasts.WeatherForecastsClient(_channel);
        });

        builder.Services.AddSingleton(services =>
        {
            return new Counter.CounterClient(_channel);
        });

        await builder.Build().RunAsync();
    }
}