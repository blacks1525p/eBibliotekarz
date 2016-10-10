using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;

namespace ebibliotekarz
{
    internal class IEEE : POSTMet
    {
        private List<StructIEEE> _listieee;

        public List<StructIEEE> listieee
        {
            get { return _listieee; }
        }

        public void ieee(object obiekty)
        {
            var obiektyarray = (object[]) obiekty;
            string search = obiektyarray[0].ToString();
            var datafr = (int) obiektyarray[1];
            var datato = (int) obiektyarray[2];
            CookieContainer tmpcook;
            string filedata = "bulkSetSize=1000%26queryText%253D" + search;
            var templist = new List<object>();
            templist = GET("http://ieeexplore.ieee.org/Xplore/home.jsp");
            tmpcook = (CookieContainer) templist[1];
            Console.WriteLine("Pobieram plik");
            File.SaveFile("IEEE", search + "tmp.csv",
                POST("http://ieeexplore.ieee.org/search/searchExport.jsp", filedata, tmpcook));
            List<string> tmpCSV = File.OpenFile("IEEE", search + "tmp.csv");
            tmpCSV.RemoveAt(0);
            var tmp = new StringBuilder();
            foreach (string element in tmpCSV)
            {
                tmp.AppendLine(element);
            }
            File.DeleteFile("IEEE", search + "tmp.csv");
            File.SaveFile("IEEE", search + ".csv", tmp.ToString());
            OrderedDictionary data = CSVtoListPar.Parser("IEEE", search + ".csv");
            var structieee = new StructIEEE();
            structieee.Dodawanie(data, datafr, datato);
            _listieee = structieee.StrIEEE;
            File.DeleteFile("IEEE", search + ".csv");
            //File.SaveFile("IEEE", search + ".bib", ListtoString.Parser(data));
            //File.DeleteFile("IEEE", search + ".csv");
            BazyTh.Endthread(4);
        }

        public void ParserPDF(string siteurl, string file, string dir)
        {
            var site = (string) GET(siteurl)[0];
            var tab = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(site);
            foreach (HtmlNode input in doc.DocumentNode.SelectNodes("//frame"))
            {
                tab.Add(input.WriteTo());
            }
            string znacznik = "";
            foreach (string element in tab)
            {
                if (element.Contains("pdf"))
                {
                    znacznik = element;
                }
            }
            string[] separator = {"=\"", "\""};
            string[] tmp = znacznik.Split(separator, StringSplitOptions.None);
            string link = tmp[1];
            var streampdf = (MemoryStream) GET(link)[2];
            File.SafeFilePDF(dir, file, streampdf);
        }
    }
}