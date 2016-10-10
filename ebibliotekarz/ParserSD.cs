using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;

namespace ebibliotekarz
{
    internal class ParserSD : DownSite
    {
        private List<StructSDA> _listsd;

        public List<StructSDA> listsd
        {
            get { return _listsd; }
        }

        private List<string> Parser(string url, int wier)
        {
            var tabinput = new List<string>();
            string site;
            site = DownS(url);
            var doc = new HtmlDocument();
            doc.LoadHtml(site);
            foreach (HtmlNode input in doc.DocumentNode.SelectNodes("//input"))
            {
                tabinput.Add(input.WriteTo());
            }
            List<string> index2 = tabinput.FindAll(x => x.Contains("hidden"));
            int liczwier = 0;
            var param = new List<string>();
            foreach (string temp in index2)
            {
                string[] podziel = temp.Split(new[] {'"'});
                liczwier++;
                if (liczwier > wier)
                {
                    try
                    {
                        param.Add(podziel[5]);
                    }
                    catch
                    {
                        podziel = temp.Split(new[] {'\''});
                        try
                        {
                            param.Add(podziel[7]);
                        }
                        catch
                        {
                            param.Add(podziel[5]);
                        }
                    }
                }
            }
            return param;
        }

        private string ParserDL(string url, string search)
        {
            List<string> param = Parser(url, 11);
            string downurl;
            downurl = "0";
            try
            {
                if (param[17] == "1" || param[18] == "1")
                {
                    downurl = "http://www.sciencedirect.com/science?_ob=" + param[0] + "&_method=" + param[1] +
                              "&searchtype=" + param[2] + "&refSource=" + param[3] + "&pdfDownloadSort=" + param[4] +
                              "&PDF_DDM_MAX=" + param[5] + "&_st=" + param[6] + "&count=" + param[7] + "&sort=" +
                              param[8] + "&filterType=" + param[9] + "&_chunk=" + param[10] + "&hitCount=" + param[11] +
                              "&view=" + param[12] + "&md5=" + param[13] + "&_ArticleListID=" + param[14] +
                              "&chunkSize=" + param[15] + "&sisr_search=" + param[16] + "&TOTAL_PAGES=" + param[17] +
                              "&pdfDownload=" + param[18] + "&zone=" + param[19] +
                              "&citation-type=BIBTEX&format=cite-abs&export=Export&bottomPaginationBoxChanged=" +
                              param[20] + "&displayPerPageFlag=f&resultsPerPage=25";
                }
                else
                {
                    downurl = "http://www.sciencedirect.com/science?_ob=" + param[0] + "&_method=" + param[1] +
                              "&searchtype=" + param[2] + "&refSource=" + param[3] + "&pdfDownloadSort=" + param[4] +
                              "&PDF_DDM_MAX=" + param[5] + "&_st=" + param[6] + "&count=" + param[7] + "&sort=" +
                              param[8] + "&filterType=" + param[9] + "&_chunk=" + param[10] + "&hitCount=" + param[11] +
                              " &NEXT_LIST=" + param[12] + "&view=" + param[13] + "&md5=" + param[14] +
                              "&_ArticleListID=" + param[15] + "&chunkSize=" + param[16] + "&sisr_search=" + param[17] +
                              "&TOTAL_PAGES=" + param[18] + "&pdfDownload=" + param[19] + "&zone=" + param[20] +
                              "&citation-type=BIBTEX&format=cite-abs&export=Export&bottomPaginationBoxChanged=" +
                              param[21] + "&displayPerPageFlag=f&resultsPerPage=25";
                }
            }
            catch
            {
                Console.WriteLine("Nie odnaleziono hasla");
                return "-1";
            }
            DownF("ScienceDirect", search + ".bib", downurl);
            return downurl;
        }

        public void ParserGL(object obiekty)
        {
            var obiektyarray = (object[]) obiekty;
            string search = obiektyarray[0].ToString();
            var datafr = (int) obiektyarray[1];
            var datato = (int) obiektyarray[2];
            string url = "";
            List<string> param = Parser("http://www.sciencedirect.com/", 4);
            param.Add(search);
            url = "http://www.sciencedirect.com/science?_ob=" + param[0] + "&_method=" + param[1] + "&_acct=" + param[2] +
                  "&searchtype=" + param[3] + "&_origin=" + param[4] + "&_zone=" + param[5] + "&md5=" + param[6] +
                  "&qs_all=" + param[7] + "&qs_author=&qs_title=&qs_vol=&qs_issue=&qs_pages=&sdSearch=";
            ParserDL(url, search);
            BazyTh.Endthread(0);
            var BIBSD = new StructSDA();
            BIBSD.Dodawanie(search, datafr, datato);
            _listsd = BIBSD.StrSDA;
            File.DeleteFile("ScienceDirect", search + ".bib");
        }

        public void ParserPDF(string siteurl, string file, string dir)
        {
            string site = DownS(siteurl);
            var tab = new List<string>();
            var doc = new HtmlDocument();
            doc.LoadHtml(site);
            string znacznik = "";
            foreach (HtmlNode input in doc.DocumentNode.SelectNodes("//a[@id=\"pdfLink\" ]"))
            {
                znacznik = input.WriteTo();
            }
            string[] separator = {"=\"", "\""};
            string[] tmp = znacznik.Split(separator, StringSplitOptions.None);
            string link = tmp[5];
            var streampdf = (MemoryStream) GET(link)[2];
            File.SafeFilePDF(dir, file, streampdf);
        }
    }
}