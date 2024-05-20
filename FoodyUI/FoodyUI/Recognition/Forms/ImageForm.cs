using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using TelegramBotBase.Args;
using TelegramBotBase.Base;
using TelegramBotBase.Controls.Hybrid;
using TelegramBotBase.Enums;
using TelegramBotBase.Form;

namespace FoodyUI.Recognition.Forms
{
    public class ImageForm : AutoCleanForm
    {
        
        public ImageForm()
        {
            DeleteMode = EDeleteMode.OnLeavingForm;
        }

        // Gets invoked during Navigation to this form
        public override async Task PreLoad(MessageResult message)
        {
            await this.Device.Send("Send me an image, please, to analyze the nutrition information");
        }

        // Gets invoked on every Message/Action/Data in this context
        public override async Task Load(MessageResult message)
        {
            await this.Device.DeleteMessage(message.MessageId);
            if (message.MessageType == MessageType.Text && message.MessageText == "/back")
            {
                var wf = new Recognition.RouterForm();
                await NavigateTo(wf);
            }
        }

        // Gets invoked on Data uploades by the user (of type Photo, Audio, Video, Contact, Location, Document)
        public override async Task SentData(DataResult data)
        {
            if (data != null && data.Type == MessageType.Photo)
            {
                await this.Device.Send("processing the image ...");
                Thread.Sleep(500);
                await this.Device.Send("Name: Oat porridge with strawberies the");
                await this.Device.Send("Nutrients: Calories - 450, carbs - 80, protein - 10, fat - 5");
                Thread.Sleep(2000);
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
