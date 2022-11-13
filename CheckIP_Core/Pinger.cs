using System.Net.NetworkInformation;

namespace CheckIP_Core
{
    public sealed class Pinger
    {
        private readonly Ping _pingSender = new();

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

        /// <summary>
        /// Pings IP-adresses in an IEnumerable collection. 
        /// </summary>
        /// <param name="IPlist"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public List<PingReply> CheckIP(IEnumerable<string> IPlist, int timeout = 250)
        {
            List<PingReply> pingReplies = new ();

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