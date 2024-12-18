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
        public static void ReiseMenueAnzeige(Charakter meinCharakter)
        {
            bool zurueck = true;


            string[] menueAuswahl = { "Verfluchte Stadt (Lv.1)", "Wald (Lv.30)", "Wüste (Lv.50)", "Schloss des Tyrannen (Lv.70)", "Dungeon (Lv.90)", "Zurück" };
            int auswahlIndex = 0;

            while (zurueck)
            {
                Gegner gegner = Gegner.AuswahlZufaelligesMonster();
                string rMenue = "Reise Menü";
                string reiseMenueZurueck = "Du kehrst zum Reise Menü zurück";

                auswahlIndex = Menue.MenueFuehrung(menueAuswahl, rMenue, "");

                if (auswahlIndex == menueAuswahl.Length - 1)
                {
                    Console.Clear();
                }
                if (auswahlIndex == 0)
                {
                    Menue.AuswahlPlayer("Du bist in der Verluchten Stadt.");
                    do
                    {
                        gegner = Gegner.AuswahlZufaelligesMonster();
                    }
                    while (gegner.Level >= 50);
                    Gegner.ZufaelligesMonster("", meinCharakter);
                }
                else if (auswahlIndex == 1)
                {
                    Menue.AuswahlPlayer("Du bist nun im Wald.");
                    if (meinCharakter.Level < 30)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (meinCharakter.Level >= 30)
                    {
                        do
                        {
                            gegner = Gegner.AuswahlZufaelligesMonster();
                        }
                        while (gegner.Level <= 50 || gegner.Level >= 70);
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
                }
                else if (auswahlIndex == 2)
                {
                    Menue.AuswahlPlayer("Du bist nun in der heißen Wüste.");
                    if (meinCharakter.Level < 50)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (meinCharakter.Level >= 50)
                    {
                        do
                        {
                            gegner = Gegner.AuswahlZufaelligesMonster();
                        }
                        while (gegner.Level <= 50 || gegner.Level >= 90);
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }

                }
                else if (auswahlIndex == 3)
                {
                    Menue.AuswahlPlayer("Du bist nun im Schloss des Tyrannen.");

                    if (meinCharakter.Level < 70)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (meinCharakter.Level >= 70)
                    {
                        do
                        {
                            gegner = Gegner.AuswahlZufaelligesMonster();
                        }
                        while (gegner.Level <= 70 || gegner.Level >= 120);
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
                }
                else if (auswahlIndex == 4)
                {
                    Menue.AuswahlPlayer("Du begibst dich in den Dungeon.");

                    if (meinCharakter.Level < 90)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (meinCharakter.Level >= 90)
                    {
                        do
                        {
                            gegner = Gegner.AuswahlZufaelligesMonster();
                        }
                        while (gegner.Level <= 90);
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
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