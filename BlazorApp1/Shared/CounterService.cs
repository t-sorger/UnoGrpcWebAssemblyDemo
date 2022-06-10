using System;
using System.Threading.Tasks;
using Count;
using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace BlazorApp1.Shared
{
    public class CounterService : Counter.CounterBase
    {
        private readonly ILogger _logger;
        private readonly IncrementingCounter _counter;

        public CounterService(IncrementingCounter counter, ILoggerFactory loggerFactory)
        {
            _counter = counter;
            _logger = loggerFactory?.CreateLogger<CounterService>();
        }

        public override Task<CounterReply> IncrementCount(Empty request, ServerCallContext context)
        {
            _logger?.LogInformation("Incrementing count by 1");
            Console.WriteLine("Incrementing count by 1");
            _counter.Increment(1);

            return Task.FromResult(new CounterReply { Count = _counter.Count });
        }

        public override async Task<CounterReply> AccumulateCount(IAsyncStreamReader<CounterRequest> requestStream,
            ServerCallContext context)
        {
            await foreach (var message in requestStream.ReadAllAsync())
            {
                _logger?.LogInformation($"Incrementing count by {message.Count}");
                Console.WriteLine($"Incrementing count by {message.Count}");

                _counter.Increment(message.Count);
            }

            return new CounterReply { Count = _counter.Count };
        }

        public override async Task Countdown(Empty request, IServerStreamWriter<CounterReply> responseStream,
            ServerCallContext context)
        {
            Console.WriteLine("Start Countdown");
            for (var i = _counter.Count; i >= 0; i--)
            {
                await responseStream.WriteAsync(new CounterReply { Count = i });
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
        }
    }
}