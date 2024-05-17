using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viragok
{
    internal class Virag
    {
        public string _nev;
        public int _ar;
        public string _szin;
        public string _kep;

        public Virag(string nev, int ar, string szin, string kep)
        {
            _nev = nev;
            _ar = ar;
            _szin = szin;
            _kep = kep;
        }
        public Virag(string sor)
        {
            var adatok = sor.Split(';').ToList();
            _nev = adatok[0];
            _ar = int.Parse(adatok[1]);
            _szin = adatok[2];
            _kep = adatok[3];
        }
    }
}
