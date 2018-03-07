using System;
using System.Collections;
using System.Runtime.Serialization;

public class ImportJsonPartException : Exception
{
    public ImportJsonPartException()
    {
    }

    public ImportJsonPartException(string message) : base(message)
    {
    }

    public ImportJsonPartException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected ImportJsonPartException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
