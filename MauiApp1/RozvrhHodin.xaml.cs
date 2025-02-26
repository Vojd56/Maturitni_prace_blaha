using System.Linq;
using System.Globalization;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class RozvrhHodin : ContentPage
    {
        // Kolekce pro rozvrh hodin
        public ObservableCollection<DenRozvrhu> Rozvrh { get; set; }

        public RozvrhHodin()
        {
            InitializeComponent();

            // Naplnìní rozvrhu jednotlivými dny a pøedmìty
            Rozvrh = new ObservableCollection<DenRozvrhu>
            {
                new DenRozvrhu("Pondìlí", new List<Predmet>
                {
                    new Predmet("Matematika", "8:00 - 8:45", "A12", Colors.Blue),
                    new Predmet("Èeština", "8:55 - 9:40", "A12", Colors.Red),
                    new Predmet("Angliètina", "9:50 - 10:35", "A12", Colors.Green),
                    new Predmet("Vývoj mobilních aplikací", "10:45 - 11:30", "A12", Colors.Orange)
                }),
                new DenRozvrhu("Úterý", new List<Predmet>
                {
                    new Predmet("Tìlocvik", "8:00 - 8:45", "T1", Colors.Purple),
                    new Predmet("Poèítaèové sítì", "8:55 - 9:40", "A12", Colors.Teal),
                    new Predmet("Mechatronika", "9:50 - 10:35", "A12", Colors.Brown)
                }),
                new DenRozvrhu("Støeda", new List<Predmet>
                {
                    new Predmet("Webové aplikace", "8:00 - 8:45", "A12", Colors.Cyan),
                    new Predmet("Objektovì orientované programování", "8:55 - 9:40", "A12", Colors.Magenta),
                    new Predmet("Matematika", "9:50 - 10:35", "A12", Colors.Blue)
                }),
                new DenRozvrhu("Ètvrtek", new List<Predmet>
                {
                    new Predmet("Èeština", "8:00 - 8:45", "A12", Colors.Red),
                    new Predmet("Angliètina", "8:55 - 9:40", "A12", Colors.Green),
                    new Predmet("Vývoj mobilních aplikací", "9:50 - 10:35", "A12", Colors.Orange)
                }),
                new DenRozvrhu("Pátek", new List<Predmet>
                {
                    new Predmet("Poèítaèové sítì", "8:00 - 8:45", "A12", Colors.Teal),
                    new Predmet("Mechatronika", "8:55 - 9:40", "A12", Colors.Brown),
                    new Predmet("Tìlocvik", "9:50 - 10:35", "Sportovní A12", Colors.Purple)
                })
            };

            // Nastavení datového kontextu pro vazbu na UI
            BindingContext = this;
        }
    }

    // Tøída reprezentující jednotlivé pøedmìty v rozvrhu
    public class Predmet
    {
        public string Nazev { get; set; }  // Název pøedmìtu
        public string Cas { get; set; }    // Èasový úsek výuky
        public string Mistnost { get; set; } // Místnost, kde se pøedmìt vyuèuje
        public Color Barva { get; set; }   // Barva pro vizuální odlišení pøedmìtu

        public Predmet(string nazev, string cas, string mistnost, Color barva)
        {
            Nazev = nazev;
            Cas = cas;
            Mistnost = mistnost;
            Barva = barva;
        }
    }

    // Tøída reprezentující rozvrh pro konkrétní den
    public class DenRozvrhu
    {
        public string Den { get; set; }  // Název dne (napø. Pondìlí)
        public List<Predmet> Predmety { get; set; } // Seznam pøedmìtù pro tento den

        public DenRozvrhu(string den, List<Predmet> predmety)
        {
            Den = den;
            Predmety = predmety;
        }
    }
}
