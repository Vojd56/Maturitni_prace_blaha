using MauiApp1.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;




namespace MauiApp1;

public partial class DoporucenaCetba : ContentPage
{
    // ViewModel pro propojen� s UI
    public BooksViewModel ViewModel { get; }

    public DoporucenaCetba()
    {
        InitializeComponent();
        ViewModel = new BooksViewModel();
        BindingContext = ViewModel;
    }

    // Metoda, kter� se spust� p�i kliknut� na tla��tko pro generov�n� PDF
    public async void OnGeneratePdfClicked(object sender, EventArgs e)
    {
        // Zavol�n� metody pro generov�n� PDF
        GeneratePdf();
    }

    // Metoda pro generov�n� PDF souboru
    public void GeneratePdf()
    {
        // Z�sk�n� vybran�ch knih
        var selectedBooks = ViewModel.BookCategories.SelectMany(c => c.Books)
                                                    .Where(b => b.IsSelected)
                                                    .OrderBy(b => b.Title, StringComparer.Create(new System.Globalization.CultureInfo("cs-CZ"), false)) // Se�azeno podle �esk� abecedy
                                                    .ToList();

        if (selectedBooks.Count == 0)
        {
            DisplayAlert("Chyba", "��dn� kniha nen� vybran�.", "OK");
            return;
        }

        // Vytvo�en� PDF dokumentu
        var document = new PdfDocument();
        var page = document.AddPage();
        var gfx = XGraphics.FromPdfPage(page);
        var font = new XFont("Verdana", 12, XFontStyle.Regular);

        double yPoint = 20;

        gfx.DrawString("Doporu�en� �etba", font, XBrushes.Black, new XPoint(20, yPoint));
        yPoint += 20;

        // Iterace p�es vybran� knihy a jejich zobrazen� na jednom ��dku
        int bookNumber = 1;
        foreach (var book in selectedBooks)
        {
            string bookInfo = $"{bookNumber}. - {book.Title}";
            gfx.DrawString(bookInfo, font, XBrushes.Black, new XPoint(20, yPoint));
            yPoint += 20;

            // Zaji�t�n�, �e text nep�ekro�� str�nku
            if (yPoint > page.Height - 50)
            {
                page = document.AddPage();
                gfx = XGraphics.FromPdfPage(page);
                yPoint = 20;
            }

            bookNumber++;
        }

        // Ulo�en� PDF souboru
        var fileName = Path.Combine(FileSystem.AppDataDirectory, "Cetba.pdf");
        document.Save(fileName);

        // Informace o �sp�chu
        DisplayAlert("�sp�ch", $"PDF soubor byl ulo�en na {fileName}.", "OK");
    }

    // Metoda pro zpracov�n� zm�ny stavu checkboxu (pokud se za�krtnou/neza�krtnou knihy)
    private void OnBookCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is Book book)
        {
            ViewModel.BookCheckedChanged(book);

            // Aktualizace po�tu vybran�ch knih
            int selectedCount = ViewModel.BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);

            // Zobraz� hl�ku, pokud je dosa�en limit
            //LimitWarningLabel.IsVisible = selectedCount >= 20;
        }
    }

}
