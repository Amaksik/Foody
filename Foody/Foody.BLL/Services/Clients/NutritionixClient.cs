using Foody.BLL.Interfaces.External;
using Foody.BLL.Services.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Clients
{
    public class NutritionixClient : INutritionixClient
    {
        private readonly HttpClient _client;

        public NutritionixClient(string apiUserToken, string apiUri, string apiId)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("x-app-id", apiId);
            _client.DefaultRequestHeaders.Add("x-app-key", apiUserToken);
            _client.BaseAddress = new Uri(apiUri);
        }

        public async Task<string> AnalyzeBarcodeAsync(long upc) //upc stand for Universal Product Code
        {
            try
            {
                var response = await _client.GetAsync($"/search/item/?upc={upc}");
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
        public async Task<string> AnalyzeNaturalLanguageAsync(string naturalLanguage)
        {
            try
            {
                var query = naturalLanguage;
                var jsonQuery = JsonSerializer.Serialize(query);
                var content = new StringContent(jsonQuery, null, "application/json");

                var response = await _client.PostAsync("natural/nutrients", content);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
