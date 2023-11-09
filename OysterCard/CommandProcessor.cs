using OysterCard.handlers;
using OysterCard.models;

namespace OysterCard
{
    public class CommandProcessor
    {
        private static readonly IDictionary<string, ICommandHandler> handlers = new Dictionary<string, ICommandHandler> {
            {"RECHARGE", new RechargeHandler()},
            {"ENTRY", new StationEntryHandler()},
            {"EXIT", new StationExitHandler()},
            {"BALANCE", new BalanceCommandHandler()}
        };
        public static IList<string> ProcessCommands(IEnumerable<string> lines)
        {
            var response = new List<string>();
            var card = new Card(new Wallet());
            foreach (string line in lines)
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

            return response;
        }

        private static ICommandHandler GetHandler(string command)
        {
            if (!handlers.ContainsKey(command))
                throw new Exception($"INVALID COMMAND PROVIDED: {command}");
            return handlers[command];
        }
    }
}