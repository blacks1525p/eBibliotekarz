using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace ebibliotekarz
{
    internal class PDFParser
    {
        private static int licznik;
        public int[] IEEE;
        public int[] Science;
        public int[] Springer;

        public void pdfparser(OrderedDictionary links, OrderedDictionary title, string dir)
        {
            del llinks = delegate(string baza) { return (List<string>) links[baza]; };
            del ltitle = delegate(string baza) { return (List<string>) title[baza]; };
            int licznikscience = 0;
            int licznikspringer = 0;
            int licznikIEEE = 0;
            Science = new int[llinks("Science").Count];
            Springer = new int[llinks("Springer").Count];
            IEEE = new int[llinks("IEEE").Count];
            var SD = new ParserSD();
            foreach (string link in llinks("Science"))
            {
                try
                {
                    SD.ParserPDF(link, NameParser(ltitle("Science")[licznikscience]) + ".pdf", dir);
                    Science[licznikscience] = 1;
                    licznikscience++;
                    licznik++;
                }
                catch
                {
                    Science[licznikscience] = -1;
                    licznikscience++;
                    licznik++;
                }
            }
            var spr = new Springer();
            foreach (string link in llinks("Springer"))
            {
                try
                {
                    spr.ParserPDF(link, NameParser(ltitle("Springer")[licznikspringer]) + ".pdf", dir);
                    Springer[licznikspringer] = 1;
                    licznikspringer++;
                    licznik++;
                }
                catch
                {
                    Springer[licznikspringer] = -1;
                    licznikspringer++;
                    licznik++;
                }
            }
            var ieee = new IEEE();
            foreach (string link in llinks("IEEE"))
            {
                try
                {
                    ieee.ParserPDF(link, NameParser(ltitle("IEEE")[licznikIEEE]) + ".pdf", dir);
                    IEEE[licznikIEEE] = 1;
                    licznikIEEE++;
                    licznik++;
                }
                catch
                {
                    IEEE[licznikIEEE] = -1;
                    licznikIEEE++;
                    licznik++;
                }
            }
        }

        public static int Getlicznik()
        {
            return licznik;
        }

        public static void Zerujlicznik()
        {
            licznik = 0;
        }

        public void Sprzataj()
        {
            Science = null;
            Springer = null;
            IEEE = null;
        }

        private string NameParser(string title)
        {
            string pattern = "[#%&*:?/\\|]";
            string replacement = "";
            var rgx = new Regex(pattern);
            return rgx.Replace(title, replacement);
        }

        private delegate List<string> del(string baza);
    }
}