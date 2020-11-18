# BlazorWasmSample
## Code analysis
### C#
Using Microsoft.CodeAnalysis.FxCopAnalyzers and StyleCop.Analyzers nugets.
Ruleset is located in Solution directory/SolutionItems/CodeAnalysis.ruleset.
Following needs to be added to csprojs:
```
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
<CodeAnalysisRuleSet>$(SolutionDir)SolutionItems\CodeAnalysis.ruleset</CodeAnalysisRuleSet>
```
## Code behind
I find it more readable to have the HTML template and code separated.
So all components use code behind.
* code behind class needs to be partial
* to replace `@inject` use `[Inject]` on property

[MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-3.1#partial-class-support)

## I18n
There is Internationalization tab which allows you to change culture. The tab's content is translated (only this tab is translated)
and it displays current culture and time formatted according to current culture.

When the culture is changed it's stored in local storage under BlazorCulture key and the page reloads.
During startup the culture is read from local storage and sets `DefaultThreadCurrentCulture` and `DefaultThreadCurrentUICulture`.
[Blazored.LocalStorage](https://www.nuget.org/packages/Blazored.LocalStorage/) is used to access local storage.

Localization is supported by `IStringLocalizer` from [Microsoft.Extensions.Localization](https://www.nuget.org/packages/Microsoft.Extensions.Localization/).
The resources are in resx files under Resources folder.

[MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/globalization-localization?view=aspnetcore-3.1)

## Dependecy injection
Blazor supports DI. The registration is handled in `DependencyInjectionServiceCollectionExtensions`.

Non component classes (`InternationalizationService`) can use constructor injections but all comoponent classes has to use property injection with `[Inject]`.
The access modifier on the property doesnt matter (can be private).

[MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/fundamentals/dependency-injection?view=aspnetcore-3.1)

## Typesript/Javascript interop
There are some features WebAssembly does not support (popups, web storage, ...). So there definitely cases where you need to use javascript.
In those case I would recommend looking for some already existing wrapper - there is one even in this project ([Blazored.LocalStorage](https://www.nuget.org/packages/Blazored.LocalStorage/)).

In case you need to use javascript interop there is a Javascript interop tab with an example.

To use js interop in a component inject `IJSRuntime` and use it to load your js script using `JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/TypescriptInterop.js")`.
The resulting `IJSObjectReference` allows you to call javascript.

To use Typescript instead of javascript install [Microsoft.TypeScript.MSBuild](https://www.nuget.org/packages/Microsoft.TypeScript.MSBuild/) replace your script with typescript version.
During build it gets compiled to javascript which you can reference in `JSRuntime.InvokeAsync<IJSObjectReference>("import", "./scripts/TypescriptInterop.js")`.

[MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/call-javascript-from-dotnet?view=aspnetcore-3.1)

TODO: CSS  
TODO: testing  
TODO: logging  
TODO: unhandled exceptions  
TODO: unit & integration test runners   
TODO: configuration - environments   
TODO: HTTP client wrapper + error handling   
TODO: editor config  
TODO: Data tables   