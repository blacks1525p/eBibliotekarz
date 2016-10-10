using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using HtmlAgilityPack;

namespace ebibliotekarz
{
    internal class POSTMet : PHPMet
    {
        protected List<string> splitter(string text)
        {
            int licznik = 0;
            string[] split = text.Split('&', '=');
            var split2 = new List<string>();
            for (int i = 0; i < split.Length; i++)
            {
                if (licznik%2 == 0)
                {
                    split[i] = "name=\"" + split[i] + "\"";
                    split2.Add(split[i]);
                }
                licznik++;
            }
            return split2;
        }

        protected string paramcut(string key)
        {
            int lznak = key.IndexOf("name=\"") + "name=\"".Length;
            char znak = '"';
            string val = "";
            while (key[lznak] != znak)
            {
                val = val + key[lznak];
                lznak++;
            }
            return val;
        }

        protected List<string> parser(string site)
        {
            var doc = new HtmlDocument();
            var tabinput = new List<string>();
            doc.LoadHtml(site);
            foreach (HtmlNode input in doc.DocumentNode.SelectNodes("//input"))
            {
                tabinput.Add(input.WriteTo());
            }
            List<string> index2 = tabinput.FindAll(x => x.Contains("value"));
            return index2;
        }

        protected OrderedDictionary paramaters(List<string> keys, List<string> value)
        {
            var param = new OrderedDictionary();
            string oldkey = "";
            foreach (string key in keys)
            {
                if (value.Any(x => x.Contains(key)))
                {
                    try
                    {
                        param.Add(paramcut(key), value.Find(x => x.Contains(key)));
                    }
                    catch
                    {
                        if (key != oldkey)
                        {
                            var mparam = new List<string>();
                            mparam = value.FindAll(x => x.Contains(key));
                            param[paramcut(key)] = mparam;
                        }
                        oldkey = key;
                    }
                }
                else
                {
                    Console.WriteLine("Nie znaleziono elementu: {0}", key);
                }
            }
            for (int i = 0; i < param.Count; i++)
            {
                if (param[i].GetType().ToString() == "System.String")
                {
                    string tmp;
                    tmp = param[i].ToString();
                    int lznak = tmp.IndexOf("value=\"") + "value=\"".Length;
                    char znakend = '"';
                    string val = "";
                    while (tmp[lznak] != znakend)
                    {
                        val = val + tmp[lznak];
                        lznak++;
                    }
                    param[i] = val;
                }
                else
                {
                    var element = (List<string>) param[i];
                    for (int j = 0; j < element.Count; j++)
                    {
                        string tmp = element[j];
                        int lznak = tmp.IndexOf("value=\"") + "value=\"".Length;
                        char znakend = '"';
                        string val = "";
                        while (tmp[lznak] != znakend)
                        {
                            val = val + tmp[lznak];
                            lznak++;
                        }
                        element[j] = val;
                    }
                }
            }
            //reczparam(ref param, search);
            return param;
        }

        protected string fileadress(OrderedDictionary datasite)
        {
            string gotdata = "";
            ICollection datakey = datasite.Keys;
            var sdatakey = new string[datakey.Count];
            datakey.CopyTo(sdatakey, 0);
            for (int i = 0; i < datasite.Count; i++)
            {
                if (datasite[i].GetType().ToString() == "System.String")
                {
                    gotdata = gotdata + sdatakey[i] + "=" + datasite[i] + "&";
                }
                else
                {
                    var element = (List<string>) datasite[i];
                    for (int j = 0; j < element.Count; j++)
                    {
                        gotdata = gotdata + sdatakey[i] + "=" + element[j] + "&";
                    }
                }
            }
            return gotdata;
        }
    }
}