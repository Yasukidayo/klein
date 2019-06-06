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
using LivetApp1.Services;

namespace LivetApp1.ViewModels
{
    public class RankingViewModel : ViewModel
    {

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

        #region CountsProperty
        private List<ThanksCard> _Counts;

        public List<ThanksCard> Counts
        {
            get
            { return _Counts; }
            set
            {
                if (_Counts == value)
                    return;
                _Counts = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            IRestService service = new RestService();   // ThanksCard thanksCard = new ThanksCard();
            ThanksCards = await service.GetThanksCardsAsync();
            User AuthorizedUser = SessionService.Instance.AuthorizedUser;

          //  Counts = ThanksCards.Where(x => x.ToId == AuthorizedUser.Id).ToList();
        }
    }
}
