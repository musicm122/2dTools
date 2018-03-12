using System;
using Scripts.Importer.Parts;

namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public abstract class BaseRule
    {
        public abstract RuleResult RunRule(object val);
    }
}
