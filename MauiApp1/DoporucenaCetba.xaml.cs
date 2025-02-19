using MauiApp1.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;




namespace MauiApp1;

public partial class DoporucenaCetba : ContentPage
{
    // ViewModel pro propojení s UI
    public BooksViewModel ViewModel { get; }

    public DoporucenaCetba()
    {
        InitializeComponent();
        ViewModel = new BooksViewModel();
        BindingContext = ViewModel;
    }

    // Metoda, která se spustí pøi kliknutí na tlaèítko pro generování PDF
    public async void OnGeneratePdfClicked(object sender, EventArgs e)
    {
        // Zavolání metody pro generování PDF
        GeneratePdf();
    }

    // Metoda pro generování PDF souboru
    public void GeneratePdf()
    {
        // Získání vybraných knih
        var selectedBooks = ViewModel.BookCategories.SelectMany(c => c.Books)
                                                    .Where(b => b.IsSelected)
                                                    .OrderBy(b => b.Title, StringComparer.Create(new System.Globalization.CultureInfo("cs-CZ"), false)) // Seøazeno podle èeské abecedy
                                                    .ToList();

        if (selectedBooks.Count == 0)
        {
            DisplayAlert("Chyba", "Žádná kniha není vybraná.", "OK");
            return;
        }

        // Vytvoøení PDF dokumentu
        var document = new PdfDocument();
        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12, XFontStyle.Regular);

        double yPoint = 20;

        gfx.DrawString("Doporuèená èetba", font, XBrushes.Black, new XPoint(20, yPoint));
        yPoint += 20;

        // Iterace pøes vybrané knihy a jejich zobrazení na jednom øádku
        int bookNumber = 1;
        foreach (var book in selectedBooks)
        {
            string bookInfo = $"{bookNumber}. - {book.Title}";
            gfx.DrawString(bookInfo, font, XBrushes.Black, new XPoint(20, yPoint));
            yPoint += 20;

            // Zajištìní, že text nepøekroèí stránku
            if (yPoint > page.Height - 50)
            {
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPoint = 20;
            }

            bookNumber++;
        }

        // Uložení PDF souboru
        var fileName = Path.Combine(FileSystem.AppDataDirectory, "Cetba.pdf");
        document.Save(fileName);

        // Informace o úspìchu
        DisplayAlert("Úspìch", $"PDF soubor byl uložen na {fileName}.", "OK");
    }

    // Metoda pro zpracování zmìny stavu checkboxu (pokud se zaškrtnou/nezaškrtnou knihy)
    private void OnBookCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is Book book)
        {
            ViewModel.BookCheckedChanged(book);

            // Aktualizace poètu vybraných knih
            int selectedCount = ViewModel.BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

            // Zobrazí hlášku, pokud je dosažen limit
            //LimitWarningLabel.IsVisible = selectedCount >= 20;
        }
    }

}
