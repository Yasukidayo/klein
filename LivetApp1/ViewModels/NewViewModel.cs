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
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using LivetApp1.Services;

namespace LivetApp1.ViewModels
{
    public class NewViewModel : ViewModel
    {
        
      

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;

        public ThanksCard ThanksCard
        {
            get
            { return _ThanksCard; }
            set
            {
                if (_ThanksCard == value)
                    return;
                _ThanksCard = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region UsersProperty
        private List<User> _User;

        public List<User> User
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

        #region UsersProperty
        private List<User> _FromUser;

        public List<User> FromUser
        {
            get
            { return _FromUser; }
            set
            {
                if (_FromUser == value)
                    return;
                _FromUser = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        #region DepartmentsProperty
        private List<Department> _Department;

        public List<Department> Department
        {
            get
            { return _Department; }
            set
            {
                if (_Department == value)
                    return;
                _Department = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public async void Initialize()
        {
            this.ThanksCard = new ThanksCard();

            Department department = new Department();
            this.Department = await department.GetDepartmentsAsync();

            User user = new User();
            this.User = await user.GetUsersAsync();

           
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.User = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
            }
        }

        #region Command
        private ViewModelCommand _SelectCommand;

        public ViewModelCommand selectCommand
        {
            get
            {
                if (_SelectCommand == null)
                {
                    _SelectCommand = new ViewModelCommand(Select);
                }
                return _SelectCommand;
            }
        }

        public async void Select()
        { 
            
        }
           
        #endregion



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
            ThanksCard createdThanksCard = await ThanksCard.PostThanksCardAsync(this.ThanksCard);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion

    }
}
