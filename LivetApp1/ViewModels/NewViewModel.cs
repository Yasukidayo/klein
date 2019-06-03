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
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
using LivetApp1.Services;

namespace LivetApp1.ViewModels
{
    public class NewViewModel : ViewModel
    {
        
         #region MyMessageProperty
         private string _MyMessage;

         public string MyMessage
         {
             get
             { return _MyMessage; }
             set
             {
                 if (_MyMessage == value)
                     return;
                 _MyMessage = value;
                 RaisePropertyChanged();
                 System.Diagnostics.Debug.WriteLine("MyMessage: " + this.MyMessage); //動作確認用。本来はこの行は必要ありません。

             }
         }
        #endregion

        public void Initialize()
        {
        }



    }
}
