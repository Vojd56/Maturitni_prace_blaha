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
            "Vyu�uj�c�:\n- Boh��ov�\n- Haas\n- Koslov�\n- Zaor�lkov�\n- Ondru�ov�",
            "Zp�t");
    }
    private async void OnKabinetA4Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Informace", "Nevyu�it� m�stnost", "Zp�t");
    }
    private async void OnKabinetA3Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A3", "V�chovn� poradkyn�:\n- Mgr. Barbora Cie�larov�\n�koln� psycholog:\n- Mgr. Marek Nytra", "Zp�t");
    }

    private async void OnKabinetA2Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A2", "Z�stupce �editelky pro teoretickou v�uku:\n- Ing. Tom� Havl�sek\nStudijn� referentka:\n- Mgr. Blanka Pod�orsk�", "Zp�t");
    }
    private async void OnKabinetA106Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A106", "Vyu�uj�c�:\n- Pil��ov�\n- �t�p�nov�", "Zp�t");
    }
    private async void OnKabinetA102Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A102", "Vyu�uj�c�:\n- Poleh�a\n- Walder", "Zp�t");
    }
    private async void OnKabinetA113Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A113", "Vyu�uj�c�:\n- Ma��k\n- Strako�\n- Rybn�k��", "Zp�t");
    }
    private async void OnSekratariatTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Sekretari�t", "Asistentka �editelky �koly:\n- Alena Rakov�", "Zp�t");
    }
    private async void OnReditelnaTapped(object sender, EventArgs e)
    {
        await DisplayAlert("�editelna", "�editelka �koly\n- Mgr. Andrea Pytlikov�", "Zp�t");
    }
    private async void OnKabinetA205Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A205", "Vyu�uj�c�:\n- Ratimorsk�\n- Such�nkov�\n- Sedl��kov�", "Zp�t");
    }
    private async void OnKabinetA203Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A203", "Vyu�uj�c�:\n- Bachura \n- Foldyna\n- Toma�ula\n- Zeman", "Zp�t");
    }
    private async void OnKabinetC205Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C205", "Vyu�uj�c�:\n- Gre�malov� \n- S�korov�", "Zp�t");
    }
    private async void OnKabinetC203Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C203", "Vyu�uj�c�:\n- Holovka \n- Lichmovsk�", "Zp�t");
    }
    private async void OnKabinetC201Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C201", "Vyu�uj�c�:\n- Trebichalsk� \n- Valcuch", "Zp�t");
    }
    private async void OnKabinetA301Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A301", "Vyu�uj�c�:\n- J�lek \n- Babinec", "Zp�t");
    }
    private async void OnKabinetA306Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet A306", "Vyu�uj�c�:\n- O�ana \n- Plevov�\n- Prokopov�", "Zp�t");
    }
    private async void OnKabinetC305Tapped(object sender, EventArgs e)
    {
        await DisplayAlert("Kabinet C305", "Vyu�uj�c�:\n- Nikdo Nejsp�", "Zp�t");
    }
    private async void OnServerovnaTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Serverovna", "Vyu�uj�c�:\n- Besuch \n- Kapcala\n- Pavlovsk�", "Zp�t");
    }
}
