namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public struct RuleResult
    {
        public RuleResult(string targetName, string message, bool hasPassed)
        {
            this.TargetName = targetName;
            this.Message = message;
            this.HasPassed = hasPassed;
        }
        public string TargetName;
        public string Message;
        public bool HasPassed;
    }
}
