using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    public class Traenke : Gegenstaende
    {
        public Traenke(string name) : base(name) { }

        public override string AnzeigeInfo()
        {
            return $"Trank: {Name}\t\t-\t\tHp Heilung: {Wert}";
        }

        public static void TraenkeGenerieren(string text)
        {
            List<Gegenstaende> TraenkeListe = new List<Gegenstaende>();
            Random zufall = new Random();

            string[] traenkeName = { "Helm", "Rüstung", "Schild", "Stiefel", "Handschuhe" };

            for (int i = 0; i < 20; i++)
            {
                TraenkeListe.Add(new Traenke(traenkeName[zufall.Next(traenkeName.Length)]));
            }
            TraenkeListe = TraenkeListe.OrderBy(g => g.Wert).ToList();
            Console.WriteLine(text);

            for (int i = 0; i < TraenkeListe.Count; i++)
            {
                Console.WriteLine($"{i+1}\t{TraenkeListe[i].AnzeigeInfo()}");
            }
        }
    }
}
