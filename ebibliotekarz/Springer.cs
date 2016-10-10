using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using HtmlAgilityPack;

namespace ebibliotekarz
{
    internal class Springer : DownSite
    {
        private List<StructSpringer> _listspringer;

        public List<StructSpringer> listspringer
        {
            get { return _listspringer; }
        }

        public void springer(object obiekty)
        {
            var obiektyarray = (object[]) obiekty;
            string search = obiektyarray[0].ToString();
            var datafr = (int) obiektyarray[1];
            var datato = (int) obiektyarray[2];
            DownF("Springer", search + ".csv", "http://link.springer.com/search/csv?query=" + search);
            OrderedDictionary data = CSVtoListPar.Parser("Springer", search + ".csv");
            var structspri = new StructSpringer();
            structspri.Dodawanie(data, datafr, datato);
            _listspringer = structspri.StrSpri;
            File.DeleteFile("Springer", search + ".csv");
            //File.SaveFile("Springer", search + ".bib", ListtoString.Parser(data));
            BazyTh.Endthread(3);
        }

        public void ParserPDF(string siteurl, string file, string dir)
        {
            string site = DownS(siteurl);
            var tab = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(site);
            string znacznik = "";
            try
            {
                foreach (
                    HtmlNode input in doc.DocumentNode.SelectNodes("//a[@id=\"action-bar-download-book-pdf-link\" ]"))
                {
                    znacznik = input.WriteTo();
                }
            }
            catch
            {
                foreach (
                    HtmlNode input in
                        doc.DocumentNode.SelectNodes("//a[@id=\"abstract-actions-download-article-pdf-link\" ]"))
                {
                    znacznik = input.WriteTo();
                }
            }
            string[] separator = {"href="};
            string[] tmp = znacznik.Split(separator, StringSplitOptions.None);
            string[] tmp2 = tmp[1].Split('"');
            string link = tmp2[1];
            link = "http://link.springer.com" + link;
            var streampdf = (MemoryStream) GET(link)[2];
            File.SafeFilePDF(dir, file, streampdf);
        }
    }
}