using TelegramWebAppDataValidator;

namespace TelegramMiniAppHashChecker.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var raw = """INSERT_QUERY_FROM_TELEGRAM""";
            var token = "YOUR_BOT_TOKEN";
            var validated = Validator.Validate(raw, token);
            Console.WriteLine(validated);
        }
    }
}
