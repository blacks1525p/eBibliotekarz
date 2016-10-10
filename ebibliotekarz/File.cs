using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ebibliotekarz
{
    internal class File
    {
        public static void DeleteFile(string dir, string file)
        {
            var F = new FileInfo(".\\BIBTEX\\" + dir + "\\" + file);
            if (F.Exists)
            {
                F.Delete();
            }
        }

        public static void SaveFile(string dir, string file, string data)
        {
            if (!Directory.Exists(".\\BIBTEX\\" + dir))
            {
                Directory.CreateDirectory(".\\BIBTEX\\" + dir);
            }
            var fs = new FileStream(".\\BIBTEX\\" + dir + "\\" + file, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                var sw = new StreamWriter(fs);
                sw.Write(data);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void SaveFile(string dir, string file, List<string> ldata)
        {
            var fs = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
            string data = Inicjaly(ldata);
            try
            {
                var sw = new StreamWriter(fs);
                sw.Write(data);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void SafeFilePDF(string dir, string pfile, MemoryStream data)
        {
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            int bufferSize = 8192;
            var buffer = new byte[bufferSize];
            int bytesRead = 0;

            string file = dir + "\\" + pfile;
            // Read from response and write to file
            FileStream fileStream = System.IO.File.Create(file);
            while ((bytesRead = data.Read(buffer, 0, bufferSize)) != 0)
            {
                fileStream.Write(buffer, 0, bytesRead);
            } // end while
            fileStream.Close();
            // Define buffer and buffer size
            data.Close();
        }

        public static List<string> OpenFile(string dir, string pfile)
        {
            FileStream file;
            try
            {
                if (dir != null)
                {
                    file = new FileStream(".\\BIBTEX\\" + dir + "\\" + pfile, FileMode.Open, FileAccess.Read);
                }
                else
                {
                    file = new FileStream(pfile, FileMode.Open, FileAccess.Read);
                }
            }
            catch
            {
                Console.WriteLine("Nie znaleziono pliku");
                var error = new List<string>();
                error.Add("-1");
                return error;
            }
            var FILE = new StreamReader(file);
            var linefile = new List<string>();
            while (!FILE.EndOfStream)
            {
                linefile.Add(FILE.ReadLine());
            }
            linefile.Add(FILE.ReadToEnd());
            FILE.Close();
            return linefile;
        }

        public static bool Sprawdzenie(List<string> data)
        {
            string[] splitter = {"MD5="};
            string[] temp = data[0].Split(splitter, StringSplitOptions.None);
            string hashcheck = "";
            try
            {
                hashcheck = temp[1];
            }
            catch
            {
                return false;
            }            
            data.RemoveAt(0);
            data.RemoveAt(data.Count - 1);
            using (MD5 Hashfunction = MD5.Create())
            {
                string hash = Hashfun.GetMd5Hash(Hashfunction, ToString(data));
                return Hashfun.VerifyMd5Hash(Hashfunction, ToString(data), hashcheck);
            }
        }

        private static string Inicjaly(List<string> data)
        {
            string stringdata = ToString(data);
            using (MD5 Hashfunction = MD5.Create())
            {
                string hash = Hashfun.GetMd5Hash(Hashfunction, stringdata);
                data.Insert(0, "Plik zostal stworzony przez program ebibliotekarz. MD5=" + hash);
            }
            return ToString(data);
        }

        public static string ToString(List<string> data)
        {
            var datastring = new StringBuilder();
            foreach (string element in data)
            {
                datastring.Append(element);
                datastring.AppendLine();
            }
            return datastring.ToString();
        }
    }
}