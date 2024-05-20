using Telegram.Bot.Types.Enums;
using TelegramBotBase.Base;
using TelegramBotBase.Form;

namespace FoodyUI
{
    public class StartForm : FormBase
    {
        // Gets invoked during Navigation to this form
        public override async Task PreLoad(MessageResult message)
        {

        }

        // Gets invoked on every Message/Action/Data in this context
        public override async Task Load(MessageResult message)
        {
            await this.Device.DeleteMessage(message.MessageId);
            if (message.MessageType == MessageType.Text && message.MessageText == "/start")
            {
                await this.Device.Send("Hello there 👋");
                await this.Device.Send("I`m your personal asistant for healthy lifestyle!");
                await this.Device.Send("Here is a small guide for you to get started!");
                await this.Device.Send("https://telegra.ph/How-many-calories-should-I-eat-in-a-day-04-15");

                var wf = new WelcomeForm();
                await NavigateTo(wf);
            }

        }

        // Gets invoked on edited messages
        public override async Task Edited(MessageResult message)
        {
        }

        // Gets invoked on Button clicks
        public override async Task Action(MessageResult message)
        {
        }

        // Gets invoked on Data uploades by the user (of type Photo, Audio, Video, Contact, Location, Document)
        public override async Task SentData(DataResult data)
        {
            if (data != null && data.Type == MessageType.Photo)
            {
                await this.Device.Send("processing the image ...");
                var wf = new WelcomeForm();
                await NavigateTo(wf);
            }
            else
            {
                await this.Device.Send($"Unfortunately, I do not work with {data?.Type} files");
            }
        }

        //Gets invoked on every Message/Action/Data to render Design or Response 
        public override async Task Render(MessageResult message)
        {
        }
    }
}
