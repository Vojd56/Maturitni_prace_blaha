using MauiApp1.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;




namespace MauiApp1;

public partial class DoporucenaCetba : ContentPage
{

    // ViewModel pro propojení s UI
    public BooksViewModel ViewModel { get; set; }

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
    public async void GeneratePdf()
    {

        try
        {
            // Získání vybraných knih
            var selectedBooks = ViewModel.BookCategories.SelectMany(c => c.Books)
                                                        .Where(b => b.IsSelected)
                                                        .OrderBy(b => b.Title, StringComparer.Create(new System.Globalization.CultureInfo("cs-CZ"), false))
                                                        .ToList();

            if (selectedBooks.Count == 0)
            {
                await MainThread.InvokeOnMainThreadAsync(() => DisplayAlert("Chyba", "Žádná kniha není vybraná.", "OK"));
                return;
            }

            // Vytvoøení PDF dokumentu
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 12, XFontStyle.Regular);

            double yPoint = 20;
            // Získání šíøky plátna a šíøky textu pro první dva øádky
            double canvasWidth = gfx.PdfPage.Width;
            double text1Width = gfx.MeasureString("Seznam literárních dìl k ústní zkoušce", font).Width;
            double text2Width = gfx.MeasureString("z èeského jazyka a literatury", font).Width;

            // Výpoèet pozice pro støed
            double centerX1 = (canvasWidth - text1Width) / 2;
            double centerX2 = (canvasWidth - text2Width) / 2;

            // První dva øádky uprostøed
            gfx.DrawString("Seznam literárních dìl k ústní zkoušce", font, XBrushes.Black, new XPoint(centerX1, 20));
            gfx.DrawString("z èeského jazyka a literatury", font, XBrushes.Black, new XPoint(centerX2, 30));

            // Zbytek textu na levém okraji
            gfx.DrawString("Jméno:", font, XBrushes.Black, new XPoint(14, 60));
            gfx.DrawString("Tøída", font, XBrushes.Black, new XPoint(14, 80));
            gfx.DrawString("Školní rok: 2024/2025", font, XBrushes.Black, new XPoint(14, 10));

            yPoint += 90;

            // Iterace pøes vybrané knihy
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

            // **Uložení PDF souboru do složky aplikace**
            var fileName = Path.Combine(FileSystem.AppDataDirectory, "Cetba.pdf");
            document.Save(fileName);

            // **Zkontroluj, jestli se soubor správnì vytvoøil**
            if (File.Exists(fileName))
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                    DisplayAlert("Hotovo", $"Soubor byl uložen:\n{fileName}", "OK"));
            }
            else
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                    DisplayAlert("Chyba", "Nepodaøilo se uložit PDF soubor.", "OK"));
            }

            // **Otevøení PDF souboru**
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(fileName)
            });
        }
        catch (Exception ex)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
                DisplayAlert("Chyba", $"Došlo k chybì: {ex.Message}", "OK"));
        }
    }


    // Metoda pro zpracování zmìny stavu checkboxu (pokud se zaškrtnou/nezaškrtnou knihy)
    private void OnBookCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is Book book)
        {
            ViewModel.BookCheckedChanged(book);

            // Aktualizace poètu vybraných knih
            int selectedCount = ViewModel.BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);


        }
    }


}
