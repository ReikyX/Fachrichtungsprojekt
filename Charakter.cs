﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Charakter
    {
        private int level = 1;
        private int hp = 200;
        private int maxHp = 1000;
        private int maxLevel = 200;
        private int staerke = 20;
        private int mana = 15;
        private int maxMana = 500;
        private int intelligenz = 15;
        private int exp = 0;
        private int maxExp = 200;
        private int gold = 100;
        private int verteidigung = 0;
        private string charakterName;
        private string gewaehlteRasse;
        public static List<Gegenstaende> Inventar = new List<Gegenstaende>(20); //Liste wird erstellt zum speichern der erhaltenen Gegenständen

        public int Level { get => level; set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; }
        public int MaxLevel { get => maxLevel; }
        public int Staerke { get => staerke; set => staerke = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Intelligenz { get => intelligenz; set => intelligenz = value; }
        public string CharakterName { get => charakterName; }
        public string GewaehlteRasse { get => gewaehlteRasse; set => gewaehlteRasse = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; }
        public int MaxMana { get => maxMana; }
        public int Gold { get => gold; set => gold = value; }
        public int Verteidigung { get => verteidigung; set => verteidigung = value; }

        public Charakter()
        {

        }
        //Attribute werden dem Charakter zugewiesen
        public Charakter(int level, int staerke, int mana, int exp, int intelligenz, int hp, string charakterName, string gewaehlteRasse, int verteidigung)
        {
            Level = level;
            Hp = hp;
            Staerke = staerke;
            Mana = mana;
            Intelligenz = intelligenz;
            GewaehlteRasse = gewaehlteRasse;
            Verteidigung = verteidigung;
            this.charakterName = charakterName;
        }

        public void CharakterErstellen() //Methode zum erstellen des Charakters
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) - 11, Console.WindowHeight - 25);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(" Charakter erstellung ");
            Console.ResetColor();
            Console.SetCursorPosition((Console.WindowWidth / 2) - 17, Console.WindowHeight - 22);
            Console.WriteLine("Bitte gib deinen Player-Namen ein!");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight - 19);
            Console.WriteLine("Player Name: ");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 7, Console.WindowHeight - 17);
            this.charakterName = Console.ReadLine().Trim();
            WaehleRasse(); //Methode Rassenauswahl wird aufgerufen.
        }
        public void WaehleRasse()
        {
            int rasseIndex = 0;
            string[] auswahlRassen = { "Mensch", "Hoch-Elf", "Dunkel-Elf", "Zwerg", "Ork" };

            while (true)
            {
                //Auswahl durch den Benutzer 
                rasseIndex = Menue.MenueFuehrung(auswahlRassen, "Wähle deine Rasse aus!", "");
                Console.SetCursorPosition((Console.WindowWidth / 2) - 17, Console.WindowHeight - 28);
                Console.WriteLine($"Du hast die Klasse {auswahlRassen[rasseIndex]} ausgewählt.");
                GewaehlteRasse = auswahlRassen[rasseIndex];
                Console.ReadKey();
                Console.Clear();
                //Je nach auswahl des Benutzers werden die Attribute für die jeweilige Klasse überschrieben/übernommen.
                if (rasseIndex == 0) //Mensch
                {
                    Level = 1;
                    Hp = 200;
                    Staerke = 20;
                    Verteidigung = 0;
                    Mana = 15;
                    Intelligenz = 15;
                }
                else if (rasseIndex == 1) //Hoch-Elf
                {
                    Level = 1;
                    Hp = 300;
                    Staerke = 10;
                    Verteidigung = 0;
                    Mana = 30;
                    Intelligenz = 25;
                }
                else if (rasseIndex == 2) //Dunkel-Elf
                {
                    Level = 1;
                    Hp = 300;
                    Staerke = 15;
                    Verteidigung = 0;
                    Mana = 20;
                    Intelligenz = 20;
                }
                else if (rasseIndex == 3) //Zwerg
                {
                    Level = 1;
                    Hp = 300;
                    Staerke = 30;
                    Verteidigung = 10;
                    Mana = 10;
                    Intelligenz = 10;
                }
                else if (rasseIndex == 4) //Ork
                {
                    Level = 1;
                    Hp = 400;
                    Staerke = 40;
                    Verteidigung = 10;
                    Mana = 5;
                    Intelligenz = 5;
                }
                return;
            }
        }

        public static void HinzufuegenInventar(Gegenstaende i)
        {
            if (Inventar.Count <= 20)
            {
                Inventar.Add(i); //Hinzufügen eines Objekts in die Liste Inventar. Hierzu wird der Index genommen den der Benutzer auswählt.
                Menue.AuswahlPlayer(i.Name + " wurde zu deinem Inventar hinzugefügt.");
            }
            else { Menue.AuswahlPlayer("Dein Inventar ist voll"); }

        }
    }
}

