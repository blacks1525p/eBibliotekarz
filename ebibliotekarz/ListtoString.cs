using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace ebibliotekarz
{
    internal class ListtoString
    {
        public static string Parser(OrderedDictionary data)
        {
            var tmpdata = new List<string>();
            var keys = new string[data.Count];
            data.Keys.CopyTo(keys, 0);
            var datastring = new StringBuilder();
            for (int i = 0; i < ((List<string>) data[keys[0]]).Count; i++)
            {
                datastring.AppendLine("@article{");
                for (int j = 0; j < keys.Length; j++)
                {
                    datastring.Append(keys[j]);
                    datastring.Append("={");
                    datastring.Append(((List<string>) data[keys[j]])[i]);
                    datastring.AppendLine("},");
                }
                datastring.AppendLine("}");
                datastring.AppendLine();
            }
            return datastring.ToString();
        }

        public static List<string> ParserAll(OrderedDictionary data)
        {
            var tmpdata = new List<string>();
            var keys = new string[data.Count];
            data.Keys.CopyTo(keys, 0);
            var datastring = new List<string>();
            var sb = new StringBuilder();
            for (int i = 0; i < ((List<string>) data[keys[0]]).Count; i++)
            {
                datastring.Add("@article{");
                for (int j = 0; j < keys.Length; j++)
                {
                    sb.Append(keys[j]);
                    sb.Append("={");
                    sb.Append(((List<string>) data[keys[j]])[i]);
                    sb.Append("},");
                    datastring.Add(sb.ToString());
                    sb.Clear();
                }
                datastring.Add("}");
                datastring.Add("");
            }
            return datastring;
        }
    }
}