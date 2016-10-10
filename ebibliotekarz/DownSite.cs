using System;
using System.Net;

namespace ebibliotekarz
{
    internal class DownSite : FileGetSite
    {
        protected static string DownS(string URL)
        {
            string site = "";
            using (var client = new WebClient())
            {
                client.Headers["User-Agent"] =
                    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                    "(compatible; MSIE 6.0; Windows NT 5.1; " +
                    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
                try
                {
                    site = client.DownloadString(URL);
                }
                catch (WebException)
                {
                    Console.WriteLine("Blad polaczenia.");
                    Console.WriteLine("Czy ponowic probe?");
                    char znak = '5';
                    while (znak != 'n' || znak != 'N' || znak != 'T' || znak != 't')
                    {
                        ConsoleKeyInfo znaktemp = Console.ReadKey(true); //zmienic na okienko
                        znak = znaktemp.KeyChar;
                        if (znak == 't' || znak == 'T')
                        {
                            Console.WriteLine("Ponawiam probe.");
                            DownS(URL);
                            break;
                        }
                        if (znak == 'n' || znak == 'N')
                        {
                            Environment.Exit(-1);
                        }
                    }
                }
                return site;
            }
        }
    }
}