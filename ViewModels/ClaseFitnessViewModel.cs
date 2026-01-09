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
    // Moștenim ObservableObject pentru a notifica UI-ul când proprietățile se schimbă
    public partial class ClaseFitnessViewModel : ObservableObject
    {
        private readonly ClasaFitnessService _clasaFitnessService;

        // Lista de clase care va fi afișată în UI
        public ObservableCollection<ClasaFitnessDTO> Clase { get; } = new();

        // Variabilă pentru a urmări starea de încărcare (Loading)
        [ObservableProperty]
        bool isBusy;

        // Variabilă pentru a urmări dacă lista este goală
        [ObservableProperty]
        bool isListEmpty = true;

        public ICommand GetClaseCommand { get; }

        public ClaseFitnessViewModel(ClasaFitnessService clasaFitnessService)
        {
            _clasaFitnessService = clasaFitnessService;

            // Inițializează comanda care va fi apelată de UI
            GetClaseCommand = new AsyncRelayCommand(LoadClaseAsync);

            // Opțional: Începe încărcarea datelor imediat la pornirea ViewModel-ului
            LoadClaseAsync();
        }

        public async Task LoadClaseAsync()
        {
            if (IsBusy) // Previne apelurile multiple simultane
                return;

            try
            {
                IsBusy = true;

                var claseList = await _clasaFitnessService.GetGroupClassesAsync();

                // Golește lista curentă
                Clase.Clear();

                if (claseList.Any())
                {
                    // Adaugă noile date în lista observabilă
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
                // Tratarea erorilor (de exemplu, afișarea unui mesaj)
                Console.WriteLine($"Eroare la încărcarea claselor: {ex.Message}");
                // MAUI oferă metode pentru a afișa mesaje către utilizator, dar deocamdată folosim Console.
                await Shell.Current.DisplayAlert("Eroare", "Nu s-au putut încărca clasele. Verificați conexiunea la server.", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
