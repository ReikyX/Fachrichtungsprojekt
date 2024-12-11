using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class StartMenue
    {
        public void StartMenueAnzeigen(Charakter meinCharakter, Ladebalken laed)
        {
            int posUnten;
            bool zurueck = true;

            string[] menueAuswahl = { "Reisen", "Taverne", "Schmied", "Händler", "Inventar", "Reittiere/Begleiter", "Infos", "Zurück" };
            int auswahlIndex = 0;

            while (zurueck)
            {
                string sMenü = "Start Menü";
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - sMenü.Length) / 2, Console.WindowHeight - 25);
                Console.WriteLine(sMenü);

                
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

                        }

                        if (auswahlIndex == 0)
                        {
                            string a = "Du gehst auf die Reise.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight / 2);
                            Console.WriteLine(a);
                            //laed.Stauts();

                        }
                        else if (auswahlIndex == 1)
                        {
                            string a = "Du bist nun in der Taverne";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                            Console.WriteLine(a);
                        }
                        else if (auswahlIndex == 2)
                        {
                            string a = "Du bist in der Schmiede.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                            Console.WriteLine(a);
                        }
                        else if (auswahlIndex == 3)
                        {
                            string a = "Du bist nun beim Händler im Laden.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                            Console.WriteLine(a);
                        }
                        else if (auswahlIndex == 4)
                        {
                            string a = "Dein Inventar.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                            Console.WriteLine(a);
                        }
                        else if (auswahlIndex == 5)
                        {
                            string a = "Deine Reittiere/Begleiter.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight - 25);
                            Console.WriteLine(a);
                        }
                        else if (auswahlIndex == 6)
                        {
                            string a = "Dein Aktueller Status:\n\n";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight / 2);
                            Console.WriteLine(a);
                            Console.WriteLine($"\t\t\t\t\t\tName:\t\t{meinCharakter.CharakterName}");
                            Console.WriteLine($"\t\t\t\t\t\tRasse:\t\t{meinCharakter.GewaehlteRasse}");
                            Console.WriteLine($"\t\t\t\t\t\tLevel:\t\t{meinCharakter.Level}/{meinCharakter.MaxLevel}");
                            Console.WriteLine($"\t\t\t\t\t\tExp:\t\t{meinCharakter.Exp}/{meinCharakter.MaxExp}");
                            Console.WriteLine($"\t\t\t\t\t\tMana\t\t{meinCharakter.Mana}");
                            Console.WriteLine($"\t\t\t\t\t\tStärke:\t\t{meinCharakter.Staerke}");
                            Console.WriteLine($"\t\t\t\t\t\tIntelligenz:\t{meinCharakter.Intelligenz}");
                        }
                        else if (auswahlIndex == 7)
                        {
                            string a = "Du kehrst ins Hauptmenü zurück.";
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
}
