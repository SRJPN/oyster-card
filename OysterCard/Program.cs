using System.Diagnostics.CodeAnalysis;

namespace OysterCard
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var lines = RetreiveFileContent(args);

                var response = CommandProcessor.ProcessCommands(lines);

                PrintResponse(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void PrintResponse(IList<string> response)
        {
            response.ToList().ForEach(Console.WriteLine);
        }

        private static IEnumerable<string> RetreiveFileContent(string[] args)
        {
            var filePath = args[0];
            var lines = File.ReadLines(filePath);
            return lines;
        }
    }
}
