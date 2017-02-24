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
            _logger = loggerFactory.CreateLogger<Node>();
            //_logger.LogDebug("Node ctor");
        }

        public void Start()
        {
            _logger.LogDebug("Node Start, network = {0}", _options.Value.Network);
            new Thread(ThreadStart)
            {
                IsBackground = true
            }.Start();
        }

        public void ThreadStart()
        {
            _logger.LogInformation(1, "Node started");

            while (true)
            {
                Thread.Sleep(TimeSpan.FromSeconds(30));
                _logger.LogDebug("{0}", DateTimeOffset.UtcNow);
            }
        }
    }
}
