using Foody.BLL.Interfaces.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Foody.BLL.Services.Clients
{
    public class FoodvisorApiClient : IRecognitionClient
    {
        private readonly HttpClient _client;

        public FoodvisorApiClient(string apiKey, string apiUri)
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Api-Key", apiKey);
            _client.BaseAddress = new Uri(apiUri);
        }

        public async Task<string> AnalyzeImageAsync(byte[] imageData)
        {
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Headers.ContentType.MediaType = "multipart/form-data";
                    var imageContent = new ByteArrayContent(imageData);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpg"); // Or "image/png" if applicable
                    content.Add(imageContent, "image", "image.jpg");

                    using (var response = await _client.PostAsync("analysis/", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            return await response.Content.ReadAsStringAsync();
                        }
                        else
                        {
                            // Handle error responses here
                            return $"Error: {response.StatusCode}";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exception here
                return $"Error: {ex.Message}";
            }
        }
    }
}
