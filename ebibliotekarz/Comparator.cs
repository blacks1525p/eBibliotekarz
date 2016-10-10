using System.Collections.Generic;
using System.Collections.Specialized;

namespace ebibliotekarz
{
    internal delegate List<string> del(string s);

    internal class Comparator
    {
        public static OrderedDictionary Comper(OrderedDictionary data)
        {
            int licznik = 0;
            var keys = new string[data.Count];
            data.Keys.CopyTo(keys, 0);
            del list = ((string j) => { return (List<string>) data[j];});
            string source = "";
            for (int i = 0; i < list("title").Count; i++)
            {
                source = list("source")[i];
                list("note")[i] = "";
                for (int j = i + 1; j < list("title").Count; j++)
                {
                    if (list("title")[i] != "" && list("title")[j] != "")
                    {
                        if ((list("title")[i] == list("title")[j]) ||
                            (list("title")[i] == list("title")[j].Remove(list("title")[j].Length - 1)) ||
                            (list("title")[j] == list("title")[i].Remove(list("title")[i].Length - 1)))
                        {
                            if (source != list("source")[j])
                            {
                                if (list("note")[i] == "")
                                {
                                    list("note")[i] = list("source")[j];
                                }
                                else
                                {
                                    list("note")[i] = list("note")[i] + ", " + list("source")[j];
                                }
                            }
                            foreach (string klucz in keys)
                            {
                                list(klucz).RemoveAt(j);
                            }
                            licznik++;
                        }
                    }
                }
            }
            return data;
        }
    }
}