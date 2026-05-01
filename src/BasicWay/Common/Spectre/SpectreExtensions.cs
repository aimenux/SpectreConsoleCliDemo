using Spectre.Console;

namespace BasicWay.Common.Spectre;

public static class SpectreExtensions
{
    public static void RenderException<T>(this T exception) where T : Exception
    {
        const ExceptionFormats formats = ExceptionFormats.ShortenEverything;
        AnsiConsole.WriteLine();
        AnsiConsole.WriteException(exception, formats);
        AnsiConsole.WriteLine();
    }
}