using BlazorGrpcWebApp.Shared;
using Count;
using Grpc.Core;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorApp1.Client;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddSingleton(services =>
        {
            var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
            const string baseUri = "https://localhost:44366";
            var channel =
                GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient }) as ChannelBase;
            return channel;
        });

        builder.Services.AddSingleton(services =>
        {
            var channel = services.GetRequiredService(typeof(ChannelBase)) as ChannelBase;
            return new WeatherForecasts.WeatherForecastsClient(channel);
        });

        builder.Services.AddSingleton(services =>
        {
            var channel = services.GetRequiredService(typeof(ChannelBase)) as ChannelBase;
            return new Counter.CounterClient(channel);
        });

        await builder.Build().RunAsync();
    }
}