using ProGymMobile.ViewModels;
using Microsoft.Maui.Controls;

namespace ProGymMobile.Views;


public partial class ClaseFitnessPage : ContentPage
{
   
    public ClaseFitnessPage(ClaseFitnessViewModel viewModel)
    {
        InitializeComponent();
       
        BindingContext = viewModel;
    }

    
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        
        if (BindingContext is ClaseFitnessViewModel viewModel &&
            viewModel.Clase.Count == 0 &&
            !viewModel.IsBusy)
        {
            await viewModel.LoadClaseAsync();
        }
    }
}