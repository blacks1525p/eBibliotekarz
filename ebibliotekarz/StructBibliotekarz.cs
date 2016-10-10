using System;
using System.Collections.Generic;
using System.Linq;

namespace ebibliotekarz
{
    public class StructBibliotekarz
    {
        protected string AUTHOR;
        protected string DOI;
        protected uint ID;
        protected string ISSN;
        protected string JOURNAL;
        protected string NOTE;
        protected string NUMBER;
        protected string PAGES;
        protected string SOURCE;
        public List<StructBibliotekarz> StrBibliotekarz = new List<StructBibliotekarz>();
        protected string TITLE;
        protected string URL;
        protected string VOLUME;
        protected string YEAR;


        public uint id
        {
            get { return ID; }
        }

        public string source
        {
            get { return SOURCE; }
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

        protected string Dzielenie(int index, List<string> data)
        {
            string[] splitter = {"={"};
            string[] temp = data[index].Split(splitter, StringSplitOptions.None);
            string wynik = temp[1].Substring(0, (temp[1].Length - 2));
            return wynik;
        }

        protected void AddToStruct(uint id, string source, string title, string journal, string volume, string number,
            string pages,
            string year, string note, string issn, string doi, string url, string author)
        {
            var data = new StructBibliotekarz();
            data.ID = id;
            data.SOURCE = source;
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
            StrBibliotekarz.Add(data);
        }

        public void Dodawanie(List<string> data)
        {
            uint countab = 0;
            for (int i = 0; i < data.Count(); i++)
            {
                if (data[i].Contains("@article"))
                {
                    AddToStruct(countab, Dzielenie(i + 1, data), Dzielenie(i + 2, data), Dzielenie(i + 3, data),
                        Dzielenie(i + 4, data),
                        Dzielenie(i + 5, data), Dzielenie(i + 6, data), Dzielenie(i + 7, data), Dzielenie(i + 8, data),
                        Dzielenie(i + 9, data), Dzielenie(i + 10, data), Dzielenie(i + 11, data),
                        Dzielenie(i + 12, data));
                    countab++;
                    i += 12;
                }
            }
        }
    }
}