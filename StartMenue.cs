using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class StartMenue
    {
        public void StartMenueAnzeigen(Charakter meinCharakter, ReiseMenue reiseMenue, Ladebalken laed)
        {
            bool zurueck = true;

            string[] menueAuswahl = { "Reisen", "Taverne", "Schmied", "Händler", "Inventar", "Stall", "Infos", "Zurück" };
            int auswahlIndex = 0;

            while (zurueck)
            {
                string sMenue = "Start Menü";
                string startMenueZurueck = "Du kehrst zum Start Menü zurück";
                Gegner gegner = Gegner.GeneriereMonster();

                //Auswahl des Menüs mit Pfeiltasten hoch oder runter. Mit Enter wird die Auswahl bestätigt.
                auswahlIndex = Menue.MenueFuehrung(menueAuswahl, sMenue, "");

                if (auswahlIndex == menueAuswahl.Length - 1)
                {
                    Console.Clear();
                }
                if (auswahlIndex == 0)
                {
                    Menue.AuswahlPlayer("Du gehst auf die Reise.");
                    ReiseMenue.ReiseMenueAnzeige(meinCharakter);

                }
                else if (auswahlIndex == 1)
                {
                    while (zurueck)
                    {
                        Menue.AuswahlPlayer("Du bist nun in der Taverne");
                        string[] taverne = { "Essen (10 Gold)", "Trinken (5 Gold)", "Schlafen (100 Gold)", "Zurück" };
                        int taverneAuswahl = Menue.MenueFuehrung(taverne, "Taverne", "Du gehrst in die Taverne zurück.");

                        if (taverneAuswahl == 0)
                        {
                            meinCharakter.Hp += 20;
                            meinCharakter.Gold -= 10;
                            Menue.AuswahlPlayer("Du hast was gegessen und deine Hp sind um 20 gesteigen.");
                        }
                        else if (taverneAuswahl == 1)
                        {
                            meinCharakter.Mana += 10;
                            meinCharakter.Gold -= 5;
                            Menue.AuswahlPlayer("Du hast was getrunken und dein Mana ist um 20 gesteigen.");
                        }
                        else if (taverneAuswahl == 2)
                        {
                            meinCharakter.Hp += 300;
                            meinCharakter.Mana += 150;
                            meinCharakter.Gold -= 100;
                            Menue.AuswahlPlayer("Du hast geschlafen und bist jetzt ausgeruht. Deine Hp sind um 300 und dein Mana um 150 gestiegen.");
                        }
                        else if (taverneAuswahl == 3)
                        {
                            Menue.AuswahlPlayer(startMenueZurueck);
                            zurueck = false;
                        }
                        Console.ReadKey();
                    }
                    zurueck = true;
                }
                else if (auswahlIndex == 2)
                {
                    Menue.AuswahlPlayer("Du bist nun in der Schmiede.");
                    string[] schmied = { "Raparieren", "Schmieden", "Zurück" };
                    Menue.MenueFuehrung(schmied, "Schmiede", startMenueZurueck);
                }
                else if (auswahlIndex == 3)
                {
                    Menue.AuswahlPlayer("Du bist nun beim Händler im Laden.");
                    string[] haendler = { "Handeln", "Zurück" };
                    Menue.MenueFuehrung(haendler, "Händler Laden", startMenueZurueck);
                }
                else if (auswahlIndex == 4)
                {
                    Menue.AuswahlPlayer("Du krammst in deinem Inventar");
                    string[] inventar = { "Zurück" };
                    Menue.MenueFuehrung(inventar, "Dein Inventar.", startMenueZurueck);
                }
                else if (auswahlIndex == 5)
                {
                    Menue.AuswahlPlayer("Du gehst in den Stall");
                    string[] reittiere = { "Zurück" };
                    Menue.MenueFuehrung(reittiere, "Deine Reittiere/Begleiter.", startMenueZurueck);
                }
                else if (auswahlIndex == 6)
                {
                    Menue.AuswahlPlayer("Du gelangst zur Charakterübersicht");
                    string[] charUebersicht = { "Zurück" };
                    Menue.Info(meinCharakter);
                    Menue.MenueFuehrung(charUebersicht, "", startMenueZurueck);
                }
                else if (auswahlIndex == 7)
                {
                    string a = "Du kehrst ins Hauptmenü zurück.";
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight / 2);
                    Console.WriteLine(a);
                    zurueck = false;
                }

                continue;

            }
        }
    }
}

