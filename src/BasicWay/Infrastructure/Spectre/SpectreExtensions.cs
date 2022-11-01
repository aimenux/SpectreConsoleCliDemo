using Spectre.Console;

namespace BasicWay.Infrastructure.Spectre
{
    public static class SpectreExtensions
    {
        public static void RenderException<T>(this T exception) where T : Exception
        {
            const ExceptionFormats formats = ExceptionFormats.ShortenTypes
                                             | ExceptionFormats.ShortenPaths
                                             | ExceptionFormats.ShortenMethods;

            AnsiConsole.WriteLine();
            AnsiConsole.WriteException(exception, formats);
            AnsiConsole.WriteLine();
        }
    }
}
