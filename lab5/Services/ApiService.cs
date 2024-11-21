using System.Net.Http.Json;
using System.Text.Json;
using lab5.Models; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lab5.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProductAndService>> GetProductsAndServicesAsync()
        {
            var response = await _httpClient.GetAsync("api/Data/ProductsAndServices");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching ProductsAndServices: {response.StatusCode} - {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received JSON for ProductsAndServices: {json}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<ProductAndService>>(json, options) ?? new List<ProductAndService>();
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync("api/Data/Locations");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching Locations: {response.StatusCode} - {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received JSON for Locations: {json}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Location>>(json, options) ?? new List<Location>();
        }

        public async Task<List<Organization>> GetOrganizationsAsync()
        {
            var response = await _httpClient.GetAsync("api/Data/Organizations");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching Organizations: {response.StatusCode} - {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received JSON for Organizations: {json}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Organization>>(json, options) ?? new List<Organization>();
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            var response = await _httpClient.GetAsync("api/Data/Countries");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching Countries: {response.StatusCode} - {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received JSON for Countries: {json}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Country>>(json, options) ?? new List<Country>();
        }

        public async Task<List<MovementLocation>> GetMovementLocationsAsync()
        {
            var response = await _httpClient.GetAsync("api/MovementLocations");

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                throw new Exception($"Error fetching MovementLocations: {response.StatusCode} - {errorContent}");
            }

            var json = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"Received JSON for MovementLocations: {json}");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<MovementLocation>>(json, options) ?? new List<MovementLocation>();
        }
    }
}
