namespace ProGymMobile.Views;

public partial class HomePage : ContentPage
{
	public HomePage()
	{
		InitializeComponent();
	}
    private async void OnClaseFitnessClicked(object sender, EventArgs e)
    {
        // Navig?m c?tre pagina de clase (folosind "Route" setat în AppShell)
        await Shell.Current.GoToAsync("ClaseFitnessRoute");
    }
}