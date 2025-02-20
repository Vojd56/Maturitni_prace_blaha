using System.ComponentModel;
using System.Windows.Input;

namespace MauiApp1.Models
{
    public class Book : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public string CategoryName { get; set; }

        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                    OnPropertyChanged(nameof(IsEnabled));
                }
            }
        }

        // Příkaz pro přepnutí výběru
        public ICommand ToggleSelectionCommand { get; }

        public Book(string kniha, string categoryName = "")
        {
            Title = kniha;
            CategoryName = categoryName;

            // Inicializace příkazu pro přepnutí výběru
            ToggleSelectionCommand = new Command(() => IsSelected = !IsSelected);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
