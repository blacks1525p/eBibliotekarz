using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ebibliotekarz
{
    internal class StructWOS : File
    {
        private string ABSTRACT;
        private string AUTHOR;
        private string DOI;
        private string EISSN;
        private uint ID;
        private string ISSN;
        private string JOURNAL;
        private string MONTH;
        private string NUMBER;
        private string PAGES;
        public List<StructWOS> StrWOS = new List<StructWOS>();
        private string TITLE;
        private string UNIQUE_ID;
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

        public string year
        {
            get { return YEAR; }
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

        public string month
        {
            get { return MONTH; }
        }

        public string doi
        {
            get { return DOI; }
        }

        public string issn
        {
            get { return ISSN; }
        }

        public string eissn
        {
            get { return EISSN; }
        }

        public string unique_id
        {
            get { return UNIQUE_ID; }
        }

        public string Abstract
        {
            get { return ABSTRACT; }
        }

        private void AddToStruct()
        {
            var data = new StructWOS();
            data.ID = id;
            data.AUTHOR = author;
            data.TITLE = title;
            data.JOURNAL = journal;
            data.YEAR = year;
            data.VOLUME = volume;
            data.NUMBER = number;
            data.PAGES = pages;
            data.MONTH = month;
            data.DOI = doi;
            data.ISSN = issn;
            data.EISSN = eissn;
            data.UNIQUE_ID = unique_id;
            data.ABSTRACT = Abstract;
            StrWOS.Add(data);
        }

        private string[] Dzielenie(int index, List<string> fBIB, List<string> temp3)
        {
            int temp = fBIB[index].IndexOf('=');
            var temp2 = new string[2];
            if (temp != -1)
            {
                temp2[0] = fBIB[index].Substring(0, temp - 1);
                temp2[1] = fBIB[index].Substring(temp + 2);
                return temp2;
            }
            temp2[0] = null;
            temp2[1] = null;
            return temp2;
        }

        private string FAbstract(ref int i)
        {
            var sb = new StringBuilder();
            do
            {
                i++;
                sb.Append(fBIB[i]);
            } while (fBIB[i].Contains("}},") == false);
            return sb.ToString();
        }

        public uint Dodawanie(string search, int datafr, int datato)
        {
            fBIB = OpenFile("WOS", search + ".bib");
            uint countab = 0;
            int ostatnio = 0;
            var temp2 = new List<string>();
            for (int i = 0; i < fBIB.Count(); i++)
            {
                if (fBIB[i].Contains("@article"))
                {
                    i++;
                    while (fBIB[i] != "}")
                    {
                        string[] dziel = (Dzielenie(i, fBIB, temp2));
                        if (dziel[0] != null)
                        {
                            int length = dziel[1].Length;
                            ID = countab;
                            switch (dziel[0])
                            {
                                case "Author":
                                    AUTHOR = dziel[1].Remove(length - 3).Remove(0, 1);
                                    ostatnio = 1;
                                    break;
                                case "Title":
                                    TITLE = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 2;
                                    break;
                                case "Journal":
                                    JOURNAL = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 3;
                                    break;
                                case "Year":
                                    YEAR = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 4;
                                    break;
                                case "Volume":
                                    VOLUME = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 5;
                                    break;
                                case "Number":
                                    NUMBER = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 6;
                                    break;
                                case "Pages":
                                    PAGES = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 7;
                                    break;
                                case "Month":
                                    MONTH = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 8;
                                    break;
                                case "DOI":
                                    DOI = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 9;
                                    break;
                                case "ISSN":
                                    ISSN = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 10;
                                    break;
                                case "EISSN":
                                    EISSN = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 11;
                                    break;
                                case "Unique-ID":
                                    UNIQUE_ID = dziel[1].Remove(length - 3).Remove(0, 2);
                                    ostatnio = 12;
                                    break;
                                case "Abstract":
                                    ABSTRACT = dziel[1].Remove(length - 3).Remove(0, 2) + FAbstract(ref i);
                                    break;
                            }
                        }
                        else
                        {
                            int znak = fBIB[i - 1].IndexOf('=');
                            switch (ostatnio)
                            {
                                case 1:
                                    AUTHOR = fBIB[i - 1].Substring(znak + 3) + fBIB[i].Remove(fBIB[i].Length - 2);
                                    break;
                                case 2:
                                    TITLE = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 2;
                                    break;
                                case 3:
                                    JOURNAL = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 3;
                                    break;
                                case 4:
                                    YEAR = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 4;
                                    break;
                                case 5:
                                    VOLUME = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 5;
                                    break;
                                case 6:
                                    NUMBER = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 6;
                                    break;
                                case 7:
                                    PAGES = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 7;
                                    break;
                                case 8:
                                    MONTH = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 8;
                                    break;
                                case 9:
                                    DOI = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 9;
                                    break;
                                case 10:
                                    ISSN = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 10;
                                    break;
                                case 11:
                                    EISSN = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 11;
                                    break;
                                case 12:
                                    UNIQUE_ID = fBIB[i - 1].Substring(znak + 4) + fBIB[i].Remove(fBIB[i].Length - 3);
                                    ostatnio = 12;
                                    break;
                            }
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
                for (int i = 0; i < StrWOS.Count; i++)
                {
                    try
                    {
                        datetmp = Convert.ToInt32(StrWOS[i].year);
                        if (datetmp < datafr || datetmp > datato)
                        {
                            StrWOS.RemoveAt(i);
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