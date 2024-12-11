namespace Aincrad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ladebalken laed = new Ladebalken();
            Titel aincrad = new Titel();
            Charakter meinCharakter = new Charakter();
            Menue menue = new Menue();
            StartMenue startMenue = new StartMenue();



            //laed.Stauts();
            //aincrad.SpielInfo();
            //meinCharakter.CharakterErstellen();
            menue.MenueAnzeige(meinCharakter, laed, startMenue);
            
            Console.ReadKey();
        }
    }
}
