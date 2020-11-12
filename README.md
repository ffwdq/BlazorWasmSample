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

### TODO: CSS
Use sass
do scoped css - need .net 5
https://github.com/dotnet/aspnetcore/issues/10170
https://daveabrock.com/2020/09/10/blazor-css-isolation

TODO: testing
TODO: js/typescript
TODO: logging
TODO: editor config
TODO: configuration - environments 
TODO: unit & integration test runners 
TODO: HTTP client wrapper + error handling 
TODO: Data tables 
TODO: unhandled exceptions