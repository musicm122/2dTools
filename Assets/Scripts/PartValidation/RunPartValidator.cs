using System;
namespace AssemblyCSharp.Assets.Scripts.PartValidation
{
    public class RunPartValidator
    {
        public RunPartValidator()
        {
        }
    }

    public class PartValidator
    {
    }

    public abstract class ValidationAttribute : System.Attribute
    {
        public string Message { get; set; }
        public abstract bool IsValid(object item);
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class NotNullOrEmptyAttribute : ValidationAttribute
    {

        public NotNullOrEmptyAttribute(string message)
        {
            Message = message;
        }

        public override bool IsValid(object item)
        {
            if (String.IsNullOrEmpty((string)item))
                return false;

            return true;
        }
    }
}
