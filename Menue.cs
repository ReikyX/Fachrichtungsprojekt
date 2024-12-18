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

        public static void MenueAnzeige(Charakter meinCharakter, Ladebalken laed, StartMenue startMenue, ReiseMenue reiseMenue, Gegner gegner) //Methode Hauptmenü
        {
            string hauptmenue = "Hauptmenü";
            string[] menueAuswahl = { "Spiel Starten", "Infos", "Beenden" };
            auswahlIndex = 0;

            while (true)
            {
                auswahlIndex = MenueFuehrung(menueAuswahl, hauptmenue, "");//Mothode wird aufgerufen und als eine Integer Variable gespeichert
                if (auswahlIndex == menueAuswahl.Length - 1)
                {
                    Console.Clear();
                    return;
                }
                if (auswahlIndex == 0)
                {
                    AuswahlPlayer("Spiel wird gestartet");
                    startMenue.StartMenueAnzeigen(meinCharakter, reiseMenue, laed);
                }
                else if (auswahlIndex == 1)
                {
                    Console.Clear();
                    Info(meinCharakter);
                }
                else if (auswahlIndex == 2)
                {
                    break;
                }
            }
        }
        public static void Info(Charakter meinCharakter) //Metode zum Anzeigen der aktuellen Attribute des Charakters
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\tHier sind deine Infos zu deinem Charakter\n\n\n");
            Console.WriteLine($"\t\t\t\t\t\tName:\t\t{meinCharakter.CharakterName}");
            Console.WriteLine($"\t\t\t\t\t\tRasse:\t\t{meinCharakter.GewaehlteRasse}");
            Console.WriteLine($"\t\t\t\t\t\tHP:\t\t{meinCharakter.Hp}/{meinCharakter.MaxHp}");
            Console.WriteLine($"\t\t\t\t\t\tLevel:\t\t{meinCharakter.Level}/{meinCharakter.MaxLevel}");
            Console.WriteLine($"\t\t\t\t\t\tExp:\t\t{meinCharakter.Exp}/{meinCharakter.MaxExp}");
            Console.WriteLine($"\t\t\t\t\t\tMana\t\t{meinCharakter.Mana}/{meinCharakter.MaxMana}");
            Console.WriteLine($"\t\t\t\t\t\tStärke:\t\t{meinCharakter.Staerke}");
            Console.WriteLine($"\t\t\t\t\t\tIntelligenz:\t{meinCharakter.Intelligenz}");
            Console.WriteLine($"\n\t\t\t\t\t\tGold:\t\t{meinCharakter.Gold}");
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
                    Console.ForegroundColor = ConsoleColor.Black;//Schriftfarbe wird festgelegt
                    Console.BackgroundColor = ConsoleColor.White;//Hintergrundfarbe wird festgelegt
                    Console.SetCursorPosition((Console.WindowWidth - menueAuswahl[i].Length - 10) / 2, Console.WindowHeight - 15 + cursorPos);
                    Console.WriteLine($" >   {menueAuswahl[i]}   < ");
                }
                else
                {
                    Console.SetCursorPosition((Console.WindowWidth - menueAuswahl[i].Length) / 2, Console.WindowHeight - 15 + i);
                    Console.WriteLine($"{menueAuswahl[i]}");
                }
                Console.ResetColor();//Farben werden auf Standard gesetzt
            }
        }
        public static int MenueFuehrung(string[] menueAuswahl, string titel, string nachricht)
        {
            auswahlIndex = 0;
            while (true)
            {
                MenueAnzeige(menueAuswahl, titel, auswahlIndex);//Methode wird mit Übergabeparameter aufgerufen
                //https://stackoverflow.com/questions/46908148/controlling-menu-with-the-arrow-keys-and-enter
                //Auswahl des Menüs mit Pfeiltasten hoch oder runter. Mit Enter wird die Auswahl bestätigt.
                switch (Console.ReadKey(true).Key)//wartet auf eine Tasteneingabe des Benutzers.Das 'true' Argument verhindert, dass die Eingabe angezeigt wird
                                                  //Der 'switch'-Block prüft, welche Taste gedrückt wurde.
                {
                    case ConsoleKey.UpArrow:
                        auswahlIndex = (auswahlIndex - 1 + menueAuswahl.Length) % menueAuswahl.Length; //Dies bewegt die Auswahl nach oben. Die Addition von menueAuswahl.Length und der Modulo-Operator stellen sicher, dass die Auswahl am oberen Ende des Menüs zum unteren Ende springt.
                        break;
                    case ConsoleKey.DownArrow:
                        auswahlIndex = (auswahlIndex + 1) % menueAuswahl.Length;//Dies bewegt die Auswahl nach unten. Der Modulo-Operator sorgt dafür, dass die Auswahl am unteren Ende des Menüs zum oberen Ende springt.
                        break;
                    case ConsoleKey.Enter: //Bei der Eingabetaste wird die Konsole gelöscht, Cursor zentriert und eine Nachricht ausgegeben falls vorhanden.
                        Console.Clear();
                        Console.SetCursorPosition((Console.WindowWidth - nachricht.Length) / 2, Console.WindowHeight - 25);
                        if (nachricht != "") Console.WriteLine(nachricht);
                        return auswahlIndex; //Der aktuelle auswahlIndex wird zurückgegeben, was das ausgewählte Menü representiert.
                }
            }
        }
        public static void AuswahlPlayer(string text)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 23);
            Console.WriteLine(text);
            Console.ReadKey();
        }
    }
}
