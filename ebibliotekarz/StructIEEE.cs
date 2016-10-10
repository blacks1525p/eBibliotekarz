using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ebibliotekarz
{
    internal class StructIEEE
    {
        protected string ABSTRACT;
        protected string AUTHOR;
        protected string DOI;
        protected uint ID;
        protected string ISSN;
        protected string JOURNAL;
        protected string PAGES;
        public List<StructIEEE> StrIEEE = new List<StructIEEE>();
        protected string TITLE;
        protected string URL;
        protected string VOLUME;
        protected string YEAR;


        public uint id
        {
            get { return ID; }
        }

        public string title
        {
            get { return TITLE; }
        }

        public string journal
        {
            get { return JOURNAL; }
        }

        public string volume
        {
            get { return VOLUME; }
        }

        public string pages
        {
            get { return PAGES; }
        }

        public string year
        {
            get { return YEAR; }
        }

        public string issn
        {
            get { return ISSN; }
        }

        public string doi
        {
            get { return DOI; }
        }

        public string url
        {
            get { return URL; }
        }

        public string author
        {
            get { return AUTHOR; }
        }

        public string Abstract
        {
            get { return ABSTRACT; }
        }

        protected void AddToStruct(uint id, string title, string journal, string volume, string pages,
            string year, string issn, string doi, string url, string author, string Abstract)
        {
            var data = new StructIEEE();
            data.ID = id;
            data.TITLE = title;
            data.JOURNAL = journal;
            data.VOLUME = volume;
            data.PAGES = pages;
            data.YEAR = year;
            data.ISSN = issn;
            data.DOI = doi;
            data.URL = url;
            data.AUTHOR = author;
            data.ABSTRACT = Abstract;
            StrIEEE.Add(data);
        }

        public void Dodawanie(OrderedDictionary data, int datafr, int datato)
        {
            var keys = new string[data.Count];
            data.Keys.CopyTo(keys, 0);

            int ipage = 0;
            string page = "";

            for (int i = 0; i < ((List<string>) data[0]).Count; i++)
            {
                try
                {
                    ipage = Convert.ToInt32(((List<string>) data[9])[i]) - Convert.ToInt32(((List<string>) data[9])[i]);
                    page = ipage.ToString();
                }
                catch
                {
                    page = "";
                }
                AddToStruct((uint) i, ((List<string>) data[0])[i], ((List<string>) data[3])[i],
                    ((List<string>) data[6])[i],
                    page, ((List<string>) data[5])[i], ((List<string>) data[11])[i],
                    ((List<string>) data[14])[i], ((List<string>) data[15])[i], ((List<string>) data[1])[i],
                    ((List<string>) data[10])[i]);
            }
            int datetmp = 0;
            if (datafr != 0)
            {
                for (int i = 0; i < StrIEEE.Count; i++)
                {
                    try
                    {
                        datetmp = Convert.ToInt32(StrIEEE[i].year);
                        if (datetmp < datafr || datetmp > datato)
                        {
                            StrIEEE.RemoveAt(i);
                            i--;
                        }
                    }
                    catch
                    {
                    }
                }
            }
        }
    }
}