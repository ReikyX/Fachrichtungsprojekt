using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Charakter
    {
        private int level = 0;
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
        private string charakterName;
        private string gewaehlteRasse;
        public static List<Gegenstaende> Inventar = new List<Gegenstaende>();

        public int Level { get => level; set => level = value; }
        public int Hp { get => hp; set => hp = value; }
        public int MaxHp { get => maxHp; set => maxHp = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int Staerke { get => staerke; set => staerke = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Intelligenz { get => intelligenz; set => intelligenz = value; }
        public string CharakterName { get => charakterName; }
        public string GewaehlteRasse { get => gewaehlteRasse; set => gewaehlteRasse = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; set => maxExp = value; }
        public int MaxMana { get => maxMana; set => maxMana = value; }
        public int Gold { get => gold; set => gold = value; }

        public Charakter()
        {

        }
        public Charakter(int level, int staerke, int mana, int exp, int intelligenz,int hp, string charakterName, string gewaehlteRasse)
        {
            Level = level;
            Hp = hp;
            Staerke = staerke;
            Mana = mana;
            Intelligenz = intelligenz;
            GewaehlteRasse = gewaehlteRasse;
            this.charakterName = charakterName;
        }

        public void CharakterErstellen()
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
            WaehleRasse();
        }
        public void WaehleRasse()
        {
            int rasseIndex = 0;
            string[] auswahlRassen = { "Mensch", "Hoch-Elf", "Dunkel-Elf", "Zwerg", "Ork" };

            while (true)
            {
                rasseIndex = Menue.MenueFuehrung(auswahlRassen, "Wähle deine Rasse aus!", "");
                Console.SetCursorPosition((Console.WindowWidth / 2) - 17, Console.WindowHeight - 28);
                Console.WriteLine($"Du hast die Klasse {auswahlRassen[rasseIndex]} ausgewählt.");
                GewaehlteRasse = auswahlRassen[rasseIndex];
                Console.ReadKey();
                Console.Clear();
                if (rasseIndex == 0) //Mensch
                {
                    Level = 0;
                    Hp = 200;
                    Staerke = 20;
                    Mana = 15;
                    Intelligenz = 15;
                }
                else if (rasseIndex == 1) //Hoch-Elf
                {
                    Level = 0;
                    Hp = 300;
                    Staerke = 10;
                    Mana = 30;
                    Intelligenz = 25;
                }
                else if (rasseIndex == 2) //Dunkel-Elf
                {
                    Level = 0;
                    Hp = 300;
                    Staerke = 15;
                    Mana = 20;
                    Intelligenz = 20;
                }
                else if (rasseIndex == 3) //Zwerg
                {
                    Level = 0;
                    Hp = 300;
                    Staerke = 30;
                    Mana = 10;
                    Intelligenz = 10;
                }
                else if (rasseIndex == 4) //Ork
                {
                    Level = 0;
                    Hp = 400;
                    Staerke = 40;
                    Mana = 5;
                    Intelligenz = 5;
                }
                return;
            }
        }

        public static void HinzufuegenInventar(Gegenstaende i)
        {
            Inventar.Add(i);
            Console.WriteLine(i.Name + " wurde zu deinem Inventar hinzugefügt.");
        }
    }
}

