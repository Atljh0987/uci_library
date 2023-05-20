using System.Diagnostics;
using uci_library.exceptions;

namespace uci_library;

public class EngineCommands
{
    private readonly Process _process = new();
    private readonly AutoResetEvent _autoResetEvent = new(false);
    private readonly EngineMessages _messages = new();
    public EngineCommands(ProcessStartInfo processStartInfo)
    {
        _process.StartInfo = processStartInfo;
        _process.OutputDataReceived += OnOutputDataReceived;
    }

    private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
    {
        if (e.Data == null) return;
        _messages.Add(e.Data);
        _autoResetEvent.Set();
        _autoResetEvent.Reset();
    }

    public string Start()
    {
        if (!_process.Start()) throw new EngineStartException();
        
        _process.BeginOutputReadLine();
        _autoResetEvent.WaitOne();
        return _messages.GetLastMessage();
    }

    public void SendCommand(string command)
    {
        _process.StandardInput.WriteLine(command);
        _process.StandardInput.Flush();
        _autoResetEvent.WaitOne();
    }

    public string ReadLastLine() => _messages.GetLastMessage();
}