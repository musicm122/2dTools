using System.Collections.Generic;
using System.Linq;

namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public struct RuleResultSummary
    {
        public RuleResultSummary(List<RuleResult> results)
        {
            this.Results = results;
        }
        public List<RuleResult> Results;
        public List<RuleResult> Failures => FailureFilter(Results);
        public bool HasFailures => HasFailsPredicate(Results);

        private List<RuleResult> FailureFilter(List<RuleResult> results)
        {
            return results.Where(result => !result.HasPassed).ToList();
        }
        private bool HasFailsPredicate(List<RuleResult> results)
        {
            return Results.Any(result => !result.HasPassed);
        }
    }
}
