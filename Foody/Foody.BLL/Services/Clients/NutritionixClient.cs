using Foody.BLL.Interfaces.External;
using Foody.BLL.Models.DTO;
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

        public async Task<IEnumerable<NutrionixFood>> AnalyzeBarcodeAsync(string upc) //upc stand for Universal Product Code
        {
            //016000139626
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, $"https://trackapi.nutritionix.com/v2/search/item/?upc={upc}");
                var response = await _client.SendAsync(request);

                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<NutrionixDTO>(content);
                return result.foods;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<NutrionixFood>> AnalyzeNaturalLanguageAsync(string naturalLanguage)
        {
            try
            {
                var queryObject = new { query = naturalLanguage };
                var requestBody = JsonSerializer.Serialize(queryObject);
                var content = new StringContent(requestBody, null, "application/json");

                var response = await _client.PostAsync("natural/nutrients", content);
                response.EnsureSuccessStatusCode();

                var result = JsonSerializer.Deserialize<NutrionixDTO>(await response.Content.ReadAsStringAsync());

                return result.foods;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
