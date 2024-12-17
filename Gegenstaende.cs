using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    public abstract class Gegenstaende
    {
        public string Name { get; set; }
        public int Wert {  get; set; }

        public Gegenstaende(string name)
        {
            Name = name;
            Random zufall = new Random();
            Wert = zufall.Next(0, 101);
        }

        public abstract string AnzeigeInfo();
    }
}
