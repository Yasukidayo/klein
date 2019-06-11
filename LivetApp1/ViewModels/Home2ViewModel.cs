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
    public class Home2ViewModel : ViewModel
    {
      
        public void Initialize()
        {
        }
        #region ShowSoushin
        private ViewModelCommand _ShowSoushinCommand;

        public ViewModelCommand ShowSoushinCommand

        {
            get
            {
                if (_ShowSoushinCommand == null)
                {
                    _ShowSoushinCommand = new ViewModelCommand(ShowSoushin);
                }
                return _ShowSoushinCommand;
            }
        }

        public void ShowSoushin()
        {
            System.Diagnostics.Debug.WriteLine("ShowSoushin");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                SoushinViewModel ViewModel = new SoushinViewModel();
                var message = new TransitionMessage(typeof(Views.Soushin), ViewModel, TransitionMode.Modal, "ShowSoushin");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowJirei
        private ViewModelCommand _ShowJireiCommand;

        public ViewModelCommand ShowJireiCommand

        {
            get
            {
                if (_ShowJireiCommand == null)
                {
                    _ShowJireiCommand = new ViewModelCommand(ShowJirei);
                }
                return _ShowJireiCommand;
            }
        }

        public void ShowJirei()
        {
            System.Diagnostics.Debug.WriteLine("ShowJirei");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                JireiViewModel ViewModel = new JireiViewModel();
                var message = new TransitionMessage(typeof(Views.jirei), ViewModel, TransitionMode.Modal, "ShowJirei");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowGyoumukaizen
        private ViewModelCommand _ShowgyoumukaizenCommand;

        public ViewModelCommand ShowgyoumukaizenCommand

        {
            get
            {
                if (_ShowgyoumukaizenCommand == null)
                {
                    _ShowgyoumukaizenCommand = new ViewModelCommand(Showgyoumukaizen);
                }
                return _ShowgyoumukaizenCommand;
            }
        }

        public void Showgyoumukaizen()
        {
            System.Diagnostics.Debug.WriteLine("Showgyoumukaizen");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                gyoumukaizenViewModel ViewModel = new gyoumukaizenViewModel();
                var message = new TransitionMessage(typeof(Views.gyoumukaizen), ViewModel, TransitionMode.Modal, "Showgyoumukaizen");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowTourokugamen
        private ViewModelCommand _ShowTourokugamenCommand;

        public ViewModelCommand ShowTourokugamenCommand

        {
            get
            {
                if (_ShowTourokugamenCommand == null)
                {
                    _ShowTourokugamenCommand = new ViewModelCommand(ShowTourokugamen);
                }
                return _ShowTourokugamenCommand;
            }
        }

        public void ShowTourokugamen()
        {
            System.Diagnostics.Debug.WriteLine("ShowTourokugamen");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                TourokugamenViewModel ViewModel = new TourokugamenViewModel();
                var message = new TransitionMessage(typeof(Views.tourokugamen), ViewModel, TransitionMode.Modal, "ShowTourokugamen");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowAddDepartment
        private ViewModelCommand _ShowAddDepCommand;

        public ViewModelCommand ShowAddDepCommand

        {
            get
            {
                if (_ShowAddDepCommand == null)
                {
                    _ShowAddDepCommand = new ViewModelCommand(ShowAddDep);
                }
                return _ShowAddDepCommand;
            }
        }

        public void ShowAddDep()
        {
            System.Diagnostics.Debug.WriteLine("ShowAddDep");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                AddDepartmentViewModel ViewModel = new AddDepartmentViewModel();
                var message = new TransitionMessage(typeof(Views.AddDepartment), ViewModel, TransitionMode.Modal, "ShowAddDep");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowSanshou
        private ViewModelCommand _ShowSanshouCommand;

        public ViewModelCommand ShowSanshouCommand


        {
            get
            {
                if (_ShowSanshouCommand == null)
                {
                    _ShowSanshouCommand = new ViewModelCommand(ShowSanshou);
                }
                return _ShowSanshouCommand;
            }
        }

        public void ShowSanshou()
        {
            System.Diagnostics.Debug.WriteLine("ShowSanshou");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                SanshouViewModel ViewModel = new SanshouViewModel();
                var message = new TransitionMessage(typeof(Views.Sanshou), ViewModel, TransitionMode.Modal, "ShowSanshou");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
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
    }
}
