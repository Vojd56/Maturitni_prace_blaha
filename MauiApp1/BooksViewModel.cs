using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Input;
using Microsoft.Maui.Storage;
using MauiApp1.Models;
using System.ComponentModel;

public class BooksViewModel : INotifyPropertyChanged
{





    private const int MaxSelectedBooks = 20;

    private bool _isSelectionLimitReached;
    private ObservableCollection<BookCategory> _bookCategories;
    public ObservableCollection<BookCategory> BookCategories
    {
        get => _bookCategories;
        set
        {
            if (_bookCategories != value)
            {
                _bookCategories = value;
                OnPropertyChanged(nameof(BookCategories)); // Oznámení zmìny pro UI
            }
        }
    }
    public bool IsSelectionLimitReached
    {
        get => _isSelectionLimitReached;
        set
        {
            if (_isSelectionLimitReached != value)
            {
                _isSelectionLimitReached = value;
                OnPropertyChanged(nameof(IsSelectionLimitReached)); // Správná zmìna
            }
        }
    }



    public ICommand ToggleBookSelectionCommand { get; }

    public BooksViewModel()
    {
        BookCategories = LoadBooks();
        ToggleBookSelectionCommand = new Command<Book>(ToggleBookSelection);
        LoadSelectedBooks();
    }

    private void ToggleBookSelection(Book book)
    {
        if (book != null)
        {
            book.IsSelected = !book.IsSelected;
            BookCheckedChanged(book);
        }
    }


    private ObservableCollection<BookCategory> LoadBooks()
    {
        return new ObservableCollection<BookCategory>
        {
             new BookCategory("Svìtová a èeská literatura do konce 18. století", new List<Book>
  {
      new Book("Dekameron", "Giovanni Boccaccio"),
      new Book("Robinson Crusoe", "Daniel Defoe"),
      new Book("Gilgameš", "Neznámý autor"),
      new Book("Lakomec", "Moliére"),
      new Book("Promìny", "Publius Ovidius Naso"),
      new Book("Hamlet", "William Shakespeare"),
      new Book("Kupec benátský", "William Shakespeare"),
      new Book("Romeo a Julie", "William Shakespeare"),
      new Book("Gulliverovy cesty", "Jonathan Swift")
  }),
  new BookCategory("Svìtová a èeská literatura 19. století", new List<Book>
  {
      new Book("Otec Goriot", "Honoré de Balzac"),
      new Book("Král Lávra", "Karel Havlíèek Borovský"),
      new Book("Tyrolské elegie", "Karel Havlíèek Borovský"),
      new Book("Oliver Twist", "Charles Dickens"),
      new Book("Vánoèní koleda", "Charles Dickens"),
      new Book("Zloèin a trest", "Fjodor Michajloviè Dostojevskij"),
      new Book("Tøi mušketýøi", "Alexandre Dumas"),
      new Book("Kytice", "Karel Jaromír Erben"),
      new Book("Revizor", "Nikolaj Vasiljeviè Gogol"),
      new Book("Bídníci", "Victor Hugo"),
      new Book("Chrám Matky Boží v Paøíži", "Victor Hugo"),
      new Book("Máj", "Karel Hynek Mácha"),
      new Book("Maryša", "Alois a Vilém Mrštíkové"),
      new Book("Babièka", "Božena Nìmcová"),
      new Book("Povídky malostranské", "Jan Neruda"),
      new Book("Havran", "Edgar Allan Poe"),
      new Book("Povídky", "Edgar Allan Poe"),
      new Book("Evžen Onìgin", "Alexandr Sergejeviè Puškin"),
      new Book("Naši Furianti", "Ladislav Stroupežnický"),
      new Book("Anna Karenina", "Lev Nikolajeviè Tolstoj"),
      new Book("Strakonický dudák", "Josef Kajetán Tyl"),
      new Book("Noc na Karlštejnì", "Jaroslav Vrchlický"),
      new Book("Obraz Doriana Greye", "Oscar Wilde")
  }),
  new BookCategory("Svìtová literatura 20. a 21. století", new List<Book>
  {
      new Book("Andìlé a démoni", "Dan Brown"),
      new Book("Šifra mistra Leonarda", "Dan Brown"),
      new Book("Pes baskervillský", "Arthur Conan Doyle"),
      new Book("Jméno rùže", "Umberto Eco"),
      new Book("Velký Gatsby", "Francis Scott Fitzgerald"),
      new Book("Hlava XXII.", "Joseph Heller"),
      new Book("Povídky", "Ernest Hemingway"),
      new Book("Staøec a moøe", "Ernest Hemingway"),
      new Book("Smrt na Nilu", "Agatha Christie"),
      new Book("Vražda v Orient Expressu", "Agatha Christie"),
      new Book("Hra o trùny", "George R. R. Martin"),
      new Book("1984", "George Orwell"),
      new Book("Farma zvíøat", "George Orwell"),
      new Book("Na západní frontì klid", "Erich Maria Remarque"),
      new Book("Percy Jackson: Zlodìj blesku", "Rick Riordan"),
      new Book("Petr a Lucie", "Romain Rolland"),
      new Book("Harry Potter a Kámen mudrcù", "Joanne K. Rowlingová"),
      new Book("Jak jsem vyhrál válku", "Patrick Ryan"),
      new Book("Malý princ", "Antoine de Saint-Exupéry"),
      new Book("Sophiina volba", "William Styron"),
      new Book("Hobit", "J. R. R. Tolkien"),
      new Book("Pán prstenù: Spoleèenstvo prstenu", "J. R. R. Tolkien")
  }),
  new BookCategory("Èeská literatura 20. a 21. století", new List<Book>
  {
      new Book("Slezské písnì", "Petr Bezruè"),
      new Book("Bílá nemoc", "Karel Èapek"),
      new Book("Povídky z druhé kapsy", "Karel Èapek"),
      new Book("Povídky z jedné kapsy", "Karel Èapek"),
      new Book("R.U.R.", "Karel Èapek"),
      new Book("Válka s mloky", "Karel Èapek"),
      new Book("Krysaø", "Viktor Dyk"),
      new Book("Spalovaè mrtvol", "Ladislav Fuks"),
      new Book("Osudy dobrého vojáka Švejka", "Jaroslav Hašek"),
      new Book("Ostøe sledované vlaky", "Bohumil Hrabal"),
      new Book("Postøižiny", "Bohumil Hrabal"),
      new Book("Staré povìsti èeské", "Alois Jirásek"),
      new Book("Promìna", "Franz Kafka"),
      new Book("Kníška", "Karel Kryl"),
      new Book("Modlitba pro Kateøinu Horowitzovou", "Arnošt Lustig"),
      new Book("Smrt krásných srncù", "Ota Pavel"),
      new Book("Staré øecké báje a povìsti", "Eduard Petiška"),
      new Book("Bylo nás pìt", "Karel Poláèek"),
      new Book("Dobytí severního pólu", "Ladislav Smoljak, Zdenìk Svìrák"),
      new Book("Rozmarné léto", "Vladislav Vanèura"),
      new Book("Bájeèná léta pod psa", "Michal Viewegh")
  })
        };
    }

    public async void BookCheckedChanged(Book book)
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

        if (selectedCount == MaxSelectedBooks)
        {
            //book.IsSelected = false;
            //await Application.Current.MainPage.DisplayAlert("Limit dosažen",
            //    $"Vybral jsi již {MaxSelectedBooks} knih.", "OK");
        }

        bool enableBooks = selectedCount < MaxSelectedBooks;
        foreach (var b in BookCategories.SelectMany(c => c.Books))
        {
            b.IsEnabled = enableBooks || b.IsSelected;
        }

        SaveSelectedBooks();
    }


    private void SaveSelectedBooks()
    {
        var selectedBooks = BookCategories.SelectMany(c => c.Books).Where(b => b.IsSelected).Select(b => b.Title).ToList();
        Preferences.Set("SelectedBooks", string.Join(",", selectedBooks));
    }

    private void LoadSelectedBooks()
    {
        if (Preferences.ContainsKey("SelectedBooks"))
        {
            var selectedTitles = Preferences.Get("SelectedBooks", "").Split(',');

            foreach (var book in BookCategories.SelectMany(c => c.Books))
            {
                if (selectedTitles.Contains(book.Title))
                {
                    book.IsSelected = true;
                }
            }

            int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);
            IsSelectionLimitReached = selectedCount >= MaxSelectedBooks;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}