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
    public class ThanksCard : NotificationObject
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
        private int _CD;

        public int CD
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


        #region FromProperty
        private User _From;

        public User From
        {
            get
            { return _From; }
            set
            {
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ToProperty
        private User _To;

        public User To
        {
            get
            { return _To; }
            set
            {
                if (_To == value)
                    return;
                _To = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region TitleProperty
        private string _Title;
        [JsonProperty("Title")]
        public string Title
        {
            get
            { return _Title; }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region BodyProperty
        private string _Body;
        [JsonProperty("Body")]
        public string Body
        {
            get
            { return _Body; }
            set
            {
                if (_Body == value)
                    return;
                _Body = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CreatedDateTimeProperty
        private DateTime _CreatedDateTime;

        public DateTime CreatedDateTime
        {
            get
            { return _CreatedDateTime; }
            set
            {
                if (_CreatedDateTime == value)
                    return;
                _CreatedDateTime = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Flag1Property

        private bool _Flag1;
        [JsonProperty("Flag1")]
        public bool Flag1
        {
            get
            { return _Flag1; }
            set
            {
                if (_Flag1 == value)
                    return;
                _Flag1 = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Flag2Property

        private bool _Flag2;
        [JsonProperty("Flag2")]
        public bool Flag2
        {
            get
            { return _Flag2; }
            set
            {
                if (_Flag2 == value)
                    return;
                _Flag2 = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
