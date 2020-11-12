using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.JSInterop;

namespace BlazorWasmSample.Services
{
    public class InternationalizationService
    {
        private const string BlazorCultureKey = "BlazorCulture";

        public InternationalizationService(IJSRuntime jsRuntime, ILocalStorageService localStorageService)
        {
            JSRuntime = jsRuntime;
            LocalStorageService = localStorageService;
        }

        public static IEnumerable<CultureInfo> SupportedCultureInfos { get; } = new[] { new CultureInfo("en-US"), new CultureInfo("cs-CZ") };

        public IJSRuntime JSRuntime { get; set; }

        public ILocalStorageService LocalStorageService { get; set; }

        public CultureInfo CurrentCultureInfo => CultureInfo.CurrentCulture;

        public async Task Initialize()
        {
            var blazorCulture = await LocalStorageService.GetItemAsStringAsync(BlazorCultureKey).ConfigureAwait(true) ??
                               await JSRuntime.InvokeAsync<string>("getLanguage", Array.Empty<object>()).ConfigureAwait(true);

            var culture = new CultureInfo(blazorCulture);
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        public async Task SetCulture(string cultureName)
        {
            if (cultureName == CurrentCultureInfo.Name)
            {
                return;
            }

            var mewCulture = SupportedCultureInfos.Where(x => x.Name == cultureName).FirstOrDefault() ?? SupportedCultureInfos.First();
            await LocalStorageService.SetItemAsync(BlazorCultureKey, cultureName).ConfigureAwait(true);
            CultureInfo.CurrentCulture = mewCulture;
        }
    }
}
