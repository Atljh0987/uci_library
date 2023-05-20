using System.Runtime.Serialization;

namespace uci_library.exceptions;

public class EngineStartException : Exception
{
    public EngineStartException()
    {
    }

    protected EngineStartException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public EngineStartException(string? message) : base(message)
    {
    }

    public EngineStartException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}