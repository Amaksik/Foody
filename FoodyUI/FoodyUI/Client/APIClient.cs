using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FoodyUI.Client
{
    public class APIClient
    {
        private readonly HttpClient _client;

        public APIClient(string apiUri)
        {
            _client = new HttpClient();
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
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    content.Add(imageContent, "image", "image.jpg");

                    var response = await _client.PostAsync("image/segmentation/complete", content);
                    response.EnsureSuccessStatusCode(); // Throw on error response

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> AnalyzeBarcodeAsync(long upc)
        {
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Headers.ContentType.MediaType = "multipart/form-data";
                    var imageContent = new ByteArrayContent(new byte[5]);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    content.Add(imageContent, "image", "image.jpg");

                    var response = await _client.PostAsync("image/segmentation/complete", content);
                    response.EnsureSuccessStatusCode(); // Throw on error response

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<string> AnalyzeLanguageAsync(string language)
        {
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    content.Headers.ContentType.MediaType = "multipart/form-data";
                    var imageContent = new ByteArrayContent(new byte[1]);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    content.Add(imageContent, "image", "image.jpg");

                    var response = await _client.PostAsync("image/segmentation/complete", content);
                    response.EnsureSuccessStatusCode(); // Throw on error response

                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
