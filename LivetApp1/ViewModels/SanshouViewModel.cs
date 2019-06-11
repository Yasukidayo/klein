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

        #region DepartmentsProperty
        private List<Department> _Departments;

        public List<Department> Departments
        {
            get
            { return _Departments; }
            set
            {
                if (_Departments == value)
                    return;
                _Departments = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public async void Initialize()
        {
            this.UpdateUsers();
            User user = new User();
            this.User = await user.GetUsersAsync();
            this.UpdateDepartments();
        }

        private async void UpdateUsers()
        {
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.User = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
            }
        }

        private async void UpdateDepartments()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
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

        #region DepartmentDeleteCommand
        private ListenerCommand<Department> _DepartmentDeleteCommand;

        public ListenerCommand<Department> DepartmentDeleteCommand
        {
            get
            {
                if (_DepartmentDeleteCommand == null)
                {
                    _DepartmentDeleteCommand = new ListenerCommand<Department>(DepartmentDelete);
                }
                return _DepartmentDeleteCommand;
            }
        }
        public async void DepartmentDelete(Department Department)
        {
            System.Diagnostics.Debug.WriteLine("DeleteCommand" + Department.Id);
            Department deletedDepartment = await Department.DeleteDepartmentAsync(Department.Id);

            this.Initialize();
        }
        #endregion



    }
}
