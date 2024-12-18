using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    public class Ruestungen : Gegenstaende
    {

        public Ruestungen(string name) : base(name) { }

        public override string AnzeigeInfo()//Rückgabe an die Elternklasse
        {
            return $"Rüstung: {Name}\t\t-\t\tVerteidigung: {Wert}\t-\tGold: {gold}";
        }

        public static List<Gegenstaende> RuestungGenerieren(string text)
        {
            List<Gegenstaende> RuestungenListe = new List<Gegenstaende>();
            Random zufall = new Random();

            string[] ruestungName = { "Helm", "Rüstung", "Schild", "Stiefel", "Handschuhe" };

            for (int i = 0; i < 20; i++)
            {
                RuestungenListe.Add(new Ruestungen(ruestungName[zufall.Next(ruestungName.Length)]));
            }
            RuestungenListe = RuestungenListe.OrderBy(g => g.Wert).ToList();
            Console.WriteLine(text);
            for (int i = 0; i < RuestungenListe.Count; i++)
            {
                Console.WriteLine($"{i + 1}\t{RuestungenListe[i].AnzeigeInfo()}");
            }
            return RuestungenListe;
        }
    }
}
