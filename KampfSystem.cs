using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                gegner.HP = gegner.HP - meinCharakter.Staerke;
                meinCharakter.Hp = meinCharakter.Hp - gegner.Staerke;
                meinCharakter.Exp = +gegner.Level;
                Console.SetCursorPosition((Console.WindowWidth - text.Length) - 56, Console.WindowHeight - 10);
                Console.WriteLine($"Deine Hp sind auf {meinCharakter.Hp} gesunken.");
                Console.ReadKey();

                while (weiter)
                {
                    Console.Clear();
                    Console.WriteLine($"Gegner: {gegner.Name}\t\tLevel: {gegner.Level}\t\tHP {gegner.HP}\t\tStärke: {gegner.Staerke}\n");
                    Console.WriteLine($"Charakter: {meinCharakter.CharakterName}\t\tLevel: {meinCharakter.Level}\t\tHP {meinCharakter.Hp}\t\tStärke: {meinCharakter.Staerke}\n\n");
                    Console.WriteLine("Möchtest du weiter kämpfen? (j/n)");
                    string antwort = Console.ReadLine().ToLower().Trim();
                    if (antwort == "j")
                    {
                        if (meinCharakter.Hp <= gegner.Staerke)
                        {
                            Console.Clear();
                            Console.WriteLine("Du bist gestorben und fängst wieder von vorne an.");
                            Console.ReadKey();
                            Console.Clear();
                            meinCharakter.CharakterErstellen();
                            weiter = false;
                            break;
                        }
                        else if (meinCharakter.Hp == gegner.Staerke)
                        {
                            Console.Clear();
                            Console.WriteLine("Bist du dir sicher ?");
                            meinCharakter.Hp = meinCharakter.Hp - gegner.Staerke;
                            Console.WriteLine("Du bist gestorben und fängst wieder von vorne an.");
                            Console.ReadKey();
                            Console.Clear();
                            meinCharakter.CharakterErstellen();
                            weiter = false;
                            break;

                        }
                        else
                        {
                            gegner.HP = gegner.HP - meinCharakter.Staerke;
                            meinCharakter.Hp = meinCharakter.Hp - gegner.Staerke;
                            
                        }

                    }
                    else if (antwort == "n")
                    {
                        UngueltigGueltig("Du machst dich aus dem Staub.");
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
            Console.WriteLine(text);
            Thread.Sleep(2000);
            Console.Clear();
        }
    }
}
