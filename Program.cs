namespace Aincrad
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ladebalken laed = new Ladebalken();
            //laed.Stauts();

            Titel aincrad = new Titel();
            aincrad.SpielInfo();

            Charakter meinCharakter = new Charakter();
            meinCharakter.CharakterErstellen();

            Menue menue = new Menue();
            menue.MenueAnzeige();

            




        }
    }
}
