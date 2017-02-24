using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBitcoin.SimpleVerificationServer
{
    public class Node
    {
        ILogger<Node> _logger;
        IOptions<NodeSettings> _options;

        public Node(ILoggerFactory loggerFactory, IOptions<NodeSettings> options)
        {
            _options = options;
            //Console.WriteLine("CONSOLE: Node ctor");
            _logger = loggerFactory.CreateLogger<Node>();
            _logger.LogDebug("Node ctor, network = {0}", _options.Value.Network);
        }

        public void Start()
        {
            //Console.WriteLine("CONSOLE: Node Start");
            _logger.LogDebug("Node Start");
            new Thread(ThreadStart)
            {
                IsBackground = true //so the process terminate
            }.Start();
        }

        public void ThreadStart()
        {
            //Console.WriteLine("CONSOLE: Node started");
            _logger.LogInformation(1, "Node started");

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                _logger.LogDebug("{0}", DateTimeOffset.UtcNow);
            }
        }
    }
}
