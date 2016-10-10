using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace ebibliotekarz
{
    internal class CSVtoListPar
    {
        public static OrderedDictionary Parser(string dir, string file)
        {
            List<string> CSV = File.OpenFile(dir, file);
            var data = new OrderedDictionary();
            string[] pola = CSV[0].Split(',');

            for (int i = 0; i < pola.Length; i++)
            {
                pola[i] = pola[i].Replace("\"", null);
                data.Add(pola[i], ParsLines(CSV, i));
            }
            return data;
        }

        private static List<string> ParsLines(List<string> CSV, int pole)
        {
            var param = new List<string>();
            string[] separator = {"\","};
            string[] tmp;
            for (int i = 1; i < CSV.Count; i++)
            {
                tmp = CSV[i].Split(separator, StringSplitOptions.None);
                if (tmp[0] != "")
                {
                    for (int j = 0; j < tmp.Length; j++)
                    {
                        if (tmp[j] != "")
                        {
                            tmp[j] = tmp[j].Remove(0, 1);
                        }
                    }
                    if (tmp.Length <= pole)
                    {
                        param.Add(null);
                    }
                    else
                    {
                        param.Add(tmp[pole]);
                    }
                }
            }
            return param;
        }
    }
}