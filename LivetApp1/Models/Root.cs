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
    public class Root : NotificationObject
    {

        #region IdProperty
        private int _Id;

        public int Id
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

                
        #region Flag1Property


        private string _BodyFlag1;
        [JsonProperty("BodyFlag1")]
        public string BodyFlag1
        {
            get
            { return _BodyFlag1; }
            set
            {
                if (_BodyFlag1 == value)
                    return;
                _BodyFlag1 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Flag2Property

        private string _BodyFlag2;
        [JsonProperty("BodyFlag2")]
        public string BodyFlag2
        {
            get
            { return _BodyFlag2; }
            set
            {
                if (_BodyFlag2 == value)
                    return;
                _BodyFlag2 = value;
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

        #region Root

        public async Task<List<Root>> GetrootsAsync()
        {
            IRestService rest = new RestService();
            List<Root> Roots = await rest.GetRootsAsync();
            return Roots;
        }

        public async Task<Root> PostRootAsync(Root root)
        {
            IRestService rest = new RestService();
            Root createdRoot = await rest.PostRootAsync(root);
            return createdRoot;
        }

        public async Task<Root> PutRootAsync(Root root)
        {
            IRestService rest = new RestService();
            Root updatedRoot = await rest.PutRootAsync(root);
            return updatedRoot;
        }

        public async Task<Root> DeleteRootAsync(long Id)
        {
            IRestService rest = new RestService();
            Root deletedRoot = await rest.DeleteRootAsync(Id);
            return deletedRoot;
        }
        #endregion
    }
}