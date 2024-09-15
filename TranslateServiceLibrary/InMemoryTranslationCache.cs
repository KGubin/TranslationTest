using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TranslateServiceLibrary
{
    public class InMemoryTranslationCache: ITranslationCache
    {
        private readonly Dictionary<string, string> _cache = new Dictionary<string, string>();

        public bool TryGetTranslation(string text, out string translation)
        {
            return _cache.TryGetValue(text, out translation);
        }

        public void SetTranslation(string text, string translation)
        {
            _cache[text] = translation;
        }
    }
}
