using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class ReiseMenue
    {
        public static void ReiseMenueAnzeige(Charakter meinCharakter,Gegner gegner)
        {
            bool zurueck = true;

            string[] menueAuswahl = { "Stadt", "Wald", "Wüste", "Schloss", "Dungeon", "Zurück" };
            int auswahlIndex = 0;

            while (zurueck)
            {
                string rMenue = "Reise Menü";
                string reiseMenueZurueck = "Du kehrst zum Reise Menü zurück";

                auswahlIndex = Menue.MenueFuehrung(menueAuswahl, rMenue, "");

                if (auswahlIndex == menueAuswahl.Length - 1)
                {
                    Console.Clear();
                }
                if (auswahlIndex == 0)
                {
                    Menue.AuswahlPlayer("Du bist in der Stadt.");

                    gegner.ZufaelligesMonster();

                    Console.ReadKey();
                    
                }
                else if (auswahlIndex == 1)
                {
                    string a = "Du bist im Wald.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                    Console.WriteLine(a);
                }
                else if (auswahlIndex == 2)
                {
                    string a = "Du bist nun in der heißen Wüste.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                    Console.WriteLine(a);
                }
                else if (auswahlIndex == 3)
                {
                    string a = "Du bist nun im Schloss von Aincrad.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                    Console.WriteLine(a);
                }
                else if (auswahlIndex == 4)
                {
                    string a = "Du begibst dich in den Dungeon.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                    Console.WriteLine(a);
                }
                else if (auswahlIndex == 5)
                {
                    string a = "Du kehrst zum Start Menü zurück.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight / 2);
                    Console.WriteLine(a);
                    zurueck = false;
                }
                Console.ReadKey();
                continue;
            }
        }
    }
}