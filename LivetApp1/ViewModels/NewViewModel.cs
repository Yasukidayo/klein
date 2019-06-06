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

        #region ToUsersProperty
        private List<User> _ToUser;

        public List<User> ToUser
        {
            get
            { return _ToUser; }
            set
            {
                if (_ToUser == value)
                    return;
                _ToUser = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region FromUsersProperty
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
                this.FromUser = await SessionService.Instance.AuthorizedUser.GetDepUsersAsync(null);
                this.ToUser = this.FromUser;
            }

        }

        #region FromDepartmentsChangedCommand
        private ListenerCommand<long> _FromDepartmentsChangedCommand;

        public ListenerCommand<long> FromDepartmentsChangedCommand
        {
            get
            {
                if (_FromDepartmentsChangedCommand == null)
                {
                    _FromDepartmentsChangedCommand = new ListenerCommand<long>(FromDepartmentsChanged);
                }
                return _FromDepartmentsChangedCommand;
            }
        }

        public async void FromDepartmentsChanged(long DepartmentId)
        {
            System.Diagnostics.Debug.WriteLine(DepartmentId);
            this.FromUser = await SessionService.Instance.AuthorizedUser.GetDepUsersAsync(DepartmentId);
        }
        #endregion

        #region ToDepartmentsChangedCommand
        private ListenerCommand<long> _ToDepartmentsChangedCommand;

        public ListenerCommand<long> ToDepartmentsChangedCommand
        {
            get
            {
                if (_ToDepartmentsChangedCommand == null)
                {
                    _ToDepartmentsChangedCommand = new ListenerCommand<long>(ToDepartmentsChanged);
                }
                return _ToDepartmentsChangedCommand;
            }
        }

        public async void ToDepartmentsChanged(long DepartmentId)
        {
            System.Diagnostics.Debug.WriteLine(DepartmentId);
            this.ToUser = await SessionService.Instance.AuthorizedUser.GetDepUsersAsync(DepartmentId);
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
