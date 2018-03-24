using System.Collections.Generic;

namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public interface IRuleResultSummary
    {
        List<RuleResult> Failures { get; }
        bool HasFailures { get; }
    }
}