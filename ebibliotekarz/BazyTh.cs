using System;
using System.Collections.Generic;
using System.Threading;

namespace ebibliotekarz
{
    internal class BazyTh
    {
        private static int lthread;
        private static readonly bool[] threadname = {false, false, false, false, false};
        private List<StructIEEE> _ieeelist;
        private List<StructScop> _scoplist;
        private List<StructSDA> _sdlist;
        private List<StructSpringer> _springerlist;
        private List<StructWOS> _woslist;

        public List<StructScop> scoplist
        {
            get { return _scoplist; }
        }

        public List<StructWOS> woslist
        {
            get { return _woslist; }
        }

        public List<StructSDA> sdlist
        {
            get { return _sdlist; }
        }

        public List<StructSpringer> springerlist
        {
            get { return _springerlist; }
        }

        public List<StructIEEE> ieeelist
        {
            get { return _ieeelist; }
        }

        public void Bazy(bool[] bazacheck, string search, int datefr, int dateto)
        {
            var objektyarray = new object[3];
            objektyarray[0] = search;
            objektyarray[1] = datefr;
            objektyarray[2] = dateto;
            object obiekty = objektyarray;
            var SD = new ParserSD();
            var tsd = new Thread(SD.ParserGL);
            if (bazacheck[0])
            {
                tsd.IsBackground = true;
                tsd.Start(obiekty);
            }
            else
            {
                Endthread(0);
            }
            var scopus = new Scopus();
            var tscopus = new Thread(scopus.scopus);
            if (bazacheck[1])
            {
                tscopus.IsBackground = true;
                tscopus.Start(obiekty);
            }
            else
            {
                Endthread(1);
            }
            var wos = new WOS();
            var twos = new Thread(wos.wos);
            if (bazacheck[2])
            {
                twos.IsBackground = true;
                twos.Start(obiekty);
            }
            else
            {
                Endthread(2);
            }
            var springer = new Springer();
            var tspringer = new Thread(springer.springer);
            if (bazacheck[3])
            {
                tspringer.IsBackground = true;
                tspringer.Start(obiekty);
            }
            else
            {
                Endthread(3);
            }
            var ieee = new IEEE();
            var tieee = new Thread(ieee.ieee);
            if (bazacheck[4])
            {
                tieee.IsBackground = true;
                tieee.Start(obiekty);
            }
            else
            {
                Endthread(4);
            }
            if (bazacheck[0])
            {
                tsd.Join();
                _sdlist = SD.listsd;
            }
            else
            {
                var SDnon = new List<StructSDA>();
                _sdlist = SDnon;
            }
            if (bazacheck[1])
            {
                tscopus.Join();
                _scoplist = scopus.listscopus;
            }
            else
            {
                var Scopnon = new List<StructScop>();
                _scoplist = Scopnon;
            }
            if (bazacheck[2])
            {
                twos.Join();
                _woslist = wos.listwos;
            }
            else
            {
                var wosnon = new List<StructWOS>();
                _woslist = wosnon;
            }

            if (bazacheck[3])
            {
                tspringer.Join();
                _springerlist = springer.listspringer;
            }
            else
            {
                var sprnon = new List<StructSpringer>();
                _springerlist = sprnon;
            }

            if (bazacheck[4])
            {
                tieee.Join();
                _ieeelist = ieee.listieee;
            }
            else
            {
                var ieeenon = new List<StructIEEE>();
                _ieeelist = ieeenon;
            }

            Console.WriteLine("Gotowe");
            //   Console.ReadKey();            
        }

        public static void Endthread(int index)
        {
            lthread++;
            //backgroundWorker1.ReportProgress(BazyTh.Getlthread());
            threadname[index] = true;
        }

        public static int Getlthread()
        {
            return lthread;
        }

        public static bool[] Getnamethread()
        {
            return threadname;
        }
    }
}