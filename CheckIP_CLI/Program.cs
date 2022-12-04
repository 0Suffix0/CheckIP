using CheckIP_Core;
using Spectre.Console;
using System.Net;
using System.Net.NetworkInformation;

namespace CheckIP_CLI;

internal sealed class Program
{
    private static Dictionary<IPAddress, string> _listIPsStatus = new();

    private static Pinger _pinger = new();

    private static Table _table = new();
    private static CancellationTokenSource _cts = new();

    public Program()
    {
        Console.CancelKeyPress += (s, e) =>
        {
            _cts.Cancel();
        };

        _pinger.StatusIP += (s, e) =>
        {
            if (e is PingReply reply)
            {
                var status = "Success";

                if (reply.Status is not IPStatus.Success)
                    status = "Unsuccess";

                if (!_listIPsStatus.ContainsKey(reply.Address))
                {
                    _listIPsStatus.Add(reply.Address, status);
                    return;
                }

                var ip = _listIPsStatus[reply.Address];
                ip = status;
            }

            // метод отрисовки таблицы
        };

        _table.AddColumns("IP", "Status");
        _table.Columns[1].Width(50);
    }

    private static void Main(string[] args)
    {
    }
}