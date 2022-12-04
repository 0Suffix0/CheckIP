using CheckIP_Core;
using Spectre.Console;

namespace CheckIP_CLI;

internal sealed class Program
{
    static Pinger pinger = new();
    private static void Main(string[] args)
    {
        var table = new Table();

        table.AddColumns("IP", "Status");
        table.Columns[1].Width(50);

        pinger.CheckIPAsync("yandex.ru", new CancellationTokenSource().Token);

    }
}