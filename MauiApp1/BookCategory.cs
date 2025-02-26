using System.Collections.ObjectModel;

namespace MauiApp1.Models
{
    // Třída reprezentující kategorii knihy
    public class BookCategory
    {
        // Název kategorie knihy (například "Sci-fi", "Historie" apod.)
        public string CategoryName { get; set; }

        // Seznam knih, které spadají do této kategorie
        public ObservableCollection<Book> Books { get; set; }

        // Konstruktor pro inicializaci nové kategorie knihy s názvem a seznamem knih
        public BookCategory(string categoryName, List<Book> books)
        {
            // Nastaví název kategorie
            CategoryName = categoryName;

            // Převede seznam knih na ObservableCollection, aby bylo možné reagovat na změny
            Books = new ObservableCollection<Book>(books);
        }
    }
}
