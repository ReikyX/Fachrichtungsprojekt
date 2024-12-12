using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Menue
    {
        private int auswahlIndex = 0;
        public Menue()
        {

        }

        public void MenueAnzeige(Charakter meinCharakter, Ladebalken laed, StartMenue startMenue, ReiseMenue reiseMenue) //Methode Menü
        {
            int posUnten;
            string hauptmenue = "Hauptmenü";
            string[] menueAuswahl = { "Spiel Starten", "Einstellungen", "Infos", "Beenden" };
            auswahlIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - hauptmenue.Length) / 2, Console.WindowHeight - 25);
                Console.WriteLine(hauptmenue);

                //https://stackoverflow.com/questions/21917203/how-do-i-center-text-in-a-console-application
                Console.SetCursorPosition(0, Console.WindowHeight - 8); //Positionsbestimmung in der Konsole

                //Schleife für die Auswahl des Menüs
                for (int i = 0; i < menueAuswahl.Length; i++)
                {
                    Console.CursorVisible = false; //Cursor unsichtbar
                    if (i == auswahlIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t\t\t  >   {menueAuswahl[i]}   <  ");
                    }
                    else
                    {
                        Console.WriteLine($"\t\t\t\t\t\t{menueAuswahl[i]}");
                    }
                    Console.ResetColor();
                }

                //Auswahl des Menüs mit Pfeiltasten hoch oder runter. Mit Enter wird die Auswahl bestätigt.
                ConsoleKeyInfo pfeilInfo = Console.ReadKey();
                switch (pfeilInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        auswahlIndex = (auswahlIndex - 1 + menueAuswahl.Length) % menueAuswahl.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        auswahlIndex = (auswahlIndex + 1) % menueAuswahl.Length;
                        break;
                    case ConsoleKey.Enter:
                        if (auswahlIndex == menueAuswahl.Length - 1)
                        {
                            Console.Clear();
                            return;
                        }
                        if (auswahlIndex == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("\t\t\t\t\t\t Spiel wird gestartet");
                            //laed.Stauts();
                            startMenue.StartMenueAnzeigen(meinCharakter, reiseMenue, laed);
                        }
                        else if (auswahlIndex == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Hier sind die Einstellungen");
                        }
                        else if (auswahlIndex == 2)
                        {
                            Console.Clear();
                            Info(meinCharakter);
                        }

                        Console.ReadKey();
                        break;
                }
            }
        }

        public void Info(Charakter meinCharakter)
        {
            Console.WriteLine("\t\t\t\t\tHier sind deine Infos zu deinem Charakter\n\n\n");
            Console.WriteLine($"\t\t\t\t\t\tName:\t\t{meinCharakter.CharakterName}");
            Console.WriteLine($"\t\t\t\t\t\tRasse:\t\t{meinCharakter.GewaehlteRasse}");
            Console.WriteLine($"\t\t\t\t\t\tLevel:\t\t{meinCharakter.Level}/{meinCharakter.MaxLevel}");
            Console.WriteLine($"\t\t\t\t\t\tExp:\t\t{meinCharakter.Exp}/{meinCharakter.MaxExp}");
            Console.WriteLine($"\t\t\t\t\t\tMana\t\t{meinCharakter.Mana}");
            Console.WriteLine($"\t\t\t\t\t\tStärke:\t\t{meinCharakter.Staerke}");
            Console.WriteLine($"\t\t\t\t\t\tIntelligenz:\t{meinCharakter.Intelligenz}");
        }


        private int MenueFuehrung(string[] menueAuswahl)
        {
            auswahlIndex = 0;
            while (true)
            {
                DisplayMenue(menueAuswahl);
                //Auswahl des Menüs mit Pfeiltasten hoch oder runter. Mit Enter wird die Auswahl bestätigt.
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        auswahlIndex = (auswahlIndex - 1 + menueAuswahl.Length) % menueAuswahl.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        auswahlIndex = (auswahlIndex + 1) % menueAuswahl.Length;
                        break;
                    case ConsoleKey.Enter:

                        Console.Clear();
                        return auswahlIndex;
                }
            }
        }
        private void DisplayMenue(string[] menueAuswahl)
        {
            Console.Clear();
            Console.SetCursorPosition(0, Console.WindowHeight - 10); //Positionsbestimmung in der Konsole

            //Schleife für die Auswahl des Menüs
            for (int i = 0; i < menueAuswahl.Length; i++)
            {
                Console.CursorVisible = false; //Cursor unsichtbar
                if (i == auswahlIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.WriteLine($"\t\t\t\t\t\t  >   {menueAuswahl[i]}   <  ");
                }
                else
                {
                    Console.WriteLine($"\t\t\t\t\t\t{menueAuswahl[i]}");
                }
                Console.ResetColor();
            }

        }
    }
}
