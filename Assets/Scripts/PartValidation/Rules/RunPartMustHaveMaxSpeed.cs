namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public class RunPartMustHaveMaxSpeed : BaseRule
    {
        public readonly string RuleMessage = "RunPart Should have Max Speed";
        protected RunPartMustHaveMaxSpeed()
        {
        }

        public override RuleResult EvaluateRule<RunPart>(RunPart val)
        {

            return new RuleResult("RunPart", RuleMessage, val.MaxSpeed != null);
        }
    }
}
