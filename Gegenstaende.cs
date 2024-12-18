using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    //Für Abstrakte Klassen wurde KI zum aufklären genutzt.
    public abstract class Gegenstaende //Abstrakte Klasse zur förderung der Wiederverwendbarkeit
                                       //Dient als Basisklasse für andere Klassen und diefniert eine gemeinsame Schnittstelle
    {
        public string Name { get; set; }
        public int Wert {  get; set; }
        public int gold { get; set; }

        public Gegenstaende(string name)
        {
            Name = name;
            Random zufall = new Random();
            Wert = zufall.Next(1, 101);
            gold = Wert * 2;
        }
        public abstract string AnzeigeInfo(); //Methode muss von abgeleitetr Klasse überschrieben werden
    }
}
