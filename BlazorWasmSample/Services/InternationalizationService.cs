using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace BlazorWasmSample.Services
{
    public class InternationalizationService : IInternationalizationService
    {
        private const string _blazorCultureKey = "BlazorCulture";

        private readonly IJSRuntime _jsRuntime;

        private readonly ILocalStorageService _localStorageService;

        public InternationalizationService(IJSRuntime jsRuntime, ILocalStorageService localStorageService)
        {
            _jsRuntime = jsRuntime;
            _localStorageService = localStorageService;
        }

        public IEnumerable<CultureInfo> SupportedCultureInfos { get; } = new[] { new CultureInfo("en-US"), new CultureInfo("cs-CZ") };

        public CultureInfo CurrentCultureInfo => CultureInfo.CurrentCulture;

        public async Task Initialize()
        {
            var blazorCulture = await _localStorageService.GetItemAsStringAsync(_blazorCultureKey).ConfigureAwait(true);
            if (blazorCulture == null)
            {
                await using (var jsModule = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", new[] { "./scripts/scripts.js" }).ConfigureAwait(true))
                {
                    blazorCulture = await jsModule.InvokeAsync<string>("getBrowserLanguage", Array.Empty<object>()).ConfigureAwait(true);
                    await SetCultureInternal(blazorCulture);
                }
            }

            var culture = GetCulture(blazorCulture);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        public async Task SetCulture(string cultureName)
        {
            if (cultureName == CurrentCultureInfo.Name)
            {
                return;
            }

            await SetCultureInternal(cultureName);
        }

        private async Task SetCultureInternal(string cultureName)
        {
            var newCulture = GetCulture(cultureName);
            await _localStorageService.SetItemAsync(_blazorCultureKey, newCulture.Name).ConfigureAwait(true);
            CultureInfo.CurrentCulture = newCulture;
        }

        private CultureInfo GetCulture(string name)
        {
            return SupportedCultureInfos.Where(x => x.Name == name).FirstOrDefault() ?? SupportedCultureInfos.First();
        }
    }
}
