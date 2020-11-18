using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorWasmSample.Pages
{
    public partial class JavascriptInterop : IAsyncDisposable
    {
        private string _userMessage;
        private IJSObjectReference _typescriptModule;

        [Inject]
        private IJSRuntime JSRuntime { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _typescriptModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/TypescriptInterop.js").ConfigureAwait(true);
        }

        private async Task OnClick()
        {
            _userMessage = await _typescriptModule.InvokeAsync<string>("TypescriptInteropExample.TypescriptInterop.showPrompt", "Hello from javascript.").ConfigureAwait(true);
        }

        public ValueTask DisposeAsync()
        {
            return _typescriptModule.DisposeAsync();
        }
    }
}
