using System;
using System.Collections.Generic;
using System.Linq;

namespace ebibliotekarz
{
    internal class StructScop : File
    {
        private string ABSTRACT;
        private string ART_NUMBER;
        private string AUTHOR;
        private string DOCUMENT_TYPE;
        private uint ID;
        private string JOURNAL;
        private string NOTE;
        private string NUMBER;
        private string PAGES;
        private string SOURCE;
        public List<StructScop> StrScop = new List<StructScop>();
        private string TITLE;
        private string URL;
        private string VOLUME;
        private string YEAR;
        private List<string> fBIB = new List<string>();

        public uint id
        {
            get { return ID; }
        }

        public string author
        {
            get { return AUTHOR; }
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

        public string art_number
        {
            get { return ART_NUMBER; }
        }

        public string url
        {
            get { return URL; }
        }

        public string document_type
        {
            get { return DOCUMENT_TYPE; }
        }

        public string source
        {
            get { return SOURCE; }
        }

        public string Abstract
        {
            get { return ABSTRACT; }
        }

        private void AddToStruct()
        {
            var data = new StructScop();
            data.ID = id;
            data.AUTHOR = author;
            data.TITLE = title;
            data.JOURNAL = journal;
            data.VOLUME = volume;
            data.NUMBER = number;
            data.PAGES = pages;
            data.YEAR = year;
            data.NOTE = note;
            data.ART_NUMBER = art_number;
            data.URL = url;
            data.DOCUMENT_TYPE = document_type;
            data.SOURCE = source;
            data.ABSTRACT = Abstract;
            StrScop.Add(data);
        }

        private string[] Dzielenie(int index, List<string> fBIB)
        {
            int temp = fBIB[index].IndexOf('=');
            var temp2 = new string[2];
            if (temp != -1)
            {
                temp2[0] = fBIB[index].Substring(0, temp);
                temp2[1] = fBIB[index].Substring(temp + 2);
                return temp2;
            }
            temp2[0] = "";
            temp2[1] = "";
            return temp2;
        }

        public uint Dodawanie(string search, int datafr, int datato)
        {
            fBIB = OpenFile("Scopus", search + ".BIB");
            int j;
            uint countab = 0;
            for (int i = 0; i < fBIB.Count(); i++)
            {
                if (fBIB[i].Contains("@ARTICLE"))
                {
                    i++;
                    while (fBIB[i] != "}")
                    {
                        string temp = (Dzielenie(i, fBIB)[1]);
                        int length = temp.Length;
                        ID = countab;
                        switch (Dzielenie(i, fBIB)[0])
                        {
                            case "author":
                                AUTHOR = temp.Remove(length - 2);
                                break;
                            case "title":
                                TITLE = temp.Remove(length - 2);
                                break;
                            case "journal":
                                JOURNAL = temp.Remove(length - 2);
                                break;
                            case "volume":
                                VOLUME = temp.Remove(length - 2);
                                break;
                            case "number":
                                NUMBER = temp.Remove(length - 2);
                                break;
                            case "pages":
                                PAGES = temp.Remove(length - 2);
                                break;
                            case "year":
                                YEAR = temp.Remove(length - 2);
                                break;
                            case "note":
                                NOTE = temp.Remove(length - 2);
                                break;
                            case "art_number":
                                ART_NUMBER = temp.Remove(length - 2);
                                break;
                            case "url":
                                URL = temp.Remove(length - 2);
                                break;
                            case "document_type":
                                DOCUMENT_TYPE = temp.Remove(length - 2);
                                break;
                            case "source":
                                SOURCE = temp.Remove(length - 2);
                                break;
                            case "abstract":
                                ABSTRACT = temp.Remove(length - 2);
                                break;
                        }
                        i++;
                    }
                    AddToStruct();
                    countab++;
                }
            }
            int datetmp = 0;
            if (datafr != 0)
            {
                for (int i = 0; i < StrScop.Count; i++)
                {
                    try
                    {
                        datetmp = Convert.ToInt32(StrScop[i].year);
                        if (datetmp < datafr || datetmp > datato)
                        {
                            StrScop.RemoveAt(i);
                            i--;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            return countab;
        }
    }
}