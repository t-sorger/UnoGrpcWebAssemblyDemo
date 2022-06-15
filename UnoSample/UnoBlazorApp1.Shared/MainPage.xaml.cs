using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Count;
using Google.Protobuf.WellKnownTypes;
using System.Net.Http;
using Grpc.Net.Client.Web;
using Grpc.Net.Client;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UnoBlazorApp1;

/// <summary>
/// An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainPage : Page
{
    private readonly Counter.CounterClient _counterClient;
    private int _grpcCounterValue;

    public Counter.CounterClient CounterClient => _counterClient;

    public int GrpcCounterValue
    {
        get => _grpcCounterValue;
        set => _grpcCounterValue = value;
    }

    public ICommand IncrementCommand { get; set; }

    public MainPage()
    {
        var httpClient = new HttpClient(new GrpcWebHandler(GrpcWebMode.GrpcWeb, new HttpClientHandler()));
        var baseUri = "https://localhost:44366";
        var channel = GrpcChannel.ForAddress(baseUri, new GrpcChannelOptions { HttpClient = httpClient });
        _counterClient = new Counter.CounterClient(channel);

        this.InitializeComponent();
    }


    public async void Increment_Click(object sender, EventArgs e)
    {
        var reply = await CounterClient.IncrementCountAsync(new Empty());
        CounterValue.Text = $"{reply.Count}";
    }
}