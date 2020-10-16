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

TODO: testing
TODO: js/typescript
TODO: logging
TODO: scss