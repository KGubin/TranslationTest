using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateServiceLibrary
{
    public interface ITranslationCache
    {
        bool TryGetTranslation(string text, out string translation); 
        void SetTranslation(string text, string translation);
    }
}
