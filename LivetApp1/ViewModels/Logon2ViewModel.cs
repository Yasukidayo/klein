using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using LivetApp1.Models;
using System.Windows;
namespace LivetApp1.ViewModels
{
    public class Logon2ViewModel : ViewModel
    {


        #region UserProperty
        private User _User;

        public User User
        {
            get
            { return _User; }
            set
            {
                if (_User == value)
                    return;
                _User = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.User = new User();
        }

        #region LogonCommand
        private ViewModelCommand _LogonCommand;

        public ViewModelCommand LogonCommand
        {
            get
            {
                if (_LogonCommand == null)
                {
                    _LogonCommand = new ViewModelCommand(Logon);
                }
                return _LogonCommand;
            }
        }

        public async void Logon()
        {
            User authorizedUser = await this.User.LogonAsync();
            System.Diagnostics.Debug.WriteLine("Logon");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            if (authorizedUser != null) // Logon 成功
            {
                try
                {
                    // MainWindow を非表示
                    window.Hide();
                    Home2ViewModel ViewModel = new Home2ViewModel();
                    var message = new TransitionMessage(typeof(Views.Home2), ViewModel, TransitionMode.Modal, "Logon");
                    Messenger.Raise(message);
                }
                finally
                {
                    // MainWindow を再表示
                    window.ShowDialog();
                }
            }
            else // Logon 失敗
            {
                System.Diagnostics.Debug.WriteLine("ログオンに失敗しました。");
            }

        }
        #endregion
        #region ShowHome2
        private ViewModelCommand _ShowHome2Command;

        public ViewModelCommand ShowHome2Command

        {
            get
            {
                if (_ShowHome2Command == null)
                {
                    _ShowHome2Command = new ViewModelCommand(ShowHome2);
                }
                return _ShowHome2Command;
            }
        }

        public void ShowHome2()
        {
            System.Diagnostics.Debug.WriteLine("ShowHome2");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                Home2ViewModel ViewModel = new Home2ViewModel();
                var message = new TransitionMessage(typeof(Views.Home2), ViewModel, TransitionMode.Modal, "ShowHome2");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
    }
}
