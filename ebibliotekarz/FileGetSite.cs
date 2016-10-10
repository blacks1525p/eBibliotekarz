using System;
using System.IO;
using System.Net;
using System.Text;

namespace ebibliotekarz
{
    internal class FileGetSite : PHPMet
    {
        protected static void DownF(string dir, string file, string URL)
        {
            if (!Directory.Exists(".\\BIBTEX\\" + dir))
            {
                Directory.CreateDirectory(".\\BIBTEX\\" + dir);
            }

            var fs = new FileStream(".\\BIBTEX\\" + dir + "\\" + file, FileMode.Create, FileAccess.ReadWrite);
            var client = new WebClient();

            client.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
                "(compatible; MSIE 6.0; Windows NT 5.1; " +
                ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            try
            {
                var bib = new StreamWriter(fs);
                Console.WriteLine("Pobieram plik: " + file);
                byte[] temp = client.DownloadData(URL);
                string download = Encoding.UTF8.GetString(temp);
                bib.Write(download);
                bib.Close();
                Console.WriteLine("Zakonczono powodzeniem");
            }
            catch (WebException Ex)
            {
                Console.WriteLine(Ex.Message);
                //Console.ReadKey();
                // System.Environment.Exit(-1);
                fs.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}