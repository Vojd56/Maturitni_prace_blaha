using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MauiApp1
{
    // Třída reprezentující jednu aktualitu
    public class Aktualita
    {
        public string Nadpis { get; set; }  // Název aktuality
        public string Platnost { get; set; }  // Datum platnosti aktuality
        public string Text { get; set; }  // Hlavní text aktuality
        public string Autor { get; set; }  // Autor aktuality
    }

    public partial class MainPage : ContentPage
    {
        // Kolekce pro seznam aktualit
        public ObservableCollection<Aktualita> AktualityList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            // Naplnění ObservableCollection daty (seznam aktualit)
            AktualityList = new ObservableCollection<Aktualita>
            {
                new Aktualita { Nadpis = "Zítra 22.2 bude ředitelské volno", Platnost = "22. 2. 2025",
                                Text = "Zítra (tj. 22.2) se opravuje potrubí, buďte doma", Autor = " Anonymní " },

                new Aktualita { Nadpis = "Zítra 24.2 bude ředitelské volno", Platnost = "23. 2. 2025",
                                Text = "Zítra (tj. 23.2) se opravuje monitor, buďte doma", Autor = " M. Kapcala " },

                new Aktualita { Nadpis = "Aktualita 1", Platnost = "20. 2. 2025",
                                Text = "Text první aktuality", Autor = "Autor 1" },

                new Aktualita { Nadpis = "Aktualita 2", Platnost = "21. 2. 2025",
                                Text = "Text druhé aktuality", Autor = "Autor 2" },

                // Přidej další položky podle potřeby
            };

            // Nastavení BindingContext pro stránku, aby se aktuality správně zobrazovaly v UI
            BindingContext = this;
        }
    }
}
