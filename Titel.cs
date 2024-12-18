﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aincrad
{
    internal class Titel
    {
        //Speicherung von Ascii Art in einem string.
        //https://patorjk.com/software/taag/#p=display&f=Bloody&t=Aincrad
        private string titelName = @"
                               ▄▄▄       ██▓ ███▄    █  ▄████▄   ██▀███   ▄▄▄      ▓█████▄ 
                              ▒████▄    ▓██▒ ██ ▀█   █ ▒██▀ ▀█  ▓██ ▒ ██▒▒████▄    ▒██▀ ██▌
                              ▒██  ▀█▄  ▒██▒▓██  ▀█ ██▒▒▓█    ▄ ▓██ ░▄█ ▒▒██  ▀█▄  ░██   █▌
                              ░██▄▄▄▄██ ░██░▓██▒  ▐▌██▒▒▓▓▄ ▄██▒▒██▀▀█▄  ░██▄▄▄▄██ ░▓█▄   ▌
                              ▓█   ▓██▒░██░▒██░   ▓██░▒ ▓███▀ ░░██▓ ▒██▒ ▓█   ▓██▒░▒████▓ 
                              ▒▒   ▓▒█░░▓  ░ ▒░   ▒ ▒ ░ ░▒ ▒  ░░ ▒▓ ░▒▓░ ▒▒   ▓▒█░ ▒▒▓  ▒ 
                              ▒   ▒▒ ░ ▒ ░░ ░░   ░ ▒░  ░  ▒     ░▒ ░ ▒░  ▒   ▒▒ ░ ░ ▒  ▒ 
                              ░   ▒    ▒ ░   ░   ░ ░ ░          ░░   ░   ░   ▒    ░ ░  ░ 
                                    ░  ░ ░           ░ ░ ░         ░           ░  ░   ░    
                                                      ░                            ░      
";

        private string nameSpiel = "Aincrad";
        private string beschreibungSpiel = @"
                                             Das Spiel ist ein Fantasy RPG.
                              In dem Spiel geht es darum seinen Charakter stärker zu machen. 
                          Sei es durchs Aufleveln oder Ausgrüstung wie zb. Waffen oder Rüstung.
                                             Dies ist kein Fertiges Spiel! 
                   Es wird kontinuierlich daran gearbeitet das Spiel zu verbesseren und zu optimieren.";


        public void Info( string nameSpiel, string beschreibungSpiel)
        {
            this.nameSpiel = nameSpiel;
            this.beschreibungSpiel = beschreibungSpiel;
        }

        public void SpielInfo()
        {
            Console.WriteLine(titelName);
            Console.WriteLine($"\t\t\t\t\t\t     Titel: {this.nameSpiel}");
            Console.WriteLine($"\n\t\t\t\t\t\t      Beschreibung:\n {this.beschreibungSpiel}");
            Thread.Sleep(10000);
            Console.Clear();
        }

    }
}
