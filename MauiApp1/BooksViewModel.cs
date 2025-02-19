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
                OnPropertyChanged(nameof(BookCategories)); // Ozn�men� zm�ny pro UI
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
                OnPropertyChanged(nameof(IsSelectionLimitReached)); // Spr�vn� zm�na
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
             new BookCategory("Sv�tov� a �esk� literatura do konce 18. stolet�", new List<Book>
  {
      new Book("Dekameron", "Giovanni Boccaccio"),
      new Book("Robinson Crusoe", "Daniel Defoe"),
      new Book("Gilgame�", "Nezn�m� autor"),
      new Book("Lakomec", "Moli�re"),
      new Book("Prom�ny", "Publius Ovidius Naso"),
      new Book("Hamlet", "William Shakespeare"),
      new Book("Kupec ben�tsk�", "William Shakespeare"),
      new Book("Romeo a Julie", "William Shakespeare"),
      new Book("Gulliverovy cesty", "Jonathan Swift")
  }),
  new BookCategory("Sv�tov� a �esk� literatura 19. stolet�", new List<Book>
  {
      new Book("Otec Goriot", "Honor� de Balzac"),
      new Book("Kr�l L�vra", "Karel Havl��ek Borovsk�"),
      new Book("Tyrolsk� elegie", "Karel Havl��ek Borovsk�"),
      new Book("Oliver Twist", "Charles Dickens"),
      new Book("V�no�n� koleda", "Charles Dickens"),
      new Book("Zlo�in a trest", "Fjodor Michajlovi� Dostojevskij"),
      new Book("T�i mu�ket��i", "Alexandre Dumas"),
      new Book("Kytice", "Karel Jarom�r Erben"),
      new Book("Revizor", "Nikolaj Vasiljevi� Gogol"),
      new Book("B�dn�ci", "Victor Hugo"),
      new Book("Chr�m Matky Bo�� v Pa��i", "Victor Hugo"),
      new Book("M�j", "Karel Hynek M�cha"),
      new Book("Mary�a", "Alois a Vil�m Mr�t�kov�"),
      new Book("Babi�ka", "Bo�ena N�mcov�"),
      new Book("Pov�dky malostransk�", "Jan Neruda"),
      new Book("Havran", "Edgar Allan Poe"),
      new Book("Pov�dky", "Edgar Allan Poe"),
      new Book("Ev�en On�gin", "Alexandr Sergejevi� Pu�kin"),
      new Book("Na�i Furianti", "Ladislav Stroupe�nick�"),
      new Book("Anna Karenina", "Lev Nikolajevi� Tolstoj"),
      new Book("Strakonick� dud�k", "Josef Kajet�n Tyl"),
      new Book("Noc na Karl�tejn�", "Jaroslav Vrchlick�"),
      new Book("Obraz Doriana Greye", "Oscar Wilde")
  }),
  new BookCategory("Sv�tov� literatura 20. a 21. stolet�", new List<Book>
  {
      new Book("And�l� a d�moni", "Dan Brown"),
      new Book("�ifra mistra Leonarda", "Dan Brown"),
      new Book("Pes baskervillsk�", "Arthur Conan Doyle"),
      new Book("Jm�no r��e", "Umberto Eco"),
      new Book("Velk� Gatsby", "Francis Scott Fitzgerald"),
      new Book("Hlava XXII.", "Joseph Heller"),
      new Book("Pov�dky", "Ernest Hemingway"),
      new Book("Sta�ec a mo�e", "Ernest Hemingway"),
      new Book("Smrt na Nilu", "Agatha Christie"),
      new Book("Vra�da v Orient Expressu", "Agatha Christie"),
      new Book("Hra o tr�ny", "George R. R. Martin"),
      new Book("1984", "George Orwell"),
      new Book("Farma zv��at", "George Orwell"),
      new Book("Na z�padn� front� klid", "Erich Maria Remarque"),
      new Book("Percy Jackson: Zlod�j blesku", "Rick Riordan"),
      new Book("Petr a Lucie", "Romain Rolland"),
      new Book("Harry Potter a K�men mudrc�", "Joanne K. Rowlingov�"),
      new Book("Jak jsem vyhr�l v�lku", "Patrick Ryan"),
      new Book("Mal� princ", "Antoine de Saint-Exup�ry"),
      new Book("Sophiina volba", "William Styron"),
      new Book("Hobit", "J. R. R. Tolkien"),
      new Book("P�n prsten�: Spole�enstvo prstenu", "J. R. R. Tolkien")
  }),
  new BookCategory("�esk� literatura 20. a 21. stolet�", new List<Book>
  {
      new Book("Slezsk� p�sn�", "Petr Bezru�"),
      new Book("B�l� nemoc", "Karel �apek"),
      new Book("Pov�dky z druh� kapsy", "Karel �apek"),
      new Book("Pov�dky z jedn� kapsy", "Karel �apek"),
      new Book("R.U.R.", "Karel �apek"),
      new Book("V�lka s mloky", "Karel �apek"),
      new Book("Krysa�", "Viktor Dyk"),
      new Book("Spalova� mrtvol", "Ladislav Fuks"),
      new Book("Osudy dobr�ho voj�ka �vejka", "Jaroslav Ha�ek"),
      new Book("Ost�e sledovan� vlaky", "Bohumil Hrabal"),
      new Book("Post�i�iny", "Bohumil Hrabal"),
      new Book("Star� pov�sti �esk�", "Alois Jir�sek"),
      new Book("Prom�na", "Franz Kafka"),
      new Book("Kn�ka", "Karel Kryl"),
      new Book("Modlitba pro Kate�inu Horowitzovou", "Arno�t Lustig"),
      new Book("Smrt kr�sn�ch srnc�", "Ota Pavel"),
      new Book("Star� �eck� b�je a pov�sti", "Eduard Peti�ka"),
      new Book("Bylo n�s p�t", "Karel Pol��ek"),
      new Book("Dobyt� severn�ho p�lu", "Ladislav Smoljak, Zden�k Sv�r�k"),
      new Book("Rozmarn� l�to", "Vladislav Van�ura"),
      new Book("B�je�n� l�ta pod psa", "Michal Viewegh")
  })
        };
    }

    public async void BookCheckedChanged(Book book)
    {
        int selectedCount = BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

        if (selectedCount == MaxSelectedBooks)
        {
            //book.IsSelected = false;
            //await Application.Current.MainPage.DisplayAlert("Limit dosa�en",
            //    $"Vybral jsi ji� {MaxSelectedBooks} knih.", "OK");
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