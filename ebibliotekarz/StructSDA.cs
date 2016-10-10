using System;
using System.Collections.Generic;
using System.Linq;

namespace ebibliotekarz
{
    internal class StructSDA : File
    {
        protected string ABSTRACT;
        protected string AUTHOR;
        protected string DOI;
        protected uint ID;
        protected string ISSN;
        protected string JOURNAL;
        protected List<string> KEYWORDS = new List<string>();
        protected string NOTE;
        protected string NUMBER;
        protected string PAGES;
        public List<StructSDA> StrSDA = new List<StructSDA>();
        protected string TITLE;
        protected string URL;
        protected string VOLUME;
        protected string YEAR;
        private List<string> fBIB = new List<string>();

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

        public string number
        {
            get { return NUMBER; }
        }

        public string pages
        {
            get { return PAGES; }
        }

        public string year
        {
            get { return YEAR; }
        }

        public string note
        {
            get { return NOTE; }
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

        public List<string> keywords
        {
            get { return KEYWORDS; }
        }

        public string Abstract
        {
            get { return ABSTRACT; }
        }

        protected string Dzielenie(int index, List<string> fBIB)
        {
            string[] temp = fBIB[index].Split('"');
            return temp[1];
        }

        protected string fabstract(int j)
        {
            if (fBIB[j].Contains("abstract ="))
            {
                return (Dzielenie(j, fBIB));
            }
            return ("");
        }

        protected void AddToStruct(uint id, string title, string journal, string volume, string number, string pages,
            string year, string note, string issn, string doi, string url, string author, List<string> keywords,
            string Abstract)
        {
            var data = new StructSDA();
            data.ID = id;
            data.TITLE = title;
            data.JOURNAL = journal;
            data.VOLUME = volume;
            data.NUMBER = number;
            data.PAGES = pages;
            data.YEAR = year;
            data.NOTE = note;
            data.ISSN = issn;
            data.DOI = doi;
            data.URL = url;
            data.AUTHOR = author;
            data.KEYWORDS = keywords;
            data.ABSTRACT = Abstract;
            StrSDA.Add(data);
        }

        public void Dodawanie(string search, int datafr, int datato)
        {
            fBIB = OpenFile("ScienceDirect", search + ".BIB");
            int j;
            uint countab = 0;
            for (int i = 0; i < fBIB.Count(); i++)
            {
                if (fBIB[i].Contains("@article"))
                {
                    var key = new List<string>();
                    j = i + 12;
                    while (fBIB[j].Contains("abstract =") != true && fBIB[j].Contains("}") != true)
                    {
                        key.Add(Dzielenie(j, fBIB));
                        j++;
                    }
                    AddToStruct(countab, Dzielenie(i + 1, fBIB), Dzielenie(i + 2, fBIB), Dzielenie(i + 3, fBIB),
                        Dzielenie(i + 4, fBIB),
                        Dzielenie(i + 5, fBIB), Dzielenie(i + 6, fBIB), Dzielenie(i + 7, fBIB), Dzielenie(i + 8, fBIB),
                        Dzielenie(i + 9, fBIB), Dzielenie(i + 10, fBIB), Dzielenie(i + 11, fBIB), key, fabstract(j));
                    countab++;
                    i = j;
                }
            }
            int datetmp = 0;
            if (datafr != 0)
            {
                for (int i = 0; i < StrSDA.Count; i++)
                {
                    try
                    {
                        datetmp = Convert.ToInt32(StrSDA[i].year);
                        if (datetmp < datafr || datetmp > datato)
                        {
                            StrSDA.RemoveAt(i);
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