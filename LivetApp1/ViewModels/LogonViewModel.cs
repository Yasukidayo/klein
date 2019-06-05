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
using LivetApp1.Services;

namespace LivetApp1.ViewModels
{
    public class LogonViewModel : ViewModel
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

            if (authorizedUser != null) // Logon 成功
            {
                SessionService.Instance.IsAuthorized = true;
                SessionService.Instance.AuthorizedUser = authorizedUser;
                Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Authorized"));
            }
            else // Logon 失敗
            {
                System.Diagnostics.Debug.WriteLine("ログオンに失敗しました。");
            }


        }
        #endregion

        #region ShowLogon2
        private ViewModelCommand _ShowLogon2Command;

        public ViewModelCommand ShowLogon2Command

        {
            get
            {
                if (_ShowLogon2Command == null)
                {
                    _ShowLogon2Command = new ViewModelCommand(ShowLogon2);
                }
                return _ShowLogon2Command;
            }
        }

        public void ShowLogon2()
        {
            System.Diagnostics.Debug.WriteLine("ShowLogon2");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                Logon2ViewModel ViewModel = new Logon2ViewModel();
                var message = new TransitionMessage(typeof(Views.Logon2), ViewModel, TransitionMode.Modal, "ShowLogon2");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }

        #endregion
        #region ShowNew
        private ViewModelCommand _ShowNewCommand;

        public ViewModelCommand ShowNewCommand

        {
            get
            {
                if (_ShowNewCommand == null)
                {
                    _ShowNewCommand = new ViewModelCommand(ShowNew);
                }
                return _ShowNewCommand;
            }
        }

        public void ShowNew()
        {
            System.Diagnostics.Debug.WriteLine("ShowNew");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                NewViewModel ViewModel = new NewViewModel();
                var message = new TransitionMessage(typeof(Views.New), ViewModel, TransitionMode.Modal, "ShowNew");
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