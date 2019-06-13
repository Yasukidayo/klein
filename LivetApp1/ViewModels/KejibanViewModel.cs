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

namespace LivetApp1.ViewModels
{
    public class kejibanViewModel : ViewModel
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

        public async void Initialize()
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
            ThanksCards = ThanksCards.OrderByDescending(x => x.CreatedDateTime).ToList();
        }

      
        }
}
