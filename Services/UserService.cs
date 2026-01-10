using ProGymMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProGymMobile.Services
{
    public class UserService
    {
        private readonly HttpClient _httpClient;
       
        private const string BaseUrl = "https://localhost:7296";

        public UserService()
        {
            
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler); 
        }

        
        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? new HttpClient();
        }

    
        public async Task<bool> LoginAsync(string email, string parola)
        {
            try
            {
                var loginData = new { Email = email, Parola = parola };
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/ClientApi/Login", loginData);

                if (response.IsSuccessStatusCode)
                {
                    UserEmail = email; 
                    return true;
                }
                return false;
            }
            catch { return false; }
        }

       
        public async Task<bool> RegisterAsync(UserProfileDTO profile)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/api/ClientApi/Register", profile);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare Register: {ex.Message}");
                return false;
            }
        }

       
        public static string UserEmail { get; set; }

        public async Task<UserProfileDTO> GetMyProfileAsync()
        {
            try
            {
               
                HttpResponseMessage response = await _httpClient.GetAsync($"{BaseUrl}/api/ClientApi/MyProfile?email={UserEmail}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<UserProfileDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex) { Console.WriteLine($"Eroare API Profil: {ex.Message}"); }
            return null;
        }

       
        public async Task<bool> UpdateProfileAsync(UserProfileDTO profile)
        {
            var response = await _httpClient.PutAsJsonAsync($"{BaseUrl}/api/ClientApi/UpdateProfile", profile);
            return response.IsSuccessStatusCode;
        }

       
        public async Task<bool> DeleteAccountAsync(string email)
        {
            
            var response = await _httpClient.DeleteAsync($"{BaseUrl}/api/ClientApi/DeleteAccount/{email}");
            return response.IsSuccessStatusCode;
        }
    }
}