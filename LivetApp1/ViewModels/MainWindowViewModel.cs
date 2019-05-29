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
using LivetApp1.Views;
using System.Windows.Controls;

namespace LivetApp1.ViewModels
{
     public class MainWindowViewModel : ViewModel
     {
         #region MyMessageProperty




         private string _MyMessage; //プロパティ

         public string MyMessage
         {
             get
             { return _MyMessage; }
             set
             {
                 if (_MyMessage == value)
                     return;
                 _MyMessage = value;
                 RaisePropertyChanged(); //変更通知。mymessageが変更されたことを知らせる。この場合はviewに知らせる.
                 System.Diagnostics.Debug.WriteLine("MyMessage: " + this.MyMessage); //動作確認用。本来はこの行は必要ありません。

             }
         }
         #endregion
         #region MyDate
         private DateTime _MyDate;

         public DateTime MyDate
         {
             get
             { return _MyDate; }
             set
             {
                 if (_MyDate == value)
                     return;
                 _MyDate = value;
                 RaisePropertyChanged();
             }
         }

         #endregion
         #region Testcommand
         private ViewModelCommand _TestCommand;

         public ViewModelCommand TestCommand
         {
             get
             {
                 if (_TestCommand == null)
                 {
                     _TestCommand = new ViewModelCommand(Test);
                 }
                 return _TestCommand;
             }
         }

         public void Test()
         {
             System.Diagnostics.Debug.WriteLine("TestCommand が呼ばれました。");
         }

         #endregion
         #region Test2command
         private ListenerCommand<string> _Test2Command;

         public ListenerCommand<string> Test2Command
         {
             get
             {
                 if (_Test2Command == null)
                 {
                     _Test2Command = new ListenerCommand<string>(Test2);
                 }
                 return _Test2Command;
             }
         }

         public void Test2(string parameter)
         {
             System.Diagnostics.Debug.WriteLine("Test2Command が呼ばれました。パラメータは「" + parameter + "」です。");
         }

         #endregion

         public void Initialize()
         {
             var message = new TransitionMessage(typeof(Views.Logon), new LogonViewModel(), TransitionMode.Modal, "ShowLogon");
             Messenger.Raise(message);
         }

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
        #region ShainList
        private ViewModelCommand _ShainListCommand;

        public ViewModelCommand ShainListCommand

        {
            get
            {
                if (_ShainListCommand == null)
                {
                    _ShainListCommand = new ViewModelCommand(ShainList);
                }
                return _ShainListCommand;
            }
        }

        public void ShainList()
        {
            System.Diagnostics.Debug.WriteLine("ShowShainList");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                ShainViewModel ViewModel = new ShainViewModel();
                var message = new TransitionMessage(typeof(Views.Shain), ViewModel, TransitionMode.Modal, "ShowShainList");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowRankiing
        private ViewModelCommand _ShowRankingCommand;

        public ViewModelCommand ShowRankingCommand

        {
            get
            {
                if (_ShowRankingCommand == null)
                {
                    _ShowRankingCommand = new ViewModelCommand(ShowRanking);
                }
                return _ShowRankingCommand;
            }
        }

        public void ShowRanking()
        {
            System.Diagnostics.Debug.WriteLine("ShowRanking");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                RankingViewModel ViewModel = new RankingViewModel();
                var message = new TransitionMessage(typeof(Views.Ranking), ViewModel, TransitionMode.Modal, "ShowRanking");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
        #region ShowHelp
        private ViewModelCommand _ShowHelpCommand;

        public ViewModelCommand ShowHelpCommand

        {
            get
            {
                if (_ShowHelpCommand == null)
                {
                    _ShowHelpCommand = new ViewModelCommand(ShowHelp);
                }
                return _ShowHelpCommand;
            }
        }

        public void ShowHelp()
        {
            System.Diagnostics.Debug.WriteLine("ShowHelp");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                HelpViewModel ViewModel = new HelpViewModel();
                var message = new TransitionMessage(typeof(Views.Help), ViewModel, TransitionMode.Modal, "ShowHelp");
                Messenger.Raise(message);
            }
            finally
            {
                // MainWindow を再表示
                window.ShowDialog();
            }
        }
        #endregion
       
        #region ShowKejiban
        private ViewModelCommand _ShowKejibanCommand;

        public ViewModelCommand ShowKejibanCommand

        {
            get
            {
                if (_ShowKejibanCommand == null)
                {
                    _ShowKejibanCommand = new ViewModelCommand(ShowKejiban);
                }
                return _ShowKejibanCommand;
            }
        }

        public void ShowKejiban()
        {
            System.Diagnostics.Debug.WriteLine("ShowKejiban");
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);

            try
            {
                // MainWindow を非表示
                window.Hide();
                kejibanViewModel ViewModel = new kejibanViewModel();
                var message = new TransitionMessage(typeof(Views.kejiban), ViewModel, TransitionMode.Modal, "ShowKejiban");
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
 


  