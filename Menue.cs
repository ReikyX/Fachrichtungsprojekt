using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Aincrad
{
    internal class Menue
    {
        public static int auswahlIndex = 0;
        public static void MenueAnzeige(Charakter meinCharakter, Ladebalken laed, StartMenue startMenue, ReiseMenue reiseMenue,Gegner gegner) //Methode Hauptmenü
        {
            string hauptmenue = "Hauptmenü";
            string[] menueAuswahl = { "Spiel Starten", "Einstellungen", "Infos", "Beenden" };
            auswahlIndex = 0;

            while (true)
            {
                auswahlIndex = MenueFuehrung(menueAuswahl, hauptmenue, "");

                if (auswahlIndex == menueAuswahl.Length - 1)
                {
                    Console.Clear();
                    return;
                }
                if (auswahlIndex == 0)
                {
                    AuswahlPlayer("Spiel wird gestartet");
                    startMenue.StartMenueAnzeigen(meinCharakter, gegner,reiseMenue, laed);
                }
                else if (auswahlIndex == 1)
                {
                    AuswahlPlayer("Hier sind die Einstellungen");
                }
                else if (auswahlIndex == 2)
                {
                    Console.Clear();
                    Info(meinCharakter);
                }
                else if (auswahlIndex == 3)
                { 
                break;
                }
                
             }
        }

        public static void Info(Charakter meinCharakter)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tHier sind deine Infos zu deinem Charakter\n\n\n");
            Console.WriteLine($"\t\t\t\t\t\tName:\t\t{meinCharakter.CharakterName}");
            Console.WriteLine($"\t\t\t\t\t\tRasse:\t\t{meinCharakter.GewaehlteRasse}");
            Console.WriteLine($"\t\t\t\t\t\tLevel:\t\t{meinCharakter.Level}/{meinCharakter.MaxLevel}");
            Console.WriteLine($"\t\t\t\t\t\tExp:\t\t{meinCharakter.Exp}/{meinCharakter.MaxExp}");
            Console.WriteLine($"\t\t\t\t\t\tMana\t\t{meinCharakter.Mana}");
            Console.WriteLine($"\t\t\t\t\t\tStärke:\t\t{meinCharakter.Staerke}");
            Console.WriteLine($"\t\t\t\t\t\tIntelligenz:\t{meinCharakter.Intelligenz}");
            Console.ReadKey();
        }
        private static void MenueAnzeige(string[] menueAuswahl, string titel, int cursorPos)
        {
            Console.Clear();
            //https://stackoverflow.com/questions/21917203/how-do-i-center-text-in-a-console-application
            Console.SetCursorPosition((Console.WindowWidth - titel.Length) / 2, Console.WindowHeight - 25);//Positionsbestimmung in der Konsole
            Console.WriteLine(titel);
            

            //Schleife für die Auswahl des Menüs
            for (int i = 0; i < menueAuswahl.Length; i++)
            {
                
                
                Console.CursorVisible = false; //Cursor unsichtbar
                if (i == auswahlIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.SetCursorPosition((Console.WindowWidth - menueAuswahl[i].Length - 10) / 2, Console.WindowHeight - 15 + cursorPos);
                    Console.WriteLine($" >   {menueAuswahl[i]}   < ");
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - menueAuswahl[i].Length) / 2, Console.WindowHeight - 15 + i);
                    Console.WriteLine($"{menueAuswahl[i]}");
                }
                Console.ResetColor();
            }
        }
        public static int MenueFuehrung(string[] menueAuswahl, string titel, string nachricht)
        {
            auswahlIndex = 0;
            while (true)
            {
                MenueAnzeige(menueAuswahl, titel, auswahlIndex);
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
                        Console.SetCursorPosition((Console.WindowWidth - nachricht.Length) / 2, Console.WindowHeight - 25);
                        if (nachricht != "") Console.WriteLine(nachricht);
                        return auswahlIndex;
                }
            }
        }
        public static void AuswahlPlayer(string text)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 25);
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
