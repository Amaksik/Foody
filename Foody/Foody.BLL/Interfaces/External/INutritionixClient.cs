using Foody.BLL.Models.DTO;

namespace Foody.BLL.Interfaces.External
{
    public interface INutritionixClient
    {
        Task<IEnumerable<NutrionixFood>> AnalyzeBarcodeAsync(string upc);
        Task<IEnumerable<NutrionixFood>> AnalyzeNaturalLanguageAsync(string naturalLanguage);
    }
}