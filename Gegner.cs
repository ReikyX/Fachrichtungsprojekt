using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Gegner
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Staerke { get; set; }

        public static void Monster()
        {
            List<Gegner> gegnerListe = new List<Gegner>();
            Random zufall = new Random();

            string[] gegnerNamen = {"Goblin", "Ork", "Troll", "Drache", "Skelett", "Zombie", "Vampir", "Werwolf",
            "Chimäre", "Hydra", "Oger", "Zyklop", "Harpyie", "Basilisk", "Phönix",
            "Riese", "Banshee", "Ghoul", "Lich", "Golem","Dämon"};

            for (int i = 0; i < 100; i++)
            {
                int level = zufall.Next(1, 101);
                gegnerListe.Add(new Gegner
                {
                    Name = gegnerNamen[zufall.Next(gegnerNamen.Length)],
                    Level = level,
                    HP = level * zufall.Next(5, 21),
                    Staerke = level + zufall.Next(1, 11)
                });

            }
            gegnerListe = gegnerListe.OrderBy(g => g.Level).ToList();

            foreach (var gegner in gegnerListe)
            {
                Console.WriteLine($"Name: {gegner.Name}\t\tLevel: {gegner.Level}\t\tHP: {gegner.HP}\t\tStärke: {gegner.Staerke}");
            }

            Gegner zufaelligerGegner = gegnerListe[zufall.Next(gegnerListe.Count)];
        }

        public static void ZufaelligerGegner()
        {
            Random zufall = new Random();

        }
    }
}


