using Microsoft.AspNetCore.Mvc;
using TranslateServiceLibrary;

namespace TranslationServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationController : ControllerBase
    {
        private readonly ITranslationService _translationService;

        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        [HttpPost("translate")]
        public async Task<IActionResult> Translate([FromBody] TranslateRequest request)
        {
            var translations = await _translationService.TranslateAsync(request.Texts, request.ToLanguage);
            return Ok(new TranslateResponse { Translations = translations });
        }

        [HttpGet("info")]
        public IActionResult GetServiceInfo()
        {
            return Ok(new ServiceInfo { Info = _translationService.GetServiceInfo() });
        }
    }

    public class TranslateRequest
    {
        public List<string> Texts { get; set; }
        public string ToLanguage { get; set; }
    }

    public class TranslateResponse
    {
        public List<string> Translations { get; set; }
    }

    public class ServiceInfo
    {
        public string Info { get; set; }
    }
}
