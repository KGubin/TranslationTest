

namespace TranslateServiceLibrary
{
    public class TranslateService : ITranslationService
    {
        private readonly ITranslationCache _cache;

        public TranslateService(ITranslationCache cache)
        {
            _cache = cache;
        }

        public string GetServiceInfo()
        {
            return "Translate Service";
        }

        public async Task<List<string>> TranslateAsync(List<string> texts,  string toLanguage)
        {
            var translations = new List<string>();

            foreach (var text in texts)
            {
                if (!_cache.TryGetTranslation(text, out string translatedText))
                {
                    translatedText = SimulateTranslation(text, toLanguage);
                    _cache.SetTranslation(text, translatedText);
                }
                translations.Add(translatedText);
            }

            return await Task.FromResult(translations);
        }

        private string SimulateTranslation(string text, string toLanguage)
        {
                return $"[{toLanguage.ToUpper()}]: {text.ToUpper()}";
        }
    }
}