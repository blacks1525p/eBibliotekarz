using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;

namespace ebibliotekarz
{
    internal class WOS : POSTMet
    {
        private List<StructWOS> _listwos;

        public List<StructWOS> listwos
        {
            get { return _listwos; }
        }

        public void wos(object obiekty)
        {
            var obiektyarray = (object[]) obiekty;
            string search = obiektyarray[0].ToString();
            var datafr = (int) obiektyarray[1];
            var datato = (int) obiektyarray[2];
            CookieContainer tmpcook;
            string datasite =
                "fieldCount=1&action=search&product=UA&search_mode=GeneralSearch&SID=T1wrhMnOv4562i9azaC&max_field_count=25&max_field_notice=Notice%3A+You+cannot+add+another+field.&input_invalid_notice=Search+Error%3A+Please+enter+a+search+term.&exp_notice=Search+Error%3A+Patent+search+term+could+be+found+in+more+than+one+family+%28unique+patent+number+required+for+Expand+option%29+&input_invalid_notice_limits=+%3Cbr%2F%3ENote%3A+Fields+displayed+in+scrolling+boxes+must+be+combined+with+at+least+one+other+search+field.&sa_params=UA%7C%7CT1wrhMnOv4562i9azaC%7Chttp%3A%2F%2Fapps.webofknowledge.com%7C%27&formUpdated=true&value%28input1%29=" +
                search +
                "&value%28select1%29=TS&x=0&y=0&value%28hidInput1%29=&limitStatus=collapsed&ss_lemmatization=On&ss_spellchecking=Suggest&SinceLastVisit_UTC=&SinceLastVisit_DATE=&period=Range+Selection&range=ALL&startYear=1945&endYear=2014&update_back2search_link_param=yes&ssStatus=display%3Anone&ss_showsuggestions=ON&ss_query_language=auto&ss_numDefaultGeneralSearchFields=1&rs_sort_by=PY.D%3BLD.D%3BSO.A%3BVL.D%3BPG.A%3BAU.A";
            string datasite2 =
                "product=WOS&colName=WOS&sortBy=PY.D%3BLD.D%3BSO.A%3BVL.D%3BPG.A%3BAU.A&mode=OpenOutputService&qid=7&SID=T1wrhMnOv4562i9azaC&format=saveToFile&filters=AUTHORSIDENTIFIERS+ACCESSION_NUM+ISSN+CONFERENCE_SPONSORS+CONFERENCE_INFO+SOURCE+TITLE+AUTHORS++&mark_to=500&mark_from=1&incitesCount=27530&markFrom=1&markTo=500&save_options=bibtex";
            var templist = new List<object>();
            templist = GET("http://apps.webofknowledge.com");
            tmpcook = (CookieContainer) templist[1];
            var sitesearch = (string) templist[0];
            OrderedDictionary datasite3 = paramaters(splitter(datasite), parser(sitesearch));
            reczparams(ref datasite3, search);
            string filedata = fileadress(datasite3);
            string site = "";
            try
            {
                site = POST("http://apps.webofknowledge.com/UA_GeneralSearch.do", filedata, tmpcook);
            }
            catch
            {
                BazyTh.Endthread(2);
                File.SaveFile("WOS", search + ".bib", "");
                var StrWOS2 = new StructWOS();
                StrWOS2.Dodawanie(search, datafr, datato);
                _listwos = StrWOS2.StrWOS;
                return;
            }
            OrderedDictionary datasite4 = paramaters(splitter(datasite2), parser(site));
            reczparamf(ref datasite4, search);
            string filedata2 = fileadress(datasite4);
            Console.WriteLine("Pobieram plik");
            File.SaveFile("WOS", search + ".bib",
                POST("http://apps.webofknowledge.com/OutboundService.do?action=go&& ", filedata2, tmpcook));
            var StrWOS = new StructWOS();
            StrWOS.Dodawanie(search, datafr, datato);
            _listwos = StrWOS.StrWOS;
            File.DeleteFile("WOS", search + ".bib");
            BazyTh.Endthread(2);
        }

        private void reczparams(ref OrderedDictionary param, string search)
        {
            param["product"] = "WOS";
            param.Remove("max_field_notice");
            param.Remove("input_invalid_notice");
            param.Remove("exp_notice");
            param.Remove("sa_params");
            param.Remove("input_invalid_notice_limits");
            param["formUpdated"] = "true";
            int i;
            for (i = 0; i < param.Count; i++)
            {
                if (param[i].ToString() == "true")
                {
                    break;
                }
            }
            param.Insert(i + 1, "value%28input1%29", search);
            param.Insert(i + 2, "value%28select1%29", "TS");
            string period = param["period"].ToString().Replace(' ', '+');
            param["period"] = period;
            param.Remove("ssStatus");
            param.Add("range", "ALL");
        }

        private void reczparamf(ref OrderedDictionary param, string search)
        {
            param["product"] = "WOS";
            param["colName"] = "WOS";
            param["mode"] = "OpenOutputService";
            param["format"] = "saveToFile";
            param["filters"] =
                "AUTHORSIDENTIFIERS+ACCESSION_NUM+ISSN+CONFERENCE_SPONSORS+ABSTRACT+CONFERENCE_INFO+SOURCE+TITLE+AUTHORS++";
            param["mark_from"] = "1";
            param.Add("markFrom", "1");
            int tmp = Convert.ToInt32(param["incitesCount"]);
            if (tmp < 500)
            {
                param["mark_to"] = tmp.ToString();
                param.Add("markTo", tmp.ToString());
            }
            else
            {
                param["mark_to"] = "500";
                param.Add("markTo", "500");
            }
            param.Add("save_options", "bibtex");
            string sort = param["sortBy"].ToString().Replace(";", "%3B");
            param["sortBy"] = sort;
        }
    }
}