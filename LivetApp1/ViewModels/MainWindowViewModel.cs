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
using LivetApp1.Services;

namespace LivetApp1.ViewModels
{
     public class MainWindowViewModel : ViewModel
     {
        
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


        #region ThanksCardsProperty
        private List<ThanksCard> _ThanksCards;

        public List<ThanksCard> ThanksCards
        {
            get
            { return _ThanksCards; }
            set
            {
                if (_ThanksCards == value)
                    return;
                _ThanksCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ToThanksCardsAToProperty
        private List<ThanksCard> _ToThanksCards;

        public List<ThanksCard> ToThanksCards
        {
            get
            { return _ToThanksCards; }
            set
            {
                if (_ToThanksCards == value)
                    return;
                _ToThanksCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FromThanksCardsAToProperty
        private List<ThanksCard> _FromThanksCards;

        public List<ThanksCard> FromThanksCards
        {
            get
            { return _FromThanksCards; }
            set
            {
                if (_FromThanksCards == value)
                    return;
                _FromThanksCards = value;
                RaisePropertyChanged();
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

        public async void Initialize2()
        {
          
            IRestService service = new RestService();   // ThanksCard thanksCard = new ThanksCard();
            ThanksCards = await service.GetThanksCardsAsync();  // this.ThanksCards = await thanksCard.GetThanksCardsAsync();
             User AuthorizedUser = SessionService.Instance.AuthorizedUser;
          
          
            //ここでユーザーカードにログイン済みのユーザーのみにフィルタリングする。
            ToThanksCards = ThanksCards.Where(x =>
                                     x.ToId == AuthorizedUser.Id //ここでログイン済みのユーザーがもらったものを表示
                                        ).ToList();

            FromThanksCards = ThanksCards.Where(x =>
                                        x.FromId == AuthorizedUser.Id //ここでログイン済みのユーザーの送ったものを抽出                      
                                       ).ToList();

        }
    }
}
 


  