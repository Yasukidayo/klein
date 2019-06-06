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
        private ViewModelCommand _Logon2Command;

        public ViewModelCommand Logon2Command
        {
            get
            {
                if (_Logon2Command == null)
                {
                    _Logon2Command = new ViewModelCommand(Logon2);
                }
                return _Logon2Command;
            }
        }

        public async void Logon2()
        {
            User authorizedUser2 = await this.User.LogonAsync2();
            System.Diagnostics.Debug.WriteLine("Logon2");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            if (authorizedUser2 != null) // Logon 成功
            {
                try
                {
                    
                    window.Hide();
                    Home2ViewModel ViewModel = new Home2ViewModel();
                    var message = new TransitionMessage(typeof(Views.Home2), ViewModel, TransitionMode.Modal, "Logon2");
                    Messenger.Raise(message);
                }
                finally
                {
                    
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
        #region ShowLogout
        private ViewModelCommand _ShowLogoutCommand;

        public ViewModelCommand ShowLogoutCommand

        {
            get
            {
                if (_ShowLogoutCommand == null)
                {
                    _ShowLogoutCommand = new ViewModelCommand(ShowLogout);
                }
                return _ShowLogoutCommand;
            }
        }
        public void ShowLogout()
        {
            System.Diagnostics.Debug.WriteLine("ShowLogout");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            try
            {
                // MainWindow を非表示
                window.Hide();
                LogonViewModel ViewModel = new LogonViewModel();
                var message = new TransitionMessage(typeof(Views.Logon), ViewModel, TransitionMode.Modal, "ShowLogout");
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
