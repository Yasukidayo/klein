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
    public class SanshouViewModel : ViewModel
    {
        #region UsersProperty
        private List<User> _Users;

        public List<User> Users
        {
            get
            { return _Users; }
            set
            {
                if (_Users == value)
                    return;
                _Users = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public void Initialize()
        {
            this.UpdateUsers();
        }

        private async void UpdateUsers()
        {
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.Users = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
            }
        }

        #region UserDeleteCommand
        private ListenerCommand<User> _UserDeleteCommand;

        public ListenerCommand<User> UserDeleteCommand
        {
            get
            {
                if (_UserDeleteCommand == null)
                {
                    _UserDeleteCommand = new ListenerCommand<User>(UserDelete);
                }
                return _UserDeleteCommand;
            }
        }

        public async void UserDelete(User User)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + User.Id);
            User deletedUser = await User.DeleteUserAsync(User.Id);

            this.Initialize();
        }
        #endregion
    }
}
