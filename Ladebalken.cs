﻿using System;
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


        public void FliegendeFestung() //https://www.asciiart.eu/image-to-ascii
        {
            string aincradBild = @"            ................................................   @  ............................................ 
            ..............................................    @@@   .......................................... 
            .............................................   @@@@@@   ......................................... 
            ............................................  @@@@@@@@@@  ........................................ 
            ...........................................  @@@@@@@@@@@@  ....................................... 
            ..........................................  #@@@@@@@@@@@@=  ...................................... 
            .......................................    @@@@@@@@@@@@@@@=  ..................................... 
            ....................................... #@@@@@@@@@@@@@@@@@@#  .................................... 
            .......................................  @@@@@@@@@@@@@@@@@@@    .................................. 
            ......................................   @@@@@@@@@@@@@@@@@@@@@@ .................................. 
            ....................................    @@@@@@@@@@@@@@@@@@@@@@@ .................................. 
            .................................... :@@@@@@@@@@@@@@@@@@@@@@@@@  ................................. 
            .................................... @@@@@@@@@@@@@@@@@@@@@@@@@@.  ................................ 
            ...................................   @@@@@@@@@@@@@@@@@@@@@@@@@@@ ................................ 
            .....................         ....  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@  .           ................... 
            ..................... @=@@  @ ...   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@  . @ @  @@@@ ................... 
            ..................... @ @#  @       @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   @ @  *@:@ ................... 
            ...................   * @   @  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ @   @-%  .................. 
            ..................+=- @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ @@ +.................. 
            ...................           @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@       .................. 
            ..................... =.@ ...    @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@ *      +- ................... 
            ......................  @ ....     @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   @  ... ...................... 
            .......................   .......   @@@@@@@@@@@@@@@@@@@@@@@@@@@@+    @ ........................... 
            ..................................  -@@@@@@@@@@@@@@@@@@@@@@@@ +    .   ........................... 
            ...................................  @  @@@@@@@@@@@@@@@@@@@      ................................. 
            ...................................   @  @ :@@@@@@@@@@@@@@@  ..................................... 
            ....................................          @@@@@@@@@@@   ...................................... 
            ........................................... @@@@@+@@@@@   .:...................................... 
            ........................................... %@@   @  @ @ ......................................... 
";

            Console.Write(aincradBild);
            Thread.Sleep(5000);
            Console.Clear();
        }
        public void Stauts()
        {
            //Definition von größe und position
            breite = Console.WindowWidth - 70;
            positionUnten = Console.WindowHeight - 2;


            int schritte = 100;

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, positionUnten); //Cursor Position wird bestimmt
            for (int x = 0; x <= schritte; x++) //
            {

                Console.SetCursorPosition(0, positionUnten);

                float prozent = (float)x / schritte; //Schritte werden multipliziert mit x (umgewandelt in float)
                int status = (int)(breite * prozent); //Prozent wird mit der vordefinierten Variable breite (umgewandelt in int) multipliziert

                Console.Write("[");
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(new string(' ', status));
                Console.ResetColor();
                Console.Write(new string(' ', breite - status));
                Console.Write("]");
                Console.Write($" {(int)(prozent * 100)}%"); //Ausgabe des Status in Prozent

                Thread.Sleep(50);
            }
            Console.CursorVisible = true;
            Console.Write("\tFertig! Beliebige Taste drücken um fortzufahren.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
