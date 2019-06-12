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
    public class JireiViewModel : ViewModel
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

        #region JireiProperty
        private List<ThanksCard> _Jirei;

        public List<ThanksCard> Jirei
        {
            get
            { return _Jirei; }
            set
            {
                if (_Jirei == value)
                    return;
                _Jirei = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            ThanksCard thanksCard = new ThanksCard();
            this.ThanksCards = await thanksCard.GetThanksCardsAsync();

          Jirei = ThanksCards.Where(x => x.Flag2 == true).ToList();


        }
        /*
        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;

        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
        {
            ThanksCard updatedThanksCard = await ThanksCard.PutThanksCardAsync(this.ThanksCard);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Edited"));
        }
        #endregion  */
    }
}
