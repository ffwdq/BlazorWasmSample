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
