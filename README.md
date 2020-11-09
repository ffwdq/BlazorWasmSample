# BlazorWasmSample
## Code analysis
### C#
Using Microsoft.CodeAnalysis.FxCopAnalyzers and StyleCop.Analyzers nugets.
Ruleset is located in Solution directory/SolutionItems/CodeAnalysis.ruleset.
Following needs to be added to csprojs:
```
<TreatWarningsAsErrors>true</TreatWarningsAsErrors>
<CodeAnalysisRuleSet>$(SolutionDir)/SolutionItems/CodeAnalysis.ruleset</CodeAnalysisRuleSet>
```
## Code behind
I find it more readable to have the HTML template and code separated.
So all components use code behind.
* code behind class needs to be partial
* to replace ```@inject``` use [Inject] on property

[MSDN](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/?view=aspnetcore-3.1#partial-class-support)

### CSS TODO
Use sass
do scoped css - need .net 5
https://github.com/dotnet/aspnetcore/issues/10170
https://daveabrock.com/2020/09/10/blazor-css-isolation

TODO: testing
TODO: js/typescript
TODO: logging
static code analysis, editor config
configuration - environments 
dependency injection
SCSS, l10n, i18n, unified semantic logging 
unit & integration test runners 
HTTP client wrapper + error handling 
Data tables 
unhandled exceptions