using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aincrad
{
    internal class Gegner
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int HP { get; set; }
        public int Staerke { get; set; }

        public static List<Gegner> gegnerListe;
        public static Random zufall;
        public static int zufallGegnerIndex = 0;
        public void MonsterGenerieren() //Methode zum Generieren der Gegner
        {
            gegnerListe = new List<Gegner>();
            zufall = new Random();
            //String[] wurde mittels KI generiert
            string[] gegnerNamen = {"Goblin", "Ork", "Troll", "Drache", "Skelett", "Zombie", "Vampir", "Werwolf",
            "Chimäre", "Hydra", "Oger", "Zyklop", "Harpyie", "Basilisk", "Phönix",
            "Riese", "Banshee", "Ghoul", "Lich", "Golem","Dämon"};

            for (int i = 0; i < 200; i++) //Schleife läuft 200 mal durch.(200 Gegner)
            {
                int level = zufall.Next(1, 201);//Hier wird immer eine zufällige Zahl zwischen 1 und 200 genommen. 201 ist ausgeschlossen.
                gegnerListe.Add(new Gegner //Generiertes Objekt wird in die Liste hinzugefügt
                {
                    Name = gegnerNamen[zufall.Next(gegnerNamen.Length)],
                    Level = level,
                    HP = level * zufall.Next(5, 21),
                    Staerke = level + zufall.Next(1, 11)
                });
            }
            gegnerListe = gegnerListe.OrderBy(g => g.Level).ToList(); //Ordnet die Liste nach Level aufsteigend
        }


        public static void ZufaelligesMonster(string text, Charakter meinCharakter)
        {
            Gegner zufaelligesMonster = gegnerListe[zufallGegnerIndex]; //Übergabe eines zufälligen Objekts aus der Liste 
            bool weiter = true;
            while (weiter)
            {
                if (zufaelligesMonster.HP <= 0)
                {
                    break;
                }
                Console.SetCursorPosition((Console.WindowWidth - text.Length) - 94, Console.WindowHeight - 20);
                Console.WriteLine($"Ein Monster ist erschienen: {zufaelligesMonster.Name}, Level: {zufaelligesMonster.Level}, HP: {zufaelligesMonster.HP}, Stärke: {zufaelligesMonster.Staerke}");
                Console.SetCursorPosition((Console.WindowWidth - text.Length) - 83, Console.WindowHeight - 17);
                Console.WriteLine("Möchtest du gegen das Monster kämpfen? (j/n)");
                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 15);
                string antwort = Console.ReadLine().ToLower().Trim();

                if (antwort == "j")
                {
                    KampfSystem.CharakterVsGegner(meinCharakter, zufaelligesMonster, "Der Kampf beginnt!");//Methoden aufruf für den Kampf
                }
                else if (antwort == "n")
                {
                    Menue.AuswahlPlayer("Du machst dich aus dem Staub.");
                    weiter = false;
                }
                else
                {
                    Menue.AuswahlPlayer("Keine gültige eingabe");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            }
        }        
        
        public static Gegner AuswahlZufaelligesMonster() //Zufälliger Gegner wird ausgewählt
        {
            zufallGegnerIndex = zufall.Next(gegnerListe.Count);
            return gegnerListe[zufallGegnerIndex];
        }

    }
}


