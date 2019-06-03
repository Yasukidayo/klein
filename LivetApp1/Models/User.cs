using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using LivetApp1.Services;
using Newtonsoft.Json;

namespace LivetApp1.Models
{
    public class User : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです!
         */
        #region IdProperty
        private long _Id;

        public long Id
        {
            get
            { return _Id; }
            set
            {
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region NameProperty

        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region PasswordProperty　//追加


        private string _Password;
        [JsonProperty("Password")]
        public string Password
        {
            get
            { return _Password; }
            set
            {
                if (_Password == value)
                    return;
                _Password = value;
                RaisePropertyChanged();
            }
        }
        #endregion 


        #region IsAdminProperty

        private bool _IsAdmin;
        [JsonProperty("IsAdmin")]
        public bool IsAdmin
        {
            get
            { return _IsAdmin; }
            set
            { 
                if (_IsAdmin == value)
                    return;
                _IsAdmin = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region DepartmenrProperty
        private Department _Department;

        public Department Department
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

        #region RootProperty
        private Root _Root;

        public Root Root
        {
            get
            { return _Root; }
            set
            {
                if (_Root == value)
                    return;
                _Root = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Logon処理
        public async Task<User> LogonAsync()
        {
            IRestService rest = new RestService();
            User authorizedUser = await rest.LogonAsync(this);
            return authorizedUser;
          
        }

        public async Task<User> LogonAsync2()
        {
            IRestService rest = new RestService();
            User authorizedUser2 = await rest.LogonAsync2(this);
            return authorizedUser2;

        }
        #endregion

        #region User
        public async Task<List<User>> GetUsersAsync()
        {
            IRestService rest = new RestService();
            List<User> users = await rest.GetUsersAsync();
            return users;
        }

        public async Task<User> PostUserAsync(User user)
        {
            IRestService rest = new RestService();
            User createdUser = await rest.PostUserAsync(user);
            return createdUser;
        }

        public async Task<User> PutUserAsync(User user)
        {
            IRestService rest = new RestService();
            User updatedUser = await rest.PutUserAsync(user);
            return updatedUser;
        }

        public async Task<User> DeleteUserAsync(long Id)
        {
            IRestService rest = new RestService();
            User deletedUser = await rest.DeleteUserAsync(Id);
            return deletedUser;
        }

        #endregion
    }

}
