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
            System.Diagnostics.Debug.WriteLine("ShowLogon");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                LogonViewModel ViewModel = new LogonViewModel();
                var message = new TransitionMessage(typeof(Views.Logon), ViewModel, TransitionMode.Modal, "Authorized");
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