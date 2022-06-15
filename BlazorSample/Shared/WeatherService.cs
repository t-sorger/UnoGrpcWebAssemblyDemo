﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;

namespace BlazorGrpcWebApp.Shared
{
    public class WeatherService : WeatherForecasts.WeatherForecastsBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public override Task<WeatherReply> GetWeather(WeatherForecast request, ServerCallContext context)
        {
            var reply = new WeatherReply();
            var rng = new Random();

            reply.Forecasts.Add(Enumerable.Range(1, 10).Select(index => new WeatherForecast
            {
                // Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }));

            return Task.FromResult(reply);
        }
    }
}