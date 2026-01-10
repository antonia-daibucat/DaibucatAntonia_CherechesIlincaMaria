namespace ProGymMobile.Views;
using ProGymMobile.Services; 
using ProGymMobile.Views;
public partial class HomePage : ContentPage
{
    private object lblUserLogat;

    public HomePage()
	{
		InitializeComponent();
	}
    
    async void OnProfileClicked(object sender, EventArgs e)
    {
       
        await Navigation.PushAsync(new LoginPage());
    }

    private async void OnClaseFitnessClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("ClaseFitnessRoute");
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        var service = new UserService();
        var profil = await service.GetMyProfileAsync();

        
        if (profil != null)
        {
           
           // lblUserLogat.Text = $"Conectat ca: {profil.Email}";
        }
    }
}