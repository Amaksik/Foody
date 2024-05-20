using Foody.BLL.Interfaces.External;
using Foody.BLL.Models.DTO;
using Foody.BLL.Services.Clients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Foody.BLL.Services.External
{
    public class PhotoRecognitionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IRecognitionClient _recognitionClient;

        public PhotoRecognitionService(HttpClient httpClient, string baseUrl, IRecognitionClient recognitionClient)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = baseUrl;
            _recognitionClient = recognitionClient;
        }

        public async Task<string> GetCatalogItems()
        {
            var uri = _remoteServiceBaseUrl + "/recognize";

            var responseString = await _httpClient.GetStringAsync(uri);

            var catalog = JsonSerializer.Deserialize<string>(responseString);
            return catalog ?? "";
        }

        public async Task<RecognitionResult> Recognize(byte[] image)
        {
            var result = await _recognitionClient.AnalyzeImageAsync(image);

            var response = JsonSerializer.Deserialize<LogmealRecognitionResponseSimplified>(result);

            var nutritionalInfo = response.nutritional_info;

            var mostProbableResult = nutritionalInfo.totalNutrients;

            return new RecognitionResult(response.foodName[0], nutritionalInfo.calories, mostProbableResult.CHOCDF.quantity, mostProbableResult.FAT.quantity, mostProbableResult.PROCNT.quantity);
        }


    }
}
