using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.Models
{
    // Třída reprezentující knihu, která implementuje INotifyPropertyChanged pro sledování změn vlastností
    public class Book : INotifyPropertyChanged
    {
        // Název knihy
        public string Title { get; set; }

        // Název kategorie, do které kniha patří (např. "Sci-fi", "Historie" apod.)
        public string CategoryName { get; set; }

        // Privátní pole pro indikaci, zda je kniha vybraná
        private bool _isSelected;

        // Vlastnost pro zjištění, zda je kniha vybraná, a notifikaci změny
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                // Pokud se hodnota liší, změní ji a vyvolá událost pro změnu vlastnosti
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        // Privátní pole pro indikaci, zda je kniha povolena k interakci
        private bool _isEnabled = true;

        // Vlastnost pro zjištění, zda je kniha povolena k interakci (např. kliknutí), a notifikaci změny
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                // Pokud se hodnota liší, změní ji a vyvolá událost pro změnu vlastnosti
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        // Příkaz pro přepnutí výběru knihy (zda je vybraná nebo ne)
        public ICommand ToggleSelectionCommand { get; }

        // Konstruktor pro inicializaci knihy s názvem a kategorií
        public Book(string kniha, string categoryName = "")
        {
            Title = kniha; // Nastavení názvu knihy
            CategoryName = categoryName; // Nastavení názvu kategorie knihy

            // Inicializace příkazu pro přepnutí výběru
            ToggleSelectionCommand = new Command(() => IsSelected = !IsSelected);
        }

        // Událost pro hlášení změn vlastností (vyžaduje implementaci INotifyPropertyChanged)
        public event PropertyChangedEventHandler PropertyChanged;

        // Metoda pro vyvolání události při změně vlastnosti
        protected void OnPropertyChanged(string propertyName)
        {
            // Vyvolání PropertyChanged události, pokud je někdo přihlášen
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
