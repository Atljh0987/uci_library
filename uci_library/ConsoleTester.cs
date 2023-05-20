namespace uci_library;

public class ConsoleTester
{
    public static void main()
    {
        var chessEngine = new ChessEngine("C:\\Users\\Admin\\MyProjects\\uci_library\\test_engines\\Stockfish_15.exe");
        Console.WriteLine(chessEngine.Start());
        Console.WriteLine(chessEngine.IsReady());
    }
}