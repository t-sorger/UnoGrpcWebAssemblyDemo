using Count;
using Google.Protobuf.WellKnownTypes;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Windows.Input;
using BlazorGrpcWebApp.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.UI.Xaml;

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
        this.InitializeComponent();
        DataContext = (Application.Current as App)?.Host.Services.GetRequiredService<MainPageViewModel>();
    }

    public void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            var reply = (DataContext as MainPageViewModel)?.WeatherClient?.GetWeather(new WeatherForecast(new WeatherForecast()));
        }
        catch (Exception exception)
        {
            // Cannot wait on monitors on this runtime.
            Console.WriteLine(exception);
        }
        //GrpcCounterValue = reply.Count;
    }
}