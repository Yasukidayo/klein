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
    public class KansyaViewModel : ViewModel
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

        #region LogonUserProperty
        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get
            { return _AuthorizedUser; }
            set
            {
                if (_AuthorizedUser == value)
                    return;
                _AuthorizedUser = value;
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
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;

            User user = new User();

            IRestService service = new RestService();
            this.ToUser = await service.GetDepUsersAsync(null);

            if (SessionService.Instance.AuthorizedUser != null)
            {

                this.ToUser = await SessionService.Instance.AuthorizedUser.GetDepUsersAsync(null);
                this.User = await user.GetUsersAsync();
                this.Department = await department.GetDepartmentsAsync();

            }

        }


      

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

            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.ToUser = await SessionService.Instance.AuthorizedUser.GetDepUsersAsync(DepartmentId);
            }
            else
            {
                IRestService service = new RestService();
                this.ToUser = await service.GetDepUsersAsync(DepartmentId);
            }
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
        //To部署が変更されたときに発生するコマンド
     

    }
}
