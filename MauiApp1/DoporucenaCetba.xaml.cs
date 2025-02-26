using MauiApp1.Models;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;




namespace MauiApp1;

public partial class DoporucenaCetba : ContentPage
{

    // ViewModel pro propojen� s UI
    public BooksViewModel ViewModel { get; set; }

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
    public async void GeneratePdf()
    {

        try
        {
            // Z�sk�n� vybran�ch knih
            var selectedBooks = ViewModel.BookCategories.SelectMany(c => c.Books)
                                                        .Where(b => b.IsSelected)
                                                        .OrderBy(b => b.Title, StringComparer.Create(new System.Globalization.CultureInfo("cs-CZ"), false))
                                                        .ToList();

            if (selectedBooks.Count == 0)
            {
                await MainThread.InvokeOnMainThreadAsync(() => DisplayAlert("Chyba", "��dn� kniha nen� vybran�.", "OK"));
                return;
            }

            // Vytvo�en� PDF dokumentu
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);
            var font = new XFont("Verdana", 12, XFontStyle.Regular);

            double yPoint = 20;
            // Z�sk�n� ���ky pl�tna a ���ky textu pro prvn� dva ��dky
            double canvasWidth = gfx.PdfPage.Width;
            double text1Width = gfx.MeasureString("Seznam liter�rn�ch d�l k��stn� zkou�ce", font).Width;
            double text2Width = gfx.MeasureString("z��esk�ho jazyka a literatury", font).Width;

            // V�po�et pozice pro st�ed
            double centerX1 = (canvasWidth - text1Width) / 2;
            double centerX2 = (canvasWidth - text2Width) / 2;

            // Prvn� dva ��dky uprost�ed
            gfx.DrawString("Seznam liter�rn�ch d�l k��stn� zkou�ce", font, XBrushes.Black, new XPoint(centerX1, 20));
            gfx.DrawString("z��esk�ho jazyka a literatury", font, XBrushes.Black, new XPoint(centerX2, 30));

            // Zbytek textu na lev�m okraji
            gfx.DrawString("Jm�no:", font, XBrushes.Black, new XPoint(14, 60));
            gfx.DrawString("T��da", font, XBrushes.Black, new XPoint(14, 80));
            gfx.DrawString("�koln� rok: 2024/2025", font, XBrushes.Black, new XPoint(14, 10));

            yPoint += 90;

            // Iterace p�es vybran� knihy
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

            // **Ulo�en� PDF souboru do slo�ky aplikace**
            var fileName = Path.Combine(FileSystem.AppDataDirectory, "Cetba.pdf");
            document.Save(fileName);

            // **Zkontroluj, jestli se soubor spr�vn� vytvo�il**
            if (File.Exists(fileName))
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                    DisplayAlert("Hotovo", $"Soubor byl ulo�en:\n{fileName}", "OK"));
            }
            else
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                    DisplayAlert("Chyba", "Nepoda�ilo se ulo�it PDF soubor.", "OK"));
            }

            // **Otev�en� PDF souboru**
            await Launcher.OpenAsync(new OpenFileRequest
            {
                File = new ReadOnlyFile(fileName)
            });
        }
        catch (Exception ex)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
                DisplayAlert("Chyba", $"Do�lo k chyb�: {ex.Message}", "OK"));
        }
    }


    // Metoda pro zpracov�n� zm�ny stavu checkboxu (pokud se za�krtnou/neza�krtnou knihy)
    private void OnBookCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox && checkBox.BindingContext is Book book)
        {
            ViewModel.BookCheckedChanged(book);

            // Aktualizace po�tu vybran�ch knih
            int selectedCount = ViewModel.BookCategories.SelectMany(c => c.Books).Count(b => b.IsSelected);


        }
    }


}
