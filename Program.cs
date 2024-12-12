namespace Aincrad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ladebalken laed = new Ladebalken();
            Titel aincrad = new Titel();
            Charakter meinCharakter = new Charakter();
            StartMenue startMenue = new StartMenue();
            ReiseMenue reiseMenue = new ReiseMenue();

            
            //laed.Stauts();
            //laed.FliegendeFestung();
            //aincrad.SpielInfo();
            //meinCharakter.CharakterErstellen();
            Menue.MenueAnzeige(meinCharakter, laed, startMenue, reiseMenue);
            
            Console.ReadKey();
        }
    }
}
