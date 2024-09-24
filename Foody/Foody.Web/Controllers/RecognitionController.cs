using Foody.BLL.Interfaces.External;
using Foody.BLL.Services.Clients;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Foody.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecognitionController : ControllerBase
    {
        private readonly IRecognitionClient _recognitionClient;
        private readonly INutritionixClient _nutritionixClient;

        public RecognitionController(IRecognitionClient foodvisorApiClient, INutritionixClient nutritionixClient)
        {
            _recognitionClient = foodvisorApiClient;
            _nutritionixClient = nutritionixClient;
        }

        [HttpPost("/image")]
        public async Task<IActionResult> RecognizeImage([FromForm] FileUploadViewModel model)
        {
            try
            {
                if (model.ImageFile == null || model.ImageFile.Length == 0)
                {
                    //"No image file uploaded."
                    return new BadRequestResult();
                }

                using (var memoryStream = new MemoryStream())
                {
                    await model.ImageFile.CopyToAsync(memoryStream);
                    var imageData = memoryStream.ToArray();

                    var result = await _recognitionClient.AnalyzeImageAsync(imageData);
                    return new OkObjectResult(result);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/barcode/{upc}")]
        public async Task<IActionResult> RecognizeBarcode(string upc)
        {
            try
            {
                if (string.IsNullOrEmpty(upc))
                {
                    //"No barcode provided"
                    return new BadRequestResult();
                }

                var result = await _nutritionixClient.AnalyzeBarcodeAsync(upc);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("/language")]
        public async Task<IActionResult> RecognizeLanguage([FromBody] string language)
        {
            try
            {
                if (string.IsNullOrEmpty(language))
                {
                    //"No text provided"
                    return new BadRequestResult();
                }

                var result = await _nutritionixClient.AnalyzeNaturalLanguageAsync(language);
                return new OkObjectResult(JsonSerializer.Serialize(result));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

    public class FileUploadViewModel
    {
        public IFormFile ImageFile { get; set; }
    }
}
