using Scripts.Importer.Parts;
using System;

namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public class RunPartMustHaveMaxSpeed : BaseRule
    {
        public readonly string RuleMessage = "RunPart Should have Max Speed";
        public RunPart Target { get; private set; }

        RunPartMustHaveMaxSpeed(RunPart target)
        {
            Target = target;
        }

        public override RuleResult RunRule(object val)
        {
            //return new RuleResult("RunPart", RuleMessage, val.MaxSpeed != null);
            throw new NotImplementedException();
        }
    }
}
