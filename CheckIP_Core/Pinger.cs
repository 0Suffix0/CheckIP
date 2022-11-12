using System.Net.NetworkInformation;

namespace CheckIP_Core
{
    public sealed class Pinger
    {
        private readonly Ping _pingSender = new();

        public PingReply CheckIP(string IP, int timeout = 250)
        {
            try
            {
                return _pingSender.Send(IP.Trim(), timeout);
            }
            catch
            {
                return null;
            }
        }
    }
}