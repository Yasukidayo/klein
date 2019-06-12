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
    public class AddMessageViewModel : ViewModel
    {

        #region REsponsemessage変更通知プロパティ
        private Responsemessage _Responsemessage;

        public Responsemessage Responsemessage
        {
            get
            { return _Responsemessage; }
            set
            {
                if (_Responsemessage == value)
                    return;
                _Responsemessage = value;
                RaisePropertyChanged(nameof(Department));
            }
        }
        #endregion

        #region ResponsemessagesProperty
        private List<Responsemessage> _Responsemessages;

        public List<Responsemessage> Responsemessages
        {
            get
            { return _Responsemessages; }
            set
            {
                if (_Responsemessages == value)
                    return;
                _Responsemessages = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public async void Initialize()
        {
            this.Responsemessage = new Responsemessage();
            this.Responsemessages = await this.Responsemessage.GetResponsemessagesAsync();
        }

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
            Responsemessage createdResponsemessage = await Responsemessage.PostResponsemessageAsync(this.Responsemessage);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion
    }
}