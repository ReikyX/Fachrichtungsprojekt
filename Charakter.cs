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
        private string charakterName;
        private string gewaehlteRasse;

        public int Level { get => level; set => level = value; }
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        public int Staerke { get => staerke; set => staerke = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Intelligenz { get => intelligenz; set => intelligenz = value; }
        public string CharakterName { get => charakterName;}
        public string GewaehlteRasse { get => gewaehlteRasse; set => gewaehlteRasse = value; }

        public Charakter()
        {

        }
        public Charakter(int level, int maxLevel, int staerke, int mana, int intelligenz, string charakterName, string gewaehlteRasse)
        {
            Level = level;
            MaxLevel = maxLevel;
            Staerke = staerke;
            Mana = mana;
            Intelligenz = intelligenz;
            GewaehlteRasse = gewaehlteRasse;
            this.charakterName = charakterName;
        }

        public void CharakterErstellen()
        {
            Console.WriteLine("Charakter erstellung.\n");
            Console.Write("Bitte gib deinen Player-Namen ein: ");
            this.charakterName = Console.ReadLine().Trim();
            Rasse meineRasse = new Rasse();
            meineRasse.WaehleRasse();
        }
    }
}
