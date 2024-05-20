using FoodyUI.Recognition.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelegramBotBase.Args;
using TelegramBotBase.Base;
using TelegramBotBase.Controls.Hybrid;
using TelegramBotBase.Enums;
using TelegramBotBase.Form;

namespace FoodyUI.Recognition
{
    public class RouterForm : AutoCleanForm
    {
        private ButtonGrid _mButtons;

        public RouterForm()
        {
            DeleteMode = EDeleteMode.OnLeavingForm;

            Init += ButtonGridForm_Init;
        }

        private Task ButtonGridForm_Init(object sender, InitEventArgs e)
        {
            _mButtons = new ButtonGrid
            {
                KeyboardType = EKeyboardType.ReplyKeyboard
            };

            var bf = new ButtonForm();

            bf.AddButtonRow(new ButtonBase("Image", "b1"), new ButtonBase("Barcode", "b2"), new ButtonBase("Language", "b3"));

            bf.AddButtonRow(new ButtonBase("Back", "back"));

            _mButtons.DataSource.ButtonForm = bf;

            _mButtons.ButtonClicked += Bg_ButtonClicked;

            AddControl(_mButtons);
            return Task.CompletedTask;
        }

        private async Task Bg_ButtonClicked(object sender, ButtonClickedEventArgs e)
        {
            if (e.Button == null)
            {
                return;
            }
            else if (e.Button.Value == "b1")
            {
                var form = new ImageForm();
                await NavigateTo(form);
            }
            else if (e.Button.Value == "b2")
            {
                var form = new BarcodeForm();
                await NavigateTo(form);
            }
            else if (e.Button.Value == "b3")
            {
                var form = new NaturalLanguageForm();
                await NavigateTo(form);
            }
            else if(e.Button.Value == "back")
            {
                var wf = new WelcomeForm();
                await NavigateTo(wf);
            }
            else
            {
                await Device.Send($"Button clicked with Text: {e.Button.Text} and Value {e.Button.Value}");
            }
        }
    }
}
