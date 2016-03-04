using System;
using CB.Model.Common;


namespace EventNotification
{
    public class Event: ObservableObject
    {
        #region Fields
        private string _description = "Event";

        private DateTime _time = DateTime.Now.AddMinutes(1);
        #endregion


        #region  Properties & Indexers
        public string Description
        {
            get { return _description; }
            set { SetProperty(ref _description, value); }
        }

        public DateTime Time
        {
            get { return _time; }
            set { SetProperty(ref _time, value); }
        }
        #endregion
    }
}