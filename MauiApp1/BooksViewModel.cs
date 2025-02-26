using System.Collections.ObjectModel;
using System.Linq;
using System.ComponentModel;
using Microsoft.Maui.Storage;
using MauiApp1.Models;
using System.Windows.Input;

public class BooksViewModel : INotifyPropertyChanged
{
    // Maxim�ln� po�et vybran�ch knih
    public int MaxSelectedBooks { get; set; } = 20;

    private bool _isSelectionLimitReached;
    private ObservableCollection<BookCategory> _bookCategories;

    // Kolekce kategori� knih
    public ObservableCollection<BookCategory> BookCategories
    {
        get => _bookCategories;
        set
        {
            if (_bookCategories != value)
            {
                _bookCategories = value;
                OnPropertyChanged(nameof(BookCategories)); // Notifikace UI o zm�n�
            }
        }
    }

    // Indik�tor dosa�en� limitu vybran�ch knih
    public bool IsSelectionLimitReached
    {
        get => _isSelectionLimitReached;
        set
        {
            if (_isSelectionLimitReached != value)
            {
                _isSelectionLimitReached = value;
                OnPropertyChanged(nameof(IsSelectionLimitReached)); // Notifikace UI o zm�n�
            }
        }
    }

    // P��kaz pro zm�nu v�b�ru knihy
    public ICommand ToggleBookSelectionCommand { get; }

    public BooksViewModel()
    {
        BookCategories = LoadBooks(); // Na�ten� seznamu knih
        ToggleBookSelectionCommand = new Command<Book>(ToggleBookSelection); // P�i�azen� p��kazu
        LoadSelectedBooks(); // Na�ten� ulo�en�ho v�b�ru knih
    }

    // P�ep�n� stav v�b�ru knihy
    private void ToggleBookSelection(Book book)
    {
        if (book != null)
        {
            book.IsSelected = !book.IsSelected;
            BookCheckedChanged(book);
        }
    }

    // Na��t� p�eddefinovan� seznam knih podle kategori�
    private ObservableCollection<BookCategory> LoadBooks()
    {
        return new ObservableCollection<BookCategory>
      {
           new BookCategory("Sv�tov� a �esk� literatura do konce 18. stolet�", new List<Book>
{
    new Book("Boccaccio, Giovanni: Dekameron (Praha: Odeon, 2013, p�eklad: Radovan Kr�tk�)"),
    new Book("Defoe, Daniel: �ivot a zvl�tn� podivn� dobrodru�stv� Robinsona Crusoe,n�mo�n�ka z Yorku (Praha: Odeon 1996, p�eklad: 1. d�l/Albert Vysko�il, 2. d�l/Timotheus Vodi�ka)"),
    new Book("Gilgame� (Praha: Mlad� Fronta, 1971, p�eklad: Lubom�r Matou�)"),
    new Book("Moli�re: Lakomec (Praha: Orbis, 1959, p�eklad: Erik Adolf Saudek)"),
    new Book("Naso, Publius Ovidius: Prom�ny (Praha: Odeon, 1969, p�eklad: Ferdinand Stiebitz)"),
    new Book("Shakespeare, William: Hamlet (Brno: Atlantis, 2016, p�eklad: Martin Hilsk�)"),
    new Book("Shakespeare, William: Kupec ben�tsk� (Brno: Atlantis, 2012, p�eklad: Martin Hilsk�)"),
    new Book("Shakespeare, William: Romeo a Julie (Brno: Atlantis, 2015, p�eklad: Martin Hilsk�)"),
    new Book("Swift, Jonathan: Gulliverovy cesty (Praha: Dobrovsk�, 2014, p�eklad: Jan V��a)")
}),
new BookCategory("Sv�tov� a �esk� literatura 19. stolet�", new List<Book>
{
    new Book("Balzac, Honor� de: Otec Goriot (Praha: Odeon, 1970, p�eklad: Bo�ena Zimov�)"),
    new Book("Borovsk�, Karel Havl��ek: Kr�l L�vra"),
    new Book("Borovsk�, Karel Havl��ek: Tyrolsk� elegie"),
    new Book("Dickens, Charles: Oliver Twist (Praha: Argo, 2014, p�eklad: Zden�k Fr�bort)"),
    new Book("Dickens, Charles: V�no�n� koleda (Praha: XYZ, 2010, p�eklad: Jan V��a)"),
    new Book("Dostojevskij, Fjodor Michajlovi�: Zlo�in a trest (Praha: Academia, 2007, p�eklad: Jaroslav Hul�k)"),
    new Book("Dumas, Alexandre st.: T�i mu�ket��i (Praha: SNKL, 1956, p�eklad: Jaroslav a R��enaPochovi)"),
    new Book("Erben, Karel Jarom�r: Kytice"),
    new Book("Gogol, Nikolaj Vasiljevi�: Revizor (Praha: Odeon, 1986, p�eklad: Karel Milota)"),
    new Book("Hugo, Victor: B�dn�ci (Praha: Odeon, 1984, p�eklad: Zde�ka Pavlouskov�)"),
    new Book("Hugo, Victor: Chr�m Matky Bo�� v Pa��i (Praha: Odeon, 1978, p�eklad: Milena Tom�kov�)"),
    new Book("M�cha, Karel Hynek: M�j"),
    new Book("Mr�t�kov�, Alois a Vil�m: Mary�a"),
    new Book("N�mcov�, Bo�ena: Babi�ka"),
    new Book("Neruda, Jan: Pov�dky malostransk�"),
    new Book("Poe, Edgar Allan: Havran (Praha: Doko��n, 2008, p�eklad: V�t�zslav Nezval)"),
    new Book("Poe, Edgar Allan: Pov�dky (Praha: Odeon 1987, p�eklad: Josef Schwarz)"),
    new Book("Pu�kin, Alexandr Sergejevi�: Ev�en On�gin (Praha: Odeon, 1987, p�eklad: Olga Ma�kov�)"),
    new Book("Stroupe�nick�, Ladislav: Na�i Furianti"),
    new Book("Tolstoj, Lev Nikolajevi�: Anna Karenina (Praha: Lidov� nakladatelstv�, 1973, p�eklad: Ta��na Ha�kov�)"),
    new Book("Tyl, Josef Kajet�n: Strakonick� dud�k aneb Hody div�ch �en"),
    new Book("Vrchlick�, Jaroslav: Noc na Karl�tejn�"),
    new Book("Wilde, Oscar: Obraz Doriana Greye (Praha: Mlad� fronta, 1999, p�eklad: Ji�� Zden�k Nov�k)")
}),
new BookCategory("Sv�tov� literatura 20. a 21. stolet�", new List<Book>
{
    new Book("Brown, Dan: And�l� a d�moni (Praha: Ago, 2006, p�eklad: Michala Markov�)"),
    new Book("Brown, Dan: �ifra mistra Leonarda (Praha: Ago, 2010, p�eklad: Zd�k Du�ek)"),
    new Book("Doyle, Artur Conan: Pes baskervillsk� (Praha: SNKL, 1956, p�eklad: Jaroslav a R��ena Pochovi)"),
    new Book("Eco, Umberto: Jm�no r��e (Praha: Argo, 2014, p�eklad: Zden�k Fr�bort)"),
    new Book("Fitzgerald, Francis Scott: Velk� Gatsby (Praha: LEDA, 2011, p�eklad: Rudolf �ervenka a Alexander Tomsk�)"),
    new Book("Heller, Joseph: Hlava XXII. (Praha: Odeon, 1979, p�eklad: Miroslav Jindra)"),
    new Book("Hemingway, Ernest: Pov�dky (Praha: Odeon 1978, p�eklad: Radoslav Nenad�l)"),
    new Book("Hemingway, Ernest: Sta�ec a mo�e (Praha: Odeon, 2015, p�eklad: �imon Pellar)"),
    new Book("Christie, Agatha: Smrt na Nilu (Praha: Kni�n� klub, 2010, p�eklad: Drahom�ra Hlinkov�)"),
    new Book("Christie, Agatha: Vra�da v Orient Expressu (Praha: Kni�n� klub, 2003, p�eklad: Eva Kondrysov�)"),
    new Book("Martin, George R. R.: Hra o tr�ny (P�elo�il Michala MARKOV�. Praha: Argo, 2017)"),
    new Book("Orwell, George: 1984 (Praha: Argo, 2011, p�eklad: Petr Mart�nkov�)"),
    new Book("Orwell, George: Farma zv��at (P�elo�il Gabriel G�SSEL, p�elo�il Milo� HOLUB. Praha: Ma�a, 2021)"),
    new Book("Remarque, Erich Maria: Na z�padn� front� klid (Praha: Na�e vojsko, 1967, p�eklad: Franti�ek Gel)"),
    new Book("Riordan, Rick: Percy Jackson: Zlod�j blesku (Praha: Fragment, 2009, p�eklad: Dana Chodilov�)"),
    new Book("Rolland, Romain: Petr a Lucie (Praha: Pr�ce, 1985, p�eklad: Jaroslav Zaor�lek)"),
    new Book("Rowlingov�, Joanne K.: Harry Potter a K�men mudrc� (Praha: Albatros, 2000, p�eklad: Vladim�r Medek)"),
    new Book("Ryan, Patrick: Jak jsem vyhr�l v�lku (Praha: Na�e vojsko, 1985, p�eklad: Franti�ek Vrba)"),
    new Book("Saint-Exup�ry, Antoine de: Mal� princ (Praha: Albatros, 1977, p�eklad: Zde�ka Stavinohov�)"),
    new Book("Styron, William: Sophiina volba (Praha: Odeon, 1985, p�eklad: Radoslav Nenad�l)"),
    new Book("Tolkien, John Ronald Reuel: Hobit, aneb, Cesta tam a zase zp�tky.(Ilustroval JemimaCATLIN, p�elo�il Franti�ek VRBA. Praha: Argo, 2013)"),
    new Book("Tolkien, John Ronald Reuel: P�n prsten�: Spole�enstvo prstenu (Praha: Mlad� Fronta,2001, p�eklad: Stanislava Po�ustov�)")
}),
new BookCategory("�esk� literatura 20. a 21. stolet�", new List<Book>
{
    new Book("Bezru�, Petr: Slezsk� p�sn�"),
    new Book("�apek, Karel: B�l� nemoc"),
    new Book("�apek, Karel: Pov�dky z druh� kapsy"),
    new Book("�apek, Karel: Pov�dky z druh� kapsy"),
    new Book("�apek, Karel: R. U. R."),
    new Book("�apek, Karel: V�lka s mloky"),
    new Book("Dyk, Viktor: Krysa�"),
    new Book("Fuks, Ladislav: Spalova� mrtvol"),
    new Book("Ha�ek, Jaroslav: Osudy dobr�ho voj�ka �vejka za sv�tov� v�lky"),
    new Book("Hrabal, Bohumil: Ost�e sledovan� vlaky"),
    new Book("Hrabal, Bohumil: Post�i�iny"),
    new Book("Jir�sek, Alois: Star� pov�sti �esk�"),
    new Book("Kafka, Franz: Prom�na (Praha: Vy�ehrad, 2005, p�eklad: Vladim�r Kafka)"),
    new Book("Kryl, Karel: Kn�ka"),
    new Book("Lustig, Arno�t: Modlitba pro Kate�inu Horowitzovou"),
    new Book("Pavel, Ota: Smrt kr�sn�ch srnc�"),
    new Book("Peti�ka, Eduard: Star� �eck� b�je a pov�sti"),
    new Book("Pol��ek, Karel: Bylo n�s p�t"),
    new Book("Smoljak, Ladislav Sv�r�k, Zden�k: Dobyt� severn�ho p�lu"),
    new Book("Van�ura, Vladislav: Rozmarn� l�to"),
    new Book("Viewegh, Michal: B�je�n� l�ta pod psa")
})
      };
    }

    // Aktualizuje stav p�i zm�n� v�b�ru knihy
    public async void BookCheckedChanged(Book book)
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

        // Pokud je dosa�en maxim�ln� po�et, zak�zat dal�� v�b�r
        bool shouldDisable = selectedCount >= MaxSelectedBooks;

        foreach (var b in BookCategories.SelectMany(c => c.Books))
        {
            b.IsEnabled = !shouldDisable || b.IsSelected;
        }

        UpdateSelectionStatus(); // Aktualizace UI
        SaveSelectedBooks(); // Ulo�en� vybran�ch knih
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

    // Aktualizuje stavov� text pro u�ivatele
    private void UpdateSelectionStatus()
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);
        SelectionStatus = $"Vybr�no: {selectedCount} / {MaxSelectedBooks} knih";
    }

    // Ulo�� seznam vybran�ch knih do u�ivatelsk�ch preferenc�
    private void SaveSelectedBooks()
    {
        var selectedBooks = BookCategories
                            .SelectMany(c => c.Books)
                            .Where(b => b.IsSelected)
                            .Select(b => b.Title)
                            .ToList();

        Preferences.Set("SelectedBooks", string.Join("|||", selectedBooks)); // Odd�lova� "|||" zabra�uje konflikt�m
    }

    // Na�te d��ve vybran� knihy ze syst�mu
    private void LoadSelectedBooks()
    {
        if (Preferences.ContainsKey("SelectedBooks"))
        {
            var selectedTitles = Preferences.Get("SelectedBooks", "").Split("|||", StringSplitOptions.RemoveEmptyEntries);

            foreach (var book in BookCategories.SelectMany(c => c.Books))
            {
                book.IsSelected = selectedTitles.Contains(book.Title);
            }

            UpdateSelectionStatus(); // Aktualizace UI po na�ten�
        }
    }

    // Implementace rozhran� INotifyPropertyChanged pro spr�vnou aktualizaci UI
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
