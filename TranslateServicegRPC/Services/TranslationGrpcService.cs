using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System.Transactions;
using TranslateServicegRPC;
using TranslateServiceLibrary;

namespace TranslateServicegRPC.Services
{
    public class TranslationGrpcService : Translation.TranslationBase
    {
        private readonly ITranslationService _translationService;

        public TranslationGrpcService(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        public override async Task<TranslateResponse> Translate(TranslateRequest request, ServerCallContext context)
        {
            var translations = await _translationService.TranslateAsync(request.Texts.ToList(), request.ToLanguage);
            var response = new TranslateResponse();
            response.Translations.AddRange(translations);
            return response;
        }

        public override Task<ServiceInfo> GetServiceInfo(Empty request, ServerCallContext context)
        {
            return Task.FromResult(new ServiceInfo { Info = _translationService.GetServiceInfo() });
        }
    }
}
