using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Menue
    {
        public Menue()
        {

        }

        public void MenueAnzeige() //Methode Menü
        {
            int posUnten;

            string[] menueAuswahl = { "Spiel Starten", "Einstellungen", "Infos", "Beenden" };
            int auswahlIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t      Hauptmenü");

                posUnten = Console.WindowHeight - 8; //Positions Deklaration
                Console.SetCursorPosition(0, posUnten); //Positionsbestimmung in der Konsole

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
                ConsoleKeyInfo pfeilInfo = Console.ReadKey(true);
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
                        Console.ReadKey(true);
                        break;
                }   
            }
        }
    }
}
