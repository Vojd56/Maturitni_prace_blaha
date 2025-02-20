using System.Linq;
using System.Globalization;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    public partial class RozvrhHodin : ContentPage
    {
        public ObservableCollection<DenRozvrhu> Rozvrh { get; set; }

        public RozvrhHodin()
        {
            InitializeComponent();
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

            BindingContext = this;


        }
    }

    public class Predmet
    {
        public string Nazev { get; set; }
        public string Cas { get; set; }
        public string Mistnost { get; set; }
        public Color Barva { get; set; }

        public Predmet(string nazev, string cas, string mistnost, Color barva)
        {
            Nazev = nazev;
            Cas = cas;
            Mistnost = mistnost;
            Barva = barva;
        }
    }

    public class DenRozvrhu
    {
        public string Den { get; set; }
        public List<Predmet> Predmety { get; set; }

        public DenRozvrhu(string den, List<Predmet> predmety)
        {
            Den = den;
            Predmety = predmety;
        }
    }
}
