using System;
using System.Threading;
using System.Threading.Tasks;
using BlazorWasmSample.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;

namespace BlazorWasmSample.Pages
{
    public partial class Internationalization : IDisposable
    {
        private Timer _timeTimer;

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        [Inject]
        private IInternationalizationService InternationalizationService { get; set; }

        [Inject]
        private IStringLocalizer<Internationalization> Localizer { get; set; }

        protected override void OnInitialized()
        {
            _timeTimer = new Timer(state => StateHasChanged(), null, 1000, 1000);

            base.OnInitialized();
        }

        private async Task CurrentCultureChanged(ChangeEventArgs e)
        {
            if (e.Value is string)
            {
                await InternationalizationService.SetCulture(e.Value as string).ConfigureAwait(true);
                NavigationManager.NavigateTo(NavigationManager.Uri, forceLoad: true);
            }
        }

        public void Dispose()
        {
            _timeTimer.Dispose();
        }
    }
}
