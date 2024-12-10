using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Ladebalken
    {
        private int breite;
        private int positionUnten;

        public void Stauts()
        {

            breite = Console.WindowWidth - 70;
            positionUnten = Console.WindowHeight - 2;


            int totalSteps = 100;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, positionUnten);
            for (int x = 0; x <= totalSteps; x++)
            {

                Console.SetCursorPosition(0, positionUnten);

                float percent = (float)x / totalSteps;
                int progress = (int)(breite * percent);

                Console.Write("[");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Gray;

                Console.Write(new string(' ', progress));
                Console.ResetColor();
                Console.Write(new string(' ', breite - progress));
                Console.Write("]");
                Console.Write($" {(int)(percent * 100)}%");

                Thread.Sleep(50);
            }
            Console.CursorVisible = true;
            Console.Write("\tFertig! Beliebige Taste drücken um fortzufahren.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
