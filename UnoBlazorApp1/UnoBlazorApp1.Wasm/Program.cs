using BlazorGrpcWebApp.Shared;
using Count;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace UnoBlazorApp1.Wasm
{
    public class Program
    {
        private static App _app;
        //private static GrpcChannel _channel;

        public static async Task Main(string[] args)
        {
            Microsoft.UI.Xaml.Application.Start(_ => _app = new App());

            //var builder = WebAssemblyHostBuilder.CreateDefault(args);
            //// builder.RootComponents.Add<App>("#app");

            //// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            //var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
            //var baseUri = "https://localhost:44366";
            //_channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient });

            //builder.Services.AddSingleton(services => new WeatherForecasts.WeatherForecastsClient(_channel));
            //builder.Services.AddSingleton(services => new Counter.CounterClient(_channel));

            //await builder.Build().RunAsync();
            
        }
    }
}
