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
            // TODO: Probably should be a way for this to specify where the settings come from,
            // e.g. console app would add command line, etc.
            using (var shell = new Shell())
            {
                shell.Start();
                Console.WriteLine("Press Enter to stop");
                Console.ReadLine();
            }
        }
    }
}
