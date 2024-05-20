using TelegramBotBase.Builder;
using TelegramBotBase.Commands;

namespace FoodyUI
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            var bot = BotBaseBuilder
                    .Create()
                    .WithAPIKey("") // do not store your API key as plain text in project sources
                    .DefaultMessageLoop()
                    .WithStartForm<StartForm>()
                    .NoProxy()
                    .CustomCommands(a =>
                    {
                        a.Start("Starts the bot");
                        a.AddGroupCommand( "navigation", "Go to main navigation page");
                    })
                    .NoSerialization()
                    .UseEnglish()
                    .UseSingleThread()
                    .Build();

            // Upload bot commands to BotFather
            await bot.UploadBotCommands();

            // Start your Bot
            await bot.Start();

            while (true)
            {
                Thread.Sleep(10000);
                Console.Out.WriteLine("10s passed");
            }
        }
    }
}