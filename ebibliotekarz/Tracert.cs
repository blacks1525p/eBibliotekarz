using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace ebibliotekarz
{
    internal class Tracert
    {
        public int polaczenie { get; set; }
        public bool dzialanie { get; set; }

        public void Ping()
        {
            if (PingNET())
            {
                Thread.Sleep(200);
                if (PingZUT())
                {
                    polaczenie = 0;
                }
                else
                {
                    polaczenie = -2;
                }
            }
            else
            {
                polaczenie = -1;
            }
            Thread.Sleep(200);
        }

        private bool PingNET()
        {
            var pingSender = new Ping();
            var options = new PingOptions();
            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 3000;
            PingReply reply = pingSender.Send("google.pl", timeout, buffer, options);
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }

        private bool PingZUT()
        {
            var pingSender = new Ping();
            var options = new PingOptions();
            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 3000;
            PingReply reply = pingSender.Send("82.145.73.240", timeout, buffer, options);
            if (reply.Status == IPStatus.DestinationPortUnreachable || reply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }
    }
}