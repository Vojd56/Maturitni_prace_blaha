namespace MauiApp1;

public partial class Kontakty : ContentPage
{
    public Kontakty()
    {
        InitializeComponent();
    }


    private async void OnKabinetA8Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A8",
            "Vyuèující:\n- Boháèová\n- Haas\n- Koslová\n- Zaorálková\n- Ondrušová",
            "Zpìt");
    }
    private async void OnKabinetA4Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Informace", "Nevyužitá místnost", "Zpìt");
    }
    private async void OnKabinetA3Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A3", "Výchovná poradkynì:\n- Mgr. Barbora Cieœlarová\nŠkolní psycholog:\n- Mgr. Marek Nytra", "Zpìt");
    }

    private async void OnKabinetA2Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A2", "Zástupce øeditelky pro teoretickou výuku:\n- Ing. Tomáš Havlásek\nStudijní referentka:\n- Mgr. Blanka Podžorská", "Zpìt");
    }
    private async void OnKabinetA106Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A106", "Vyuèující:\n- Piláøová\n- Štìpánová", "Zpìt");
    }
    private async void OnKabinetA102Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A102", "Vyuèující:\n- Polehòa\n- Walder", "Zpìt");
    }
    private async void OnKabinetA113Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A113", "Vyuèující:\n- Mašík\n- Strakoš\n- Rybníkáø", "Zpìt");
    }
    private async void OnSekratariatTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Sekretariát", "Asistentka øeditelky školy:\n- Alena Raková", "Zpìt");
    }
    private async void OnReditelnaTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Øeditelna", "Øeditelka školy\n- Mgr. Andrea Pytliková", "Zpìt");
    }
    private async void OnKabinetA205Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A205", "Vyuèující:\n- Ratimorský\n- Suchánková\n- Sedláèková", "Zpìt");
    }
    private async void OnKabinetA203Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A203", "Vyuèující:\n- Bachura \n- Foldyna\n- Tomašula\n- Zeman", "Zpìt");
    }
    private async void OnKabinetC205Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C205", "Vyuèující:\n- Greèmalový \n- Sýkorová", "Zpìt");
    }
    private async void OnKabinetC203Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C203", "Vyuèující:\n- Holovka \n- Lichmovská", "Zpìt");
    }
    private async void OnKabinetC201Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C201", "Vyuèující:\n- Trebichalský \n- Valcuch", "Zpìt");
    }
    private async void OnKabinetA301Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A301", "Vyuèující:\n- Jílek \n- Babinec", "Zpìt");
    }
    private async void OnKabinetA306Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A306", "Vyuèující:\n- Ožana \n- Plevová\n- Prokopová", "Zpìt");
    }
    private async void OnKabinetC305Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C305", "Vyuèující:\n- Nikdo Nejspíš", "Zpìt");
    }
    private async void OnServerovnaTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Serverovna", "Vyuèující:\n- Besuch \n- Kapcala\n- Pavlovská", "Zpìt");
    }
}
