using System.Diagnostics;
using static uci_library.Command;

namespace uci_library;

public class ChessEngine
{
    private string Path { get; set; } 
    
    private readonly EngineCommands _engineCommands;

    public ChessEngine(string path)
    {
        Path = path;
        var processStartInfo = new ProcessStartInfo(path)
        {
            UseShellExecute = false,
            RedirectStandardInput = true,
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };

        _engineCommands = new EngineCommands(processStartInfo);
    }

    public string Start()
    {
        return _engineCommands.Start();
    }

    public bool IsReady()
    {
        _engineCommands.SendCommand(Command.IsReady);
        return _engineCommands.ReadLastLine() == "readyok";
    }
}