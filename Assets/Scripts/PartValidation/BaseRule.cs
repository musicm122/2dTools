namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public abstract class BaseRule
    {
        public abstract RuleResult EvaluateRule<T>();

    }
}
