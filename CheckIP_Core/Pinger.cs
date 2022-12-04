using System.Net.NetworkInformation;

namespace CheckIP_Core
{
    public sealed class Pinger
    {
        private readonly Ping _pingSender = new();

        public event EventHandler<object>? StatusIP;

        public Pinger()
        {
            _pingSender.PingCompleted += (s, e) => StatusIP?.Invoke(this, e);
        }

        /// <summary>
        /// Ping just one IP-adress.
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public PingReply CheckIP(string IP, int timeout = 250)
        {
            try
            {
                return _pingSender.Send(IP.Trim(), timeout);
            }
            catch (Exception e)
            {
                throw new Exception("Unknown error\n" + e.ToString());
            }
        }

        public void CheckIPAsync(string IP, CancellationToken token, int timeout = 250)
        {
            while (!token.IsCancellationRequested)
            {
                _pingSender.SendAsync(IP.Trim(), timeout, token);
            }
        }

        /// <summary>
        /// Pings IP-adresses in an IEnumerable collection.
        /// </summary>
        /// <param name="IPlist"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public IEnumerable<PingReply> CheckIP(IEnumerable<string> IPlist, int timeout = 250)
        {
            List<PingReply> pingReplies = new();

            try
            {
                foreach (string IP in IPlist)
                    pingReplies.Add(_pingSender.Send(IP.Trim(), timeout));
                return pingReplies;
            }
            catch (Exception e)
            {
                throw new Exception("Unknown error\n" + e.ToString());
            }
        }
    }
}