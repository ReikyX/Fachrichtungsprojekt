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
            string[] menueAuswahl = { "Reisen", "Taverne", "Händler", "Inventar", "Infos", "Zurück" };
            int auswahlIndex = 0;

            while (zurueck) //Schleife für das Start Menü bis die Auswahl zurück erfolgt.
            {
                string sMenue = "Start Menü";
                string startMenueZurueck = "Du kehrst zum Start Menü zurück";
                Gegner gegner = Gegner.AuswahlZufaelligesMonster(); //Auswahl eines zufälligen Gegners

                //Auswahl des Menüs mit Pfeiltasten hoch oder runter. Mit Enter wird die Auswahl bestätigt.
                auswahlIndex = Menue.MenueFuehrung(menueAuswahl, sMenue, ""); //Rückgabe in vorm von einem Integers an auswahlIndex

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
                        //Bedingungen je nach Auswahl
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
                    while (zurueck)
                    {
                        Menue.AuswahlPlayer("Du bist nun beim Händler im Laden.");
                        string[] haendler = { "Waffen", "Rüstung", "Tränke", "Zurück" };
                        int haendlerauswahl = Menue.MenueFuehrung(haendler, "Händler Laden", startMenueZurueck);//Auswahl des Benutzers wird in einer Integer Variable gespeichert.
                        if (haendlerauswahl == 0)
                        {
                            Console.Clear();
                            List<Gegenstaende> verfuegbareWaffen = Waffen.WaffenGenerieren("Händler: Dies sind meine Waffen:\n");//Waffen werden generiert und an in der Liste gespeichert bzw. an die Liste übergeben.
                            Console.Write("\n\nWähle deine Waffe die du kaufen möchtest aus: ");
                            if (int.TryParse(Console.ReadLine(), out int auswahl))
                            {
                                auswahl--;
                                if (auswahl >= 0 && auswahl < verfuegbareWaffen.Count)
                                {
                                    Gegenstaende ausgewaehlteWaffe = verfuegbareWaffen[auswahl];
                                    if (meinCharakter.Gold >= ausgewaehlteWaffe.gold)
                                    {
                                        Charakter.HinzufuegenInventar(verfuegbareWaffen[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
                                        meinCharakter.Gold -= ausgewaehlteWaffe.gold;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteWaffe.Name} für {ausgewaehlteWaffe.gold} Gold gekauft.");
                                    }
                                    else
                                    {
                                        Menue.AuswahlPlayer("Du hast nicht genügend Gold.");
                                    }
                                }
                                else
                                {
                                    Menue.AuswahlPlayer("Bitte gib eine gültige Zahl ein.");
                                }
                                Console.ReadKey();
                            }
                            else { KampfSystem.UngueltigGueltig("Keine Gültige eingabe!"); }
                        }
                        else if (haendlerauswahl == 1)
                        {
                            Console.Clear();
                            List<Gegenstaende> verfuegbareRuestungen = Ruestungen.RuestungGenerieren("Händler: Dies sind meine Rüstungen:\n");
                            Console.Write("\n\nWähle deine Ausrüstung die du kaufen möchtest aus: ");
                            if (int.TryParse(Console.ReadLine(), out int auswahl))
                            {
                                auswahl--;
                                if (auswahl >= 0 && auswahl < verfuegbareRuestungen.Count)
                                {
                                    Gegenstaende ausgewaehlteRuestung = verfuegbareRuestungen[auswahl];
                                    if (meinCharakter.Gold >= ausgewaehlteRuestung.gold)
                                    {
                                        Charakter.HinzufuegenInventar(verfuegbareRuestungen[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
                                        meinCharakter.Gold -= ausgewaehlteRuestung.gold;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteRuestung.Name} für {ausgewaehlteRuestung.gold} Gold gekauft.");
                                    }
                                    else
                                    {
                                        Menue.AuswahlPlayer("Du hast nicht genügend Gold.");
                                    }
                                }
                                else
                                {
                                    Menue.AuswahlPlayer("Bitte gib eine gültige Zahl ein.");
                                }
                                Console.ReadKey();
                            }
                            else { KampfSystem.UngueltigGueltig("Keine Gültige eingabe!"); }
                        }
                        else if (haendlerauswahl == 2)
                        {
                            Console.Clear();
                            List<Gegenstaende> verfuegbareTraenke = Traenke.TraenkeGenerieren("Händler: Dies sind meine Tränke:\n");
                            Console.Write("\n\nWähle deine Waffe die du kaufen möchtest aus: ");
                            if (int.TryParse(Console.ReadLine(), out int auswahl))
                            {
                                auswahl--;
                                if (auswahl >= 0 && auswahl < verfuegbareTraenke.Count)
                                {
                                    Gegenstaende ausgewaehlteTraenke = verfuegbareTraenke[auswahl];
                                    if (meinCharakter.Gold >= ausgewaehlteTraenke.gold)
                                    {
                                        Charakter.HinzufuegenInventar(verfuegbareTraenke[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
                                        meinCharakter.Gold -= ausgewaehlteTraenke.gold;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteTraenke.Name} für {ausgewaehlteTraenke.gold} Gold gekauft.");
                                    }
                                    else
                                    {
                                        Menue.AuswahlPlayer("Du hast nicht genügend Gold.");
                                    }
                                }
                                else
                                {
                                    Menue.AuswahlPlayer("Bitte gib eine gültige Zahl ein.");
                                }
                                Console.ReadKey();
                            }
                            else { KampfSystem.UngueltigGueltig("Keine Gültige eingabe!"); }
                        }
                        else if (haendlerauswahl == 3)
                        {
                            Menue.AuswahlPlayer(startMenueZurueck);
                            zurueck = false;
                        }
                    }
                    zurueck = true;
                }
                else if (auswahlIndex == 3)
                {
                    Menue.AuswahlPlayer("Du krammst in deinem Inventar");
                    //Konvertiert das Inventar in ein Array von Strings
                    //Select Methode -> wandelt jedes Objekt im Inventar in einen String um.
                    //Das Ergebnis wird hier zu einer Array konvertiert mit der Methode ToArray().
                    string[] inventar = Charakter.Inventar.Select(obj => $"Item: {obj.Name}   Wert: {obj.Wert}").ToArray();
                    Menue.MenueFuehrung(inventar, "Dein Inventar.", startMenueZurueck);
                }
                else if (auswahlIndex == 4)
                {
                    Menue.AuswahlPlayer("Du gelangst zur Charakterübersicht");
                    string[] charUebersicht = { "Zurück" };
                    Menue.Info(meinCharakter);
                    Menue.MenueFuehrung(charUebersicht, "", startMenueZurueck);
                }
                else if (auswahlIndex == 5)
                {
                    Menue.AuswahlPlayer("Du kehrst ins Hauptmenü zurück.");
                    zurueck = false;
                }
                continue;
            }
        }
    }
}

