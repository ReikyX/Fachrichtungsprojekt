using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Aincrad
{
    internal class KampfSystem
    {
        public static void CharakterVsGegner(Charakter meinCharakter, Gegner gegner, string text)
        {
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 13);
            Console.WriteLine(text);
            bool weiter = true;
            if (meinCharakter.Hp > 0)
            {
                gegner.HP -= meinCharakter.Staerke;
                meinCharakter.Hp -= gegner.Staerke;
                meinCharakter.Exp += gegner.Level;
                meinCharakter.Gold += 20;
                if (meinCharakter.Exp >= meinCharakter.MaxExp)
                {
                    meinCharakter.Level++;
                    meinCharakter.Hp = meinCharakter.MaxHp;
                    meinCharakter.Mana = meinCharakter.MaxMana;
                    meinCharakter.Intelligenz += 3;
                    meinCharakter.Staerke += 5;
                }
                Console.SetCursorPosition((Console.WindowWidth - text.Length) - 56, Console.WindowHeight - 10);
                Console.WriteLine($"Deine Hp sind auf {meinCharakter.Hp} gesunken.");
                if (gegner.HP <= 0)
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - text.Length) - 60, Console.WindowHeight - 8);
                    Console.WriteLine("Du hast das Monster besiegt.");
                    Console.ReadKey();
                    Console.Clear();
                    weiter = false;
                }
                if (meinCharakter.Hp<=0)
                {
                    Console.Clear();
                    Console.SetCursorPosition((Console.WindowWidth - text.Length) - 60, Console.WindowHeight - 8);
                    Console.WriteLine("Du bist leider gestorben und fängst wieder von neu an.");
                    Console.ReadKey();
                    Program.Neu();
                }
                
                while (weiter) //wird solange ausgeführt bis die bedingung zutrifft (Auswahl 'nein' oder Tod des Charakters)
                {
                    Console.Clear();
                    Console.WriteLine($"Gegner: {gegner.Name}\t\tLevel: {gegner.Level}\t\tHP {gegner.HP}\t\tStärke: {gegner.Staerke}\n");
                    Console.WriteLine($"Charakter: {meinCharakter.CharakterName}\t\tLevel: {meinCharakter.Level}\t\tStärke: {meinCharakter.Staerke}\t\tHP: {meinCharakter.Hp}\t\tExp: {meinCharakter.Exp}/{meinCharakter.MaxExp}\n\n");
                    Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 13);
                    Console.WriteLine("Möchtest du weiter kämpfen? (j/n)");
                    Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 11);
                    string antwort = Console.ReadLine().ToLower().Trim();
                    if (antwort == "j")
                    {
                        if (meinCharakter.Hp <= gegner.Staerke)
                        {
                            Menue.AuswahlPlayer("Du bist gestorben und fängst wieder von vorne an.");
                            Program.Neu();
                        }
                        else if (meinCharakter.Hp == gegner.Staerke)
                        {
                            Console.Clear();
                            Console.WriteLine("Bist du dir sicher ?");
                            meinCharakter.Hp -= gegner.Staerke;
                            Menue.AuswahlPlayer("Du bist gestorben und fängst wieder von vorne an.");
                            Console.ReadKey();
                            Console.Clear();
                            Program.Neu();
                        }
                        else
                        {
                            gegner.HP -= meinCharakter.Staerke;
                            meinCharakter.Hp -= gegner.Staerke;
                            meinCharakter.Exp += gegner.Level;
                            meinCharakter.Gold += 20;
                            if (meinCharakter.Exp >= meinCharakter.MaxExp)//Bedingung bei erreichen des Exp Maximalwertes
                            {
                                meinCharakter.Level++;
                                meinCharakter.Hp += 50;
                                meinCharakter.Mana += 20;
                                meinCharakter.Intelligenz += 3;
                                meinCharakter.Staerke += 5;
                                meinCharakter.Gold += 50;
                                meinCharakter.Exp = 0;
                            }
                            if (gegner.HP <= 0)
                            {
                                Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 13);
                                Console.WriteLine("Du hast das Monster besiegt Glückwunsch!");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    else if (antwort == "n")
                    {
                        Console.Clear();
                        break;
                    }
                    else
                    {
                        UngueltigGueltig("Keine gültige eingabe!");
                    }
                }
            }
            else
            {
                return;
            };

        }
        public static void UngueltigGueltig(string text)
        {
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.WindowHeight - 13);
            Console.WriteLine(text);
            Thread.Sleep(2000);
            Console.Clear();
        }//Methode für Ungültige Eingabe
    }
}
