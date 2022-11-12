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

        public List<PingReply> CheckIP(IEnumerable<string> IPlist, int timeout = 250)
        {
            List<PingReply> pingReplies = new ();

            try
            {
                foreach (string IP in IPlist)
                    pingReplies.Add(_pingSender.Send(IP.Trim(), timeout));
                return pingReplies;
            }
            catch
            {
                return null;
            }
        }
    }
}