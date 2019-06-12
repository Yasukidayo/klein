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

        #region MessageProperty
        private string _Message;
        [JsonProperty("Message")]
        public string Message
        {
            get
            { return _Message; }
            set
            {
                if (_Message == value)
                    return;
                _Message = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ThanksCardProperty
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

        public static implicit operator Responsemessage(Department v)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Responsemessage
        public async Task<List<Responsemessage>> GetResponsemessagesAsync()
        {
            IRestService rest = new RestService();
            List<Responsemessage> responsemessages = await rest.GetResponsemessagesAsync();
            return responsemessages;
        }

        public async Task<Responsemessage> PostResponsemessageAsync(Responsemessage responsemessage)
        {
            IRestService rest = new RestService();
            Responsemessage createdResponsemessage = await rest.PostResponsemessageAsync(responsemessage);
            return createdResponsemessage;
        }

        public async Task<Responsemessage> PutResponsemessageAsync(Responsemessage responsemessage)
        {
            IRestService rest = new RestService();
            Responsemessage updatedResponsemessage = await rest.PutResponsemessageAsync(responsemessage);
            return updatedResponsemessage;
        }

        public async Task<Responsemessage> DeleteResponsemessageAsync(long Id)
        {
            IRestService rest = new RestService();
            Responsemessage deletedResponsemessage = await rest.DeleteResponsemessageAsync(Id);
            return deletedResponsemessage;
        }

        #endregion
    }
}
