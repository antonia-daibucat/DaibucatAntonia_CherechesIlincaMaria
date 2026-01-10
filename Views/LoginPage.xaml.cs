namespace ProGymMobile.Views;
using ProGymMobile.Services;

public partial class LoginPage : ContentPage
{
    UserService _userService = new UserService();
    public LoginPage()
	{
		InitializeComponent();
	}
    async void OnLoginClicked(object sender, EventArgs e)
    {
        string email = entEmail.Text;
        string parola = entParola.Text;

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(parola))
        {
            await DisplayAlert("Eroare", "Te rug?m s? introduci email-ul ?i parola.", "OK");
            return;
        }

      
        var success = await _userService.LoginAsync(email, parola);

        if (success)
        {
           
            await Navigation.PushAsync(new ProfilePage(_userService));
        }
        else
        {
            await DisplayAlert("Eroare", "Email sau parol? incorect?. Verific? datele.", "OK");
        }
    }

    async void OnGoToRegisterClicked(object sender, EventArgs e)
    {
       
        await Navigation.PushAsync(new RegisterPage());
    }
}