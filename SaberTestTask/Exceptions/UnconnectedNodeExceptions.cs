using System.Runtime.Serialization;

namespace SaberTestTask.Exceptions;

public class UnconnectedNodeExceptions : SerializationException
{
    public UnconnectedNodeExceptions(string? message) : base(message)
    {
    }
}