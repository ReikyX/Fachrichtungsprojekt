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
                            if (meinCharakter.Gold >= 10)
                            {
                                if (meinCharakter.Hp >= 980)
                                {
                                    Menue.AuswahlPlayer("Du hast deine Maximale Gesundheit erreicht.");
                                    meinCharakter.Hp = meinCharakter.MaxHp;
                                }
                                else
                                {
                                    meinCharakter.Hp += 20;
                                    meinCharakter.Gold -= 10;
                                    Menue.AuswahlPlayer("Du hast was gegessen und deine Hp sind um 20 gestiegen.");
                                }
                            }
                            else
                            {
                                Menue.AuswahlPlayer("Nicht genug Gold!");
                            }
                        }
                        else if (taverneAuswahl == 1)
                        {
                            if (meinCharakter.Gold >= 5)
                            {
                                if (meinCharakter.Mana >= 490)
                                {
                                    Menue.AuswahlPlayer("Dein Mana hat das Maximum erreicht.");
                                    meinCharakter.Mana = meinCharakter.MaxMana;
                                }
                                else
                                {
                                    meinCharakter.Mana += 10;
                                    meinCharakter.Gold -= 5;
                                    Menue.AuswahlPlayer("Du hast was getrunken und dein Mana ist um 10 gesteigen.");
                                }
                            }
                            else
                            {
                                Menue.AuswahlPlayer("Nicht genug Gold!");
                            }
                        }
                        else if (taverneAuswahl == 2)
                        {
                            if (meinCharakter.Gold >= 100)
                            {
                                if (meinCharakter.Hp >= 700 || meinCharakter.Mana >= 350)
                                {
                                    if (meinCharakter.Hp >= 700 && meinCharakter.Mana <= 350)
                                    {
                                        Menue.AuswahlPlayer("Du hast deine Maximale Gesundheit erreicht. Dein Mana hat sich um 150 erhöht.");
                                        meinCharakter.Hp = meinCharakter.MaxHp;
                                        meinCharakter.Mana += 150;
                                        meinCharakter.Gold -= 100;
                                    }
                                    if (meinCharakter.Mana >= 350 && meinCharakter.Hp <= 700)
                                    {
                                        Menue.AuswahlPlayer("Dein Mana hat das Maximum erreicht. Deine Gesundheit ist um 300 gestiegen.");
                                        meinCharakter.Mana = meinCharakter.MaxMana;
                                        meinCharakter.Hp += 300;
                                        meinCharakter.Gold -= 100;
                                    }
                                    if (meinCharakter.Hp >= 700 && meinCharakter.Mana >= 350)
                                    {
                                        Menue.AuswahlPlayer("Dein Mana und deine Gesundheit haben das Maximum erreicht.");
                                        meinCharakter.Mana = meinCharakter.MaxMana;
                                        meinCharakter.Hp = meinCharakter.MaxHp;
                                    }
                                }
                                else
                                {
                                    meinCharakter.Hp += 300;
                                    meinCharakter.Mana += 150;
                                    meinCharakter.Gold -= 100;
                                    Menue.AuswahlPlayer("Du hast geschlafen und bist jetzt ausgeruht. Deine Gesundheit ist um 300 und dein Mana um 150 gestiegen.");
                                }
                            }
                            else
                            {
                                Menue.AuswahlPlayer("Nicht genug Gold!");
                            }
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
                        string[] haendler = { "Waffen", "Rüstung", "Tränke", "Verkaufen", "Zurück" };
                        int haendlerauswahl = Menue.MenueFuehrung(haendler, "Händler Laden", startMenueZurueck);//Auswahl des Benutzers wird in einer Integer Variable gespeichert.
                        if (haendlerauswahl == 0)
                        {
                            Console.Clear();
                            List<Gegenstaende> verfuegbareWaffen = Waffen.WaffenGenerieren("Händler: Dies sind meine Waffen:\n");//Waffen werden generiert und an in der Liste gespeichert bzw. an die Liste übergeben.
                            Console.Write("\n\nWähle deine Waffe die du kaufen möchtest aus: ");
                            if (int.TryParse(Console.ReadLine(), out int auswahl)) //TryParse mit KI optimiert
                            {
                                auswahl--; //hier wird die auswahl -1 gesetzt weil der Index bei 0 beginnt
                                if (auswahl >= 0 && auswahl < verfuegbareWaffen.Count)
                                {
                                    Gegenstaende ausgewaehlteWaffe = verfuegbareWaffen[auswahl];
                                    if (meinCharakter.Gold >= ausgewaehlteWaffe.gold)
                                    {
                                        meinCharakter.Gold -= ausgewaehlteWaffe.gold;
                                        meinCharakter.Staerke += ausgewaehlteWaffe.Wert;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteWaffe.Name} für {ausgewaehlteWaffe.gold} Gold gekauft.");
                                        Charakter.HinzufuegenInventar(verfuegbareWaffen[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
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
                                        meinCharakter.Gold -= ausgewaehlteRuestung.gold;
                                        meinCharakter.Verteidigung += ausgewaehlteRuestung.Wert;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteRuestung.Name} für {ausgewaehlteRuestung.gold} Gold gekauft.");
                                        Charakter.HinzufuegenInventar(verfuegbareRuestungen[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
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
                            Console.Write("\n\nWähle deinen Trank den du kaufen möchtest aus: ");
                            if (int.TryParse(Console.ReadLine(), out int auswahl))
                            {
                                auswahl--;
                                if (auswahl >= 0 && auswahl < verfuegbareTraenke.Count)
                                {
                                    Gegenstaende ausgewaehlteTraenke = verfuegbareTraenke[auswahl];
                                    if (meinCharakter.Gold >= ausgewaehlteTraenke.gold)
                                    {
                                        meinCharakter.Gold -= ausgewaehlteTraenke.gold;
                                        meinCharakter.Hp += ausgewaehlteTraenke.Wert;
                                        Menue.AuswahlPlayer($"Du hast {ausgewaehlteTraenke.Name} für {ausgewaehlteTraenke.gold} Gold gekauft.");
                                        Charakter.HinzufuegenInventar(verfuegbareTraenke[auswahl]);//Ausgewählte Waffe wird einer neuen Liste hinzugefügt
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
                            if (Charakter.Inventar.Count <= 0)
                            {
                                Menue.AuswahlPlayer("Du hast keine Items in deinem Inventar");
                            }
                            else
                            {
                                var inventarListe = Charakter.Inventar.Select(obj => $"Item: {obj.Name}   Wert: {obj.Wert}   Gold:{obj.gold}").ToList();
                                inventarListe.Add("Zurück");
                                string[] inventar = inventarListe.ToArray();
                                int ausgewaehlterGegenstand = Menue.MenueFuehrung(inventar, "Verkaufen.", startMenueZurueck);
                                if (ausgewaehlterGegenstand >= 0 && ausgewaehlterGegenstand < Charakter.Inventar.Count)
                                {
                                    var verkaufterGegenstand = Charakter.Inventar[ausgewaehlterGegenstand];
                                    Charakter.Inventar.RemoveAt(ausgewaehlterGegenstand);
                                    meinCharakter.Gold += verkaufterGegenstand.gold;
                                    Menue.AuswahlPlayer($"{verkaufterGegenstand} wurde für {verkaufterGegenstand.gold} Gold verkauft.");
                                }
                                else if (ausgewaehlterGegenstand == inventar.Length -1)
                                {
                                    Menue.AuswahlPlayer("Verkauf wurde abgebrochen");
                                }
                                else
                                {
                                    KampfSystem.UngueltigGueltig("Ungültige auswahl");
                                }
                            }

                        }
                        else if (haendlerauswahl == 4)
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

