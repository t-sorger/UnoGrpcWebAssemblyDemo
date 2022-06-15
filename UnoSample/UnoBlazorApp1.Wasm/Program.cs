using BlazorGrpcWebApp.Shared;
using Count;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace UnoBlazorApp1.Wasm
{
    public class Program
    {
        private static App _app;

        public static async Task Main(string[] args)
        {
            Microsoft.UI.Xaml.Application.Start(_ => _app = new App());
        }
    }
}
