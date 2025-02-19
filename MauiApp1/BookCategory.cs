using System.Collections.ObjectModel;

namespace MauiApp1.Models
{
    public class BookCategory
    {
        public string CategoryName { get; set; }
        public ObservableCollection<Book> Books { get; set; }

        public BookCategory(string categoryName, List<Book> books)
        {
            CategoryName = categoryName;
            Books = new ObservableCollection<Book>(books);
        }
    }


}
