namespace Foody.BLL.Interfaces.External
{
    public interface INutritionixClient
    {
        Task<string> AnalyzeBarcodeAsync(long upc);
        Task<string> AnalyzeNaturalLanguageAsync(string naturalLanguage);
    }
}