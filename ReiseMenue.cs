﻿using System;
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
            

            string[] menueAuswahl = { "Verfluchte Stadt", "Wald", "Wüste", "Schloss des Tyrannen", "Dungeon", "Zurück" };
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
                    Menue.AuswahlPlayer("Du bist in der Stadt.");
                    if (gegner.Level > 50) //Bedingungen für den Charakter wenn der Gegner über Lvl.50 ist soll kein Monster zum Kampf angegeben werden.
                    {
                        Menue.AuswahlPlayer("Kein Monster gefunden.");
                    }
                    else if (gegner.Level > 0 && gegner.Level <= 50) //weitere Bedingung für den Kampf Monster zwischen 0 und 50 werden für den kampf angegeben.
                    {
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
                }
                else if (auswahlIndex == 1)
                {
                    Menue.AuswahlPlayer("Du bist nun im Wald.");
                    if (meinCharakter.Level <= 30)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (gegner.Level <= 30)
                    {
                        Console.WriteLine("Kein Monster gefunden.");
                    }
                    else if (gegner.Level > 30 && gegner.Level < 70)
                    {
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }

                }
                else if (auswahlIndex == 2)
                {
                    Menue.AuswahlPlayer("Du bist nun in der heißen Wüste.");
                    if (meinCharakter.Level <= 50)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (gegner.Level < 50)
                    {
                        Console.WriteLine("Kein Monster gefunden.");
                    }
                    else if (gegner.Level >= 50 && gegner.Level <= 90)
                    {
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
                }
                else if (auswahlIndex == 3)
                {
                    Menue.AuswahlPlayer("Du bist nun im Schloss von Aincrad.");
                    if (meinCharakter.Level <= 70)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (gegner.Level < 70)
                    {
                        Console.WriteLine("Kein Monster gefunden.");
                    }
                    else if (gegner.Level >= 70 && gegner.Level <= 120)
                    {
                        Gegner.ZufaelligesMonster("", meinCharakter);
                    }
                }
                else if (auswahlIndex == 4)
                {
                    Menue.AuswahlPlayer("Du begibst dich in den Dungeon.");

                    if (meinCharakter.Level <= 90)
                    {
                        Menue.AuswahlPlayer("Dein Level ist zu niedrig.");
                    }
                    else if (gegner.Level <= 90)
                    {
                        Console.WriteLine("Kein Monster gefunden.");
                    }
                    else if (gegner.Level > 90)
                    {
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