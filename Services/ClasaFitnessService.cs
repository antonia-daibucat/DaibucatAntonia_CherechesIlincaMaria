using ProGymMobile.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProGymMobile.Services
{
    public class ClasaFitnessService
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions? options;


        
        private const string BaseUrl = "https://localhost:7296";


        public ClasaFitnessService()
        {
            
#if DEBUG
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
            _httpClient = new HttpClient(handler);
#else
            _httpClient = new HttpClient();
#endif
        }

        public async Task<List<ClasaFitnessDTO>> GetGroupClassesAsync()
        {
            var url = $"{BaseUrl}/api/ClientApi/GroupClasses";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true  
                };

                return JsonSerializer.Deserialize<List<ClasaFitnessDTO>>(content, options);
            }
           
            return new List<ClasaFitnessDTO>();
        }
    }
}
