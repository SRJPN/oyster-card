using System.Diagnostics.CodeAnalysis;
using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard
{
    [ExcludeFromCodeCoverage]
    class Program
    {
        static readonly IDictionary<string, ICommandHandler> handlers = new Dictionary<string, ICommandHandler> {
            {"RECHARGE", new RechargeHandler()},
            {"ENTRY", new StationEntryHandler()},
            {"EXIT", new StationExitHandler()},
            {"BALANCE", new BalanceCommandHandler()}
        };

        static void Main(string[] args)
        {
            try
            {
                var filePath = args[0];
                var response = new List<string>();
                var card = new Card(new Wallet());
                foreach (string line in File.ReadLines(filePath))
                {
                    var arguments = new List<string>(line.Split(" "));
                    string command = arguments[0];
                    var handler = GetHandler(command);
                    var result = handler.Execute(card, arguments.Skip(1).ToArray());
                    if (result != string.Empty)
                    {
                        response.Add(result.ToString());
                    }
                }

                response.ForEach(Console.WriteLine);
            }
            catch(Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        private static ICommandHandler GetHandler(string command)
        {
            if (!handlers.ContainsKey(command))
                throw new Exception("INVALID COMMAND PROVIDED");
            return handlers[command];
        }
    }
}
