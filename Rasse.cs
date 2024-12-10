using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Rasse : Charakter
    {
        public Rasse() { }
        public Rasse(int level, int maxLevel, int staerke, int mana, int intelligenz, string charakterName, string gewaehlteRasse)
        {
            Level = level;
            MaxLevel = maxLevel;
            Staerke = staerke;
            Mana = mana;
            Intelligenz = intelligenz;
            GewaehlteRasse = gewaehlteRasse;
        }

        public void WaehleRasse()
        {
            int rasseIndex = 0;
            string[] auswahlRassen = { "Mensch", "Hoch-Elf", "Dunkel-Elf", "Zwerg", "Ork" };


            while (true)
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\tWähle deine Rasse aus!\n");

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

                ConsoleKeyInfo pfeilInfo = Console.ReadKey(true);
                switch (pfeilInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        rasseIndex = (rasseIndex - 1 + auswahlRassen.Length) % auswahlRassen.Length;
                        break;
                    case ConsoleKey.DownArrow:
                        rasseIndex = (rasseIndex + 1) % auswahlRassen.Length;
                        break;
                    case ConsoleKey.Enter:

                        Console.Clear();

                        Console.WriteLine($"Du hast die Klasse {auswahlRassen[rasseIndex]} ausgewählt.");
                        GewaehlteRasse = auswahlRassen[rasseIndex];
                        Console.ReadKey(true);
                        return;
                }
            }
        }
    }
}


