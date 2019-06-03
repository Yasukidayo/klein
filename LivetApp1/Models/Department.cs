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
     public class Department : NotificationObject
    {

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


        #region CodeProperty
        private long _CD;

        public long CD
        {
            get
            { return _CD; }
            set
            {
                if (_CD == value)
                    return;
                _CD = value;
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

        #region ParentIdProperty
        private long? _ParentId;

        public long? ParentId
        {
            get
            { return _ParentId; }
            set
            {
                if (_ParentId == value)
                    return;
                _ParentId = value;
                RaisePropertyChanged();
            }
        }
        #endregion
               

    
    }

}