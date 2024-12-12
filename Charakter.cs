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
        private int maxLevel = 200;
        private int staerke = 20;
        private int mana = 15;
        private int intelligenz = 15;
        private int exp = 0;
        private int maxExp = 200;
        private string charakterName;
        private string gewaehlteRasse;

        public int Level { get => level; set => level = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int Staerke { get => staerke; set => staerke = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Intelligenz { get => intelligenz; set => intelligenz = value; }
        public string CharakterName { get => charakterName; }
        public string GewaehlteRasse { get => gewaehlteRasse; set => gewaehlteRasse = value; }
        public int Exp { get => exp; set => exp = value; }
        public int MaxExp { get => maxExp; set => maxExp = value; }

        public Charakter()
        {

        }
        public Charakter(int level, int staerke, int mana, int exp, int intelligenz, string charakterName, string gewaehlteRasse)
        {
            Level = level;
            Staerke = staerke;
            Mana = mana;
            Intelligenz = intelligenz;
            GewaehlteRasse = gewaehlteRasse;
            this.charakterName = charakterName;
        }

        public void CharakterErstellen()
        {
            Console.SetCursorPosition((Console.WindowWidth / 2) -11, Console.WindowHeight - 25);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(" Charakter erstellung \n");
            Console.ResetColor();
            Console.WriteLine("\t\t\t\t\t   Bitte gib deinen Player-Namen ein!");
            Console.WriteLine("\n\n\n\t\t\t\t\t\t     Player Name: \n\n");
            Console.Write("\t\t\t\t\t\t\t");
            this.charakterName = Console.ReadLine().Trim();
            WaehleRasse();
        }
        public void WaehleRasse()
        {
            int rasseIndex = 0;
            string[] auswahlRassen = { "Mensch", "Hoch-Elf", "Dunkel-Elf", "Zwerg", "Ork" };


            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tWähle deine Rasse aus!\n\n");

                for (int i = 0; i < auswahlRassen.Length; i++)
                {
                    Console.CursorVisible = false; //Cursor unsichtbar
                    if (i == rasseIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine($"\t\t\t\t\t\t  >   {auswahlRassen[i]}   <  ");
                    }
                    else
                    {
                        Console.WriteLine($"\t\t\t\t\t\t{auswahlRassen[i]}");
                    }
                    Console.ResetColor();
                }

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        rasseIndex = (rasseIndex - 1 + auswahlRassen.Length) % auswahlRassen.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        rasseIndex = (rasseIndex + 1) % auswahlRassen.Length;
                        break;
                    case ConsoleKey.Enter:

                        Console.Clear();

                        Console.WriteLine($"\n\n\n\t\t\t\t\tDu hast die Klasse {auswahlRassen[rasseIndex]} ausgewählt.");
                        GewaehlteRasse = auswahlRassen[rasseIndex];
                        Console.ReadKey();
                        if (rasseIndex == 0)
                        {
                            Level = 0;
                            MaxLevel = 200;
                            Staerke = 20;
                            Mana = 15;
                            Intelligenz = 15;
                        }
                        else if (rasseIndex == 1)
                        {
                            Level = 0;
                            MaxLevel = 200;
                            Staerke = 10;
                            Mana = 30;
                            Intelligenz = 25;
                        }
                        else if (rasseIndex == 2)
                        {
                            Level = 0;
                            MaxLevel = 200;
                            Staerke = 15;
                            Mana = 20;
                            Intelligenz = 20;
                        }
                        else if (rasseIndex == 3)
                        {
                            Level = 0;
                            MaxLevel = 200;
                            Staerke = 30;
                            Mana = 10;
                            Intelligenz = 10;
                        }
                        else if (rasseIndex == 4)
                        {
                            Level = 0;
                            MaxLevel = 200;
                            Staerke = 40;
                            Mana = 5;
                            Intelligenz = 5;
                        }
                        return;
                }


            }
        }
    }
}
