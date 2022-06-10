using Count;
using Google.Protobuf.WellKnownTypes;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Windows.Input;

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

    public MainPage(Counter.CounterClient counterClient)
    {
        _counterClient = counterClient;
        this.InitializeComponent();

        //IncrementCommand += (async (sender, e) => await _counterClient.IncrementCountAsync(new Empty()));
    }
    public void Button1_Click(object sender, EventArgs e)
    {
        var reply = CounterClient.IncrementCount(new Empty());
        _grpcCounterValue = reply.Count;
    }
}