using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NBitcoin.SimpleVerificationServer.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var shell = new Shell())
            {
                shell.Start();
                Console.WriteLine("Press Enter to stop");
                Console.ReadLine();
            }


            ////Logs.Configure(new FuncLoggerFactory(n => new ConsoleLogger(n, (a, b) => true, false)));
            ////NodeArgs nodeArgs = NodeArgs.GetArgs(args);

            //// Console thread

            //server.Start();
            //server.Dispose();
        }
    }
}
