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
    public class TourokugamenViewModel : ViewModel
    {
        #region User変更通知プロパティ
        private User _User;

        public User User
        {
            get
            { return _User; }
            set
            {
                if (_User == value)
                    return;
                _User = value;
                RaisePropertyChanged(nameof(User));
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

       void Initialize()
        {
            this.User = new User();

            Department department = new Department();
            this.Department = await department.GetDepartmentsAsync();




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
            User createdUser = await User.PostUserAsync(this.User);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion
    }
}
