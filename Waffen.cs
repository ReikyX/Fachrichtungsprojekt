using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    public class Waffen : Gegenstaende
    {
        public Waffen (string name) : base (name) { }

        public override string AnzeigeInfo() //Rügabe an die Elternklasse
        {
            return $"Waffe: {Name}\t-\tStärke: {Wert}\t-\tGold: {gold}"; 
        }

        public static List<Gegenstaende> WaffenGenerieren(string text)
        {
            List<Gegenstaende> WaffenListe = new List<Gegenstaende>();
            Random zufall = new Random();

            string[] waffenName = { "Schwert", "Axt", "Bogen", "Speer", "Dolch" };

            for (int i = 0; i < 20; i++)
            {
                WaffenListe.Add(new Waffen(waffenName[zufall.Next(waffenName.Length)]));
            }
            WaffenListe = WaffenListe.OrderBy(g => g.Wert).ToList();
            Console.WriteLine(text);
            for (int i = 0; i < WaffenListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{WaffenListe[i].AnzeigeInfo()}");
            }

            return WaffenListe;
        }
    }
}
