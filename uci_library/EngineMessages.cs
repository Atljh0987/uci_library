namespace uci_library.exceptions;

public class EngineMessages
{
    private readonly List<string> _messages = new();

    public void Add(string? message)
    {
        if (message != null)
        {
            _messages.Add(message);
        }
    }

    public string GetLastMessage() => _messages[^1];
}