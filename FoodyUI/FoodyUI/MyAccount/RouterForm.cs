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

namespace FoodyUI.MyAccount
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

            bf.AddButtonRow(new ButtonBase("Add Meal", "b1"), new ButtonBase("Registration", "b2"), new ButtonBase("Statistics", "b3"));

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

            if (e.Button.Value == "back")
            {
                var wf = new WelcomeForm();
                await NavigateTo(wf);
            }
            else
            {
                await Device.Send($"Button clicked with Text: {e.Button.Text} but not implemented");
            }
        }
    }
}
