using CheckIP_Core;
using Spectre.Console;
using System.Net.NetworkInformation;

namespace CheckIP_CLI
{
    internal class Program
    {
        private static readonly Ping _pingSender = new();

        static void Main(string[] args)
        {
            _pingSender.PingCompleted += (s, e) => {
                if(e.Reply is not null)
                    Console.WriteLine(e.Reply.Status);
            };

            while (true)
            {
                Task.Delay(1000);
                _pingSender.SendAsync("yandex.ru", 250);
            }
            Console.ReadKey();
        }
    }
}