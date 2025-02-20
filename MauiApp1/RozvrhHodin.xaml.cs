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
                new DenRozvrhu("Pond�l�", new List<Predmet>
                {
                    new Predmet("Matematika", "8:00 - 8:45", "A12", Colors.Blue),
                    new Predmet("�e�tina", "8:55 - 9:40", "A12", Colors.Red),
                    new Predmet("Angli�tina", "9:50 - 10:35", "A12", Colors.Green),
                    new Predmet("V�voj mobiln�ch aplikac�", "10:45 - 11:30", "A12", Colors.Orange)
                }),
                new DenRozvrhu("�ter�", new List<Predmet>
                {
                    new Predmet("T�locvik", "8:00 - 8:45", "T1", Colors.Purple),
                    new Predmet("Po��ta�ov� s�t�", "8:55 - 9:40", "A12", Colors.Teal),
                    new Predmet("Mechatronika", "9:50 - 10:35", "A12", Colors.Brown)
                }),
                new DenRozvrhu("St�eda", new List<Predmet>
                {
                    new Predmet("Webov� aplikace", "8:00 - 8:45", "A12", Colors.Cyan),
                    new Predmet("Objektov� orientovan� programov�n�", "8:55 - 9:40", "A12", Colors.Magenta),
                    new Predmet("Matematika", "9:50 - 10:35", "A12", Colors.Blue)
                }),
                new DenRozvrhu("�tvrtek", new List<Predmet>
                {
                    new Predmet("�e�tina", "8:00 - 8:45", "A12", Colors.Red),
                    new Predmet("Angli�tina", "8:55 - 9:40", "A12", Colors.Green),
                    new Predmet("V�voj mobiln�ch aplikac�", "9:50 - 10:35", "A12", Colors.Orange)
                }),
                new DenRozvrhu("P�tek", new List<Predmet>
                {
                    new Predmet("Po��ta�ov� s�t�", "8:00 - 8:45", "A12", Colors.Teal),
                    new Predmet("Mechatronika", "8:55 - 9:40", "A12", Colors.Brown),
                    new Predmet("T�locvik", "9:50 - 10:35", "Sportovn� A12", Colors.Purple)
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
