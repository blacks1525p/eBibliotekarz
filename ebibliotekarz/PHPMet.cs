using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace ebibliotekarz
{
    internal class PHPMet
    {
        private HttpWebRequest request;
        private HttpWebResponse response;

        protected List<object> GET(string URL)
        {
            Console.WriteLine("Wysylam zadanie GET do strony: {0}", URL);
            request = (HttpWebRequest) WebRequest.Create(URL);
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.CookieContainer = new CookieContainer();
            request.Timeout = 30000;
            response = (HttpWebResponse) request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            var memdata = new MemoryStream();
            dataStream.CopyTo(memdata);
            memdata.Seek(0, SeekOrigin.Begin);
            var reader = new StreamReader(memdata);
            var lista = new List<object>();
            lista.Add(reader.ReadToEnd());
            memdata.Seek(0, SeekOrigin.Begin);
            lista.Add(request.CookieContainer);
            response.Close();
            dataStream.Close();
            lista.Add(memdata);
            return lista;
        }

        //protected Stream GET(string URL)
        //{
        //    Console.WriteLine("Wysylam zadanie GET do strony: {0}", URL);
        //    request = (HttpWebRequest)WebRequest.Create(URL);
        //    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
        //    request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
        //    request.CookieContainer = new CookieContainer();
        //    response = (HttpWebResponse)request.GetResponse();
        //    Stream dataStream = response.GetResponseStream();
        //    return dataStream;
        //}
        protected string POST(string URL, string data, CookieContainer cook)
        {
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            request = (HttpWebRequest) WebRequest.Create(URL);
            request.Method = "POST";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:32.0) Gecko/20100101 Firefox/32.0";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.CookieContainer = cook;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.Timeout = 300000;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            response = (HttpWebResponse) request.GetResponse();
            dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            string readerdata = reader.ReadToEnd();
            response.Close();
            dataStream.Close();
            reader.Close();
            return readerdata;
        }
    }
}