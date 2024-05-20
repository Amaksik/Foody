using FoodyUI.MyAccount;
using FoodyUI.Recognition;
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

namespace FoodyUI
{
    public class WelcomeForm : AutoCleanForm
    {
        private ButtonGrid _mButtons;

        public WelcomeForm()
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

            bf.AddButtonRow(new ButtonBase("Recognition", "recognition"), new ButtonBase("Account", "account"));

            bf.AddButtonRow(new ButtonBase("Back", "back"), new ButtonBase("Switch Keyboard", "switch"));

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

            if (e.Button.Value == "recognition")
            {
                var start = new Recognition.RouterForm();
                await NavigateTo(start);
            }
            else if (e.Button.Value == "account")
            {
                var start = new MyAccount.RouterForm();
                await NavigateTo(start);
            }
            else if (e.Button.Value == "back")
            {
                var start = new StartForm();
                await NavigateTo(start);
            }
            else if (e.Button.Value == "switch")
            {
                _mButtons.KeyboardType = _mButtons.KeyboardType switch
                {
                    EKeyboardType.ReplyKeyboard => EKeyboardType.InlineKeyBoard,
                    EKeyboardType.InlineKeyBoard => EKeyboardType.ReplyKeyboard,
                    _ => _mButtons.KeyboardType
                };
            }
            else
            {
                await Device.Send($"Button clicked with Text: {e.Button.Text} and Value {e.Button.Value}");
            }
        }
    }
}
