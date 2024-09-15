using TranslateServiceLibrary;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ITranslationCache, InMemoryTranslationCache>()
            .AddSingleton<ITranslationService, TranslateService>()
            .BuildServiceProvider();

        var translationService = serviceProvider.GetService<ITranslationService>();

        Console.WriteLine("Введите текст для перевода:");
        var text = Console.ReadLine();

        var translations = await translationService.TranslateAsync(new List<string> { text }, "ru");

        var translatedText = translations.First();

        Console.WriteLine($"Перевод: {translatedText}");
    }
}