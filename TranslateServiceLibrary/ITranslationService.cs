using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateServiceLibrary
{
    public interface ITranslationService
    {
        string GetServiceInfo();
        Task<List<string>> TranslateAsync(List<string> texts, string toLanguage);
    }
}
