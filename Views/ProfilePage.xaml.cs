namespace ProGymMobile.Views;
using ProGymMobile.Models;
using ProGymMobile.Services;

public partial class ProfilePage : ContentPage
{
    UserService _userService;

    public ProfilePage(UserService userService)
    {
        InitializeComponent();
        _userService = userService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        
        var profile = await _userService.GetMyProfileAsync();

        if (profile == null)
        {
        
            await DisplayAlert("Eroare", "Sesiunea a expirat. Te rugăm să te reconectezi.", "OK");
            await Navigation.PopToRootAsync();
        }
        else
        {
            
            BindingContext = profile;

           
            listAbonamente.ItemsSource = profile.Abonamente;
        }
    }

    async void OnSaveProfileClicked(object sender, EventArgs e)
    {
        var profilCurent = (UserProfileDTO)BindingContext;

        if (profilCurent == null) return;

       
        var success = await _userService.UpdateProfileAsync(profilCurent);

        if (success)
        {
            await DisplayAlert("Succes", "Profilul a fost actualizat în baza de date!", "OK");
        }
        else
        {
            await DisplayAlert("Eroare", "Nu s-a putut efectua actualizarea.", "OK");
        }
    }

    async void OnDeleteAccountClicked(object sender, EventArgs e)
    {
        var profilCurent = (UserProfileDTO)BindingContext;

        if (await DisplayAlert("Atenție", "Sigur vrei să ștergi contul definitiv?", "Da", "Nu"))
        {
           
            var success = await _userService.DeleteAccountAsync(profilCurent.Email);

            if (success)
            {
                await DisplayAlert("Adio", "Contul tău a fost șters.", "OK");
                
                Application.Current.MainPage = new NavigationPage(new HomePage());
            }
        }
    }
}