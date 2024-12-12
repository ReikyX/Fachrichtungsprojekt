using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class ReiseMenue
    {
        public ReiseMenue() { }
        public void ReiseMenueAnzeige(Charakter meinCharakter)
        {
            int posUnten;
            bool zurueck = true;

            string[] menueAuswahl = { "Stadt", "Wald", "Wüste", "Schloss", "Dungeon", "Zurück" };
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
                switch (Console.ReadKey().Key)
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
                            string a = "Du bist in der Stadt.";
                            Console.Clear();
                            Console.SetCursorPosition((Console.WindowWidth - a.Length) / 2, Console.WindowHeight / 2);
                            Console.WriteLine(a);
                            //laed.Stauts();

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
}