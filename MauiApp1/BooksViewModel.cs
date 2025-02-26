using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using Microsoft.Maui.Storage;
using MauiApp1.Models;
using System.Windows.Input;

public class BooksViewModel : INotifyPropertyChanged
{
    // Maximální poèet vybranıch knih
    public int MaxSelectedBooks { get; set; } = 20;

    private bool _isSelectionLimitReached;
    private ObservableCollection<BookCategory> _bookCategories;

    // Kolekce kategorií knih
    public ObservableCollection<BookCategory> BookCategories
    {
        get => _bookCategories;
        set
        {
            if (_bookCategories != value)
            {
                _bookCategories = value;
                OnPropertyChanged(nameof(BookCategories)); // Notifikace UI o zmìnì
            }
        }
    }

    // Indikátor dosaení limitu vybranıch knih
    public bool IsSelectionLimitReached
    {
        get => _isSelectionLimitReached;
        set
        {
            if (_isSelectionLimitReached != value)
            {
                _isSelectionLimitReached = value;
                OnPropertyChanged(nameof(IsSelectionLimitReached)); // Notifikace UI o zmìnì
            }
        }
    }

    // Pøíkaz pro zmìnu vıbìru knihy
    public ICommand ToggleBookSelectionCommand { get; }

    public BooksViewModel()
    {
        BookCategories = LoadBooks(); // Naètení seznamu knih
        ToggleBookSelectionCommand = new Command<Book>(ToggleBookSelection); // Pøiøazení pøíkazu
        LoadSelectedBooks(); // Naètení uloeného vıbìru knih
    }

    // Pøepíná stav vıbìru knihy
    private void ToggleBookSelection(Book book)
    {
        if (book != null)
        {
            book.IsSelected = !book.IsSelected;
            BookCheckedChanged(book);
        }
    }

    // Naèítá pøeddefinovanı seznam knih podle kategorií
    private ObservableCollection<BookCategory> LoadBooks()
    {
        return new ObservableCollection<BookCategory>
      {
           new BookCategory("Svìtová a èeská literatura do konce 18. století", new List<Book>
{
    new Book("Boccaccio, Giovanni: Dekameron (Praha: Odeon, 2013, pøeklad: Radovan Krátkı)"),
    new Book("Defoe, Daniel: ivot a zvláštní podivná dobrodruství Robinsona Crusoe,námoøníka z Yorku (Praha: Odeon 1996, pøeklad: 1. díl/Albert Vyskoèil, 2. díl/Timotheus Vodièka)"),
    new Book("Gilgameš (Praha: Mladá Fronta, 1971, pøeklad: Lubomír Matouš)"),
    new Book("Moliére: Lakomec (Praha: Orbis, 1959, pøeklad: Erik Adolf Saudek)"),
    new Book("Naso, Publius Ovidius: Promìny (Praha: Odeon, 1969, pøeklad: Ferdinand Stiebitz)"),
    new Book("Shakespeare, William: Hamlet (Brno: Atlantis, 2016, pøeklad: Martin Hilskı)"),
    new Book("Shakespeare, William: Kupec benátskı (Brno: Atlantis, 2012, pøeklad: Martin Hilskı)"),
    new Book("Shakespeare, William: Romeo a Julie (Brno: Atlantis, 2015, pøeklad: Martin Hilskı)"),
    new Book("Swift, Jonathan: Gulliverovy cesty (Praha: Dobrovskı, 2014, pøeklad: Jan Váòa)")
}),
new BookCategory("Svìtová a èeská literatura 19. století", new List<Book>
{
    new Book("Balzac, Honoré de: Otec Goriot (Praha: Odeon, 1970, pøeklad: Boena Zimová)"),
    new Book("Borovskı, Karel Havlíèek: Král Lávra"),
    new Book("Borovskı, Karel Havlíèek: Tyrolské elegie"),
    new Book("Dickens, Charles: Oliver Twist (Praha: Argo, 2014, pøeklad: Zdenìk Frıbort)"),
    new Book("Dickens, Charles: Vánoèní koleda (Praha: XYZ, 2010, pøeklad: Jan Váòa)"),
    new Book("Dostojevskij, Fjodor Michajloviè: Zloèin a trest (Praha: Academia, 2007, pøeklad: Jaroslav Hulák)"),
    new Book("Dumas, Alexandre st.: Tøi mušketıøi (Praha: SNKL, 1956, pøeklad: Jaroslav a RùenaPochovi)"),
    new Book("Erben, Karel Jaromír: Kytice"),
    new Book("Gogol, Nikolaj Vasiljeviè: Revizor (Praha: Odeon, 1986, pøeklad: Karel Milota)"),
    new Book("Hugo, Victor: Bídníci (Praha: Odeon, 1984, pøeklad: Zdeòka Pavlousková)"),
    new Book("Hugo, Victor: Chrám Matky Boí v Paøíi (Praha: Odeon, 1978, pøeklad: Milena Tomášková)"),
    new Book("Mácha, Karel Hynek: Máj"),
    new Book("Mrštíkové, Alois a Vilém: Maryša"),
    new Book("Nìmcová, Boena: Babièka"),
    new Book("Neruda, Jan: Povídky malostranské"),
    new Book("Poe, Edgar Allan: Havran (Praha: Dokoøán, 2008, pøeklad: Vítìzslav Nezval)"),
    new Book("Poe, Edgar Allan: Povídky (Praha: Odeon 1987, pøeklad: Josef Schwarz)"),
    new Book("Puškin, Alexandr Sergejeviè: Even Onìgin (Praha: Odeon, 1987, pøeklad: Olga Mašková)"),
    new Book("Stroupenickı, Ladislav: Naši Furianti"),
    new Book("Tolstoj, Lev Nikolajeviè: Anna Karenina (Praha: Lidové nakladatelství, 1973, pøeklad: Taána Hašková)"),
    new Book("Tyl, Josef Kajetán: Strakonickı dudák aneb Hody divıch en"),
    new Book("Vrchlickı, Jaroslav: Noc na Karlštejnì"),
    new Book("Wilde, Oscar: Obraz Doriana Greye (Praha: Mladá fronta, 1999, pøeklad: Jiøí Zdenìk Novák)")
}),
new BookCategory("Svìtová literatura 20. a 21. století", new List<Book>
{
    new Book("Brown, Dan: Andìlé a démoni (Praha: Ago, 2006, pøeklad: Michala Marková)"),
    new Book("Brown, Dan: Šifra mistra Leonarda (Praha: Ago, 2010, pøeklad: Zdík Dušek)"),
    new Book("Doyle, Artur Conan: Pes baskervillskı (Praha: SNKL, 1956, pøeklad: Jaroslav a Rùena Pochovi)"),
    new Book("Eco, Umberto: Jméno rùe (Praha: Argo, 2014, pøeklad: Zdenìk Frıbort)"),
    new Book("Fitzgerald, Francis Scott: Velkı Gatsby (Praha: LEDA, 2011, pøeklad: Rudolf Èervenka a Alexander Tomskı)"),
    new Book("Heller, Joseph: Hlava XXII. (Praha: Odeon, 1979, pøeklad: Miroslav Jindra)"),
    new Book("Hemingway, Ernest: Povídky (Praha: Odeon 1978, pøeklad: Radoslav Nenadál)"),
    new Book("Hemingway, Ernest: Staøec a moøe (Praha: Odeon, 2015, pøeklad: Šimon Pellar)"),
    new Book("Christie, Agatha: Smrt na Nilu (Praha: Kniní klub, 2010, pøeklad: Drahomíra Hlinková)"),
    new Book("Christie, Agatha: Vrada v Orient Expressu (Praha: Kniní klub, 2003, pøeklad: Eva Kondrysová)"),
    new Book("Martin, George R. R.: Hra o trùny (Pøeloil Michala MARKOVÁ. Praha: Argo, 2017)"),
    new Book("Orwell, George: 1984 (Praha: Argo, 2011, pøeklad: Petr Martínková)"),
    new Book("Orwell, George: Farma zvíøat (Pøeloil Gabriel GÖSSEL, pøeloil Miloš HOLUB. Praha: Maa, 2021)"),
    new Book("Remarque, Erich Maria: Na západní frontì klid (Praha: Naše vojsko, 1967, pøeklad: František Gel)"),
    new Book("Riordan, Rick: Percy Jackson: Zlodìj blesku (Praha: Fragment, 2009, pøeklad: Dana Chodilová)"),
    new Book("Rolland, Romain: Petr a Lucie (Praha: Práce, 1985, pøeklad: Jaroslav Zaorálek)"),
    new Book("Rowlingová, Joanne K.: Harry Potter a Kámen mudrcù (Praha: Albatros, 2000, pøeklad: Vladimír Medek)"),
    new Book("Ryan, Patrick: Jak jsem vyhrál válku (Praha: Naše vojsko, 1985, pøeklad: František Vrba)"),
    new Book("Saint-Exupéry, Antoine de: Malı princ (Praha: Albatros, 1977, pøeklad: Zdeòka Stavinohová)"),
    new Book("Styron, William: Sophiina volba (Praha: Odeon, 1985, pøeklad: Radoslav Nenadál)"),
    new Book("Tolkien, John Ronald Reuel: Hobit, aneb, Cesta tam a zase zpátky.(Ilustroval JemimaCATLIN, pøeloil František VRBA. Praha: Argo, 2013)"),
    new Book("Tolkien, John Ronald Reuel: Pán prstenù: Spoleèenstvo prstenu (Praha: Mladá Fronta,2001, pøeklad: Stanislava Pošustová)")
}),
new BookCategory("Èeská literatura 20. a 21. století", new List<Book>
{
    new Book("Bezruè, Petr: Slezské písnì"),
    new Book("Èapek, Karel: Bílá nemoc"),
    new Book("Èapek, Karel: Povídky z druhé kapsy"),
    new Book("Èapek, Karel: Povídky z druhé kapsy"),
    new Book("Èapek, Karel: R. U. R."),
    new Book("Èapek, Karel: Válka s mloky"),
    new Book("Dyk, Viktor: Krysaø"),
    new Book("Fuks, Ladislav: Spalovaè mrtvol"),
    new Book("Hašek, Jaroslav: Osudy dobrého vojáka Švejka za svìtové války"),
    new Book("Hrabal, Bohumil: Ostøe sledované vlaky"),
    new Book("Hrabal, Bohumil: Postøiiny"),
    new Book("Jirásek, Alois: Staré povìsti èeské"),
    new Book("Kafka, Franz: Promìna (Praha: Vyšehrad, 2005, pøeklad: Vladimír Kafka)"),
    new Book("Kryl, Karel: Kníška"),
    new Book("Lustig, Arnošt: Modlitba pro Kateøinu Horowitzovou"),
    new Book("Pavel, Ota: Smrt krásnıch srncù"),
    new Book("Petiška, Eduard: Staré øecké báje a povìsti"),
    new Book("Poláèek, Karel: Bylo nás pìt"),
    new Book("Smoljak, Ladislav Svìrák, Zdenìk: Dobytí severního pólu"),
    new Book("Vanèura, Vladislav: Rozmarné léto"),
    new Book("Viewegh, Michal: Bájeèná léta pod psa")
})
      };
    }

    // Aktualizuje stav pøi zmìnì vıbìru knihy
    public async void BookCheckedChanged(Book book)
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

        // Pokud je dosaen maximální poèet, zakázat další vıbìr
        bool shouldDisable = selectedCount >= MaxSelectedBooks;

        foreach (var b in BookCategories.SelectMany(c => c.Books))
        {
            b.IsEnabled = !shouldDisable || b.IsSelected;
        }

        UpdateSelectionStatus(); // Aktualizace UI
        SaveSelectedBooks(); // Uloení vybranıch knih
    }

    private string _selectionStatus;
    public string SelectionStatus
    {
        get => _selectionStatus;
        set
        {
            _selectionStatus = value;
            OnPropertyChanged(nameof(SelectionStatus));
        }
    }

    // Aktualizuje stavovı text pro uivatele
    private void UpdateSelectionStatus()
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);
        SelectionStatus = $"Vybráno: {selectedCount} / {MaxSelectedBooks} knih";
    }

    // Uloí seznam vybranıch knih do uivatelskıch preferencí
    private void SaveSelectedBooks()
    {
        var selectedBooks = BookCategories
                            .SelectMany(c => c.Books)
                            .Where(b => b.IsSelected)
                            .Select(b => b.Title)
                            .ToList();

        Preferences.Set("SelectedBooks", string.Join("|||", selectedBooks)); // Oddìlovaè "|||" zabraòuje konfliktùm
    }

    // Naète døíve vybrané knihy ze systému
    private void LoadSelectedBooks()
    {
        if (Preferences.ContainsKey("SelectedBooks"))
        {
            var selectedTitles = Preferences.Get("SelectedBooks", "").Split("|||", StringSplitOptions.RemoveEmptyEntries);

            foreach (var book in BookCategories.SelectMany(c => c.Books))
            {
                book.IsSelected = selectedTitles.Contains(book.Title);
            }

            UpdateSelectionStatus(); // Aktualizace UI po naètení
        }
    }

    // Implementace rozhraní INotifyPropertyChanged pro správnou aktualizaci UI
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
