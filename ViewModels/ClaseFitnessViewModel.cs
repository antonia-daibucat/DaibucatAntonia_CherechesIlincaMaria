using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProGymMobile.Models;
using ProGymMobile.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProGymMobile.ViewModels
{
   
    public partial class ClaseFitnessViewModel : ObservableObject
    {
        private readonly ClasaFitnessService _clasaFitnessService;

       
        public ObservableCollection<ClasaFitnessDTO> Clase { get; } = new();

       
        [ObservableProperty]
        bool isBusy;

        
        [ObservableProperty]
        bool isListEmpty = true;

        public ICommand GetClaseCommand { get; }

        public ClaseFitnessViewModel(ClasaFitnessService clasaFitnessService)
        {
            _clasaFitnessService = clasaFitnessService;

          
            GetClaseCommand = new AsyncRelayCommand(LoadClaseAsync);


            LoadClaseAsync();
        }

        public async Task LoadClaseAsync()
        {
            if (IsBusy) 
                return;

            try
            {
                IsBusy = true;

                var claseList = await _clasaFitnessService.GetGroupClassesAsync();

               
                Clase.Clear();

                if (claseList.Any())
                {
                    
                    foreach (var clasa in claseList)
                    {
                        Clase.Add(clasa);
                    }
                    IsListEmpty = false;
                }
                else
                {
                    IsListEmpty = true;
                }
            }
            catch (Exception ex)
            {
               
                Console.WriteLine($"Eroare la încărcarea claselor: {ex.Message}");
               
                await Shell.Current.DisplayAlert("Eroare", "Nu s-au putut încărca clasele. Verificați conexiunea la server.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
