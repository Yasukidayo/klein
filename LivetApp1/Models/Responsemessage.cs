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
    public class Responsemessage : NotificationObject
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

        #region ParentProperty
        private ThanksCard _ThanksCardResponses;

        public ThanksCard ThanksCardResponses
        {
            get
            { return _ThanksCardResponses; }
            set
            {
                if (_ThanksCardResponses == value)
                    return;
                _ThanksCardResponses = value;
                RaisePropertyChanged();
            }
        }
        #endregion
    }
}
