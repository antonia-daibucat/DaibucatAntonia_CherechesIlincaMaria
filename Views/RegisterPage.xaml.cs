namespace ProGymMobile.Views;
using ProGymMobile.Models;
using ProGymMobile.Services;
public partial class RegisterPage : ContentPage
{
    UserService _userService = new UserService();
  

    public RegisterPage()
    {
        InitializeComponent();
    }

    async void OnRegisterClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entEmail.Text) || string.IsNullOrWhiteSpace(entParola.Text))
        {
            await DisplayAlert("Eroare", "Email-ul și Parola sunt obligatorii!", "OK");
            return;
        }

        
        var nouUser = new UserProfileDTO
        {
            Email = entEmail.Text,
            Parola = entParola.Text, 
            Nume = entNume.Text,
            Prenume = entPrenume.Text,
            Telefon = entTelefon.Text
        };

       
        var success = await _userService.RegisterAsync(nouUser);

        if (success)
        {
            await DisplayAlert("Succes", "Contul a fost creat în baza de date Web! Te poți loga acum.", "OK");

           
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Eroare", "Serverul a respins salvarea. Email-ul ar putea exista deja.", "OK");
        }
    }
}