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

            // Napln�n� rozvrhu jednotliv�mi dny a p�edm�ty
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

            // Nastaven� datov�ho kontextu pro vazbu na UI
            BindingContext = this;
        }
    }

    // T��da reprezentuj�c� jednotliv� p�edm�ty v rozvrhu
    public class Predmet
    {
        public string Nazev { get; set; }  // N�zev p�edm�tu
        public string Cas { get; set; }    // �asov� �sek v�uky
        public string Mistnost { get; set; } // M�stnost, kde se p�edm�t vyu�uje
        public Color Barva { get; set; }   // Barva pro vizu�ln� odli�en� p�edm�tu

        public Predmet(string nazev, string cas, string mistnost, Color barva)
        {
            Nazev = nazev;
            Cas = cas;
            Mistnost = mistnost;
            Barva = barva;
        }
    }

    // T��da reprezentuj�c� rozvrh pro konkr�tn� den
    public class DenRozvrhu
    {
        public string Den { get; set; }  // N�zev dne (nap�. Pond�l�)
        public List<Predmet> Predmety { get; set; } // Seznam p�edm�t� pro tento den

        public DenRozvrhu(string den, List<Predmet> predmety)
        {
            Den = den;
            Predmety = predmety;
        }
    }
}
