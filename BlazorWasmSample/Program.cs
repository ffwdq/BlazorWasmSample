using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using BlazorWasmSample.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace BlazorWasmSample
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddSingleton<InternationalizationService, InternationalizationService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddLocalization(opt => opt.ResourcesPath = "Resources");
            var host = builder.Build();

            var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
            var localStorageService = host.Services.GetRequiredService<ILocalStorageService>();
            var i18nService = host.Services.GetRequiredService<InternationalizationService>();
            i18nService.JSRuntime = jsRuntime;
            i18nService.LocalStorageService = localStorageService;
            await i18nService.Initialize().ConfigureAwait(true);

            await host.RunAsync().ConfigureAwait(false);
        }
    }
}
