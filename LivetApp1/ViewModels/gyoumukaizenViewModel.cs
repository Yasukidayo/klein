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
using System.Windows.Controls;

namespace LivetApp1.ViewModels
{
    public class gyoumukaizenViewModel : ViewModel
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

        #region GyoumuProperty
        private List<ThanksCard> _Gyoumu;

        public List<ThanksCard> Gyoumu
        {
            get
            { return _Gyoumu; }
            set
            {
                if (_Gyoumu == value)
                    return;
                _Gyoumu = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ThanksCardDeleteCommand
        private ListenerCommand<ThanksCard> _ThanksCardDeleteCommand;

        public ListenerCommand<ThanksCard> ThanksCardDeleteCommand
        {

            get
            {
                if (_ThanksCardDeleteCommand == null)
                {
                    _ThanksCardDeleteCommand = new ListenerCommand<ThanksCard>(ThanksCardDelete);
                }
                return _ThanksCardDeleteCommand;
            }
        }

        public async void ThanksCardDelete(ThanksCard ThanksCard)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + ThanksCard.Id);
            ThanksCard deletedThanksCard = await ThanksCard.DeleteThanksCardAsync(ThanksCard.Id);

            this.Initialize();
        }
        #endregion

        public async void Initialize()
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();
            Gyoumu = ThanksCards.Where(x => x.Flag1 == true
            ).OrderByDescending(x => x.CreatedDateTime
            ).ToList();
        }
    }
}
