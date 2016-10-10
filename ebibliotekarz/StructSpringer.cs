using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ebibliotekarz
{
    internal class StructSpringer
    {
        protected string AUTHOR;
        protected string DOI;
        protected uint ID;
        protected string JOURNAL;
        public List<StructSpringer> StrSpri = new List<StructSpringer>();
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

        public string year
        {
            get { return YEAR; }
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

        protected void AddToStruct(uint id, string title, string journal, string volume,
            string year, string doi, string url, string author)
        {
            var data = new StructSpringer();
            data.ID = id;
            data.TITLE = title;
            data.JOURNAL = journal;
            data.VOLUME = volume;
            data.YEAR = year;
            data.DOI = doi;
            data.URL = url;
            data.AUTHOR = author;
            StrSpri.Add(data);
        }

        public void Dodawanie(OrderedDictionary data, int datafr, int datato)
        {
            var keys = new string[data.Count];
            data.Keys.CopyTo(keys, 0);

            for (int i = 0; i < ((List<string>) data[0]).Count; i++)
            {
                AddToStruct((uint) i, ((List<string>) data[0])[i], ((List<string>) data[4])[i],
                    ((List<string>) data[3])[i],
                    ((List<string>) data[7])[i], ((List<string>) data[5])[i], ((List<string>) data[8])[i],
                    ((List<string>) data[6])[i]);
            }
            int datetmp = 0;
            if (datafr != 0)
            {
                for (int i = 0; i < StrSpri.Count; i++)
                {
                    try
                    {
                        datetmp = Convert.ToInt32(StrSpri[i].year);
                        if (datetmp < datafr || datetmp > datato)
                        {
                            StrSpri.RemoveAt(i);
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