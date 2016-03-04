namespace EventNotification
{
    public class EventNotificationEventArgs
    {
        #region  Constructors & Destructor
        public EventNotificationEventArgs() { }

        public EventNotificationEventArgs(Event[] notifiedEvents)
        {
            NotifiedEvents = notifiedEvents;
        }
        #endregion


        #region  Properties & Indexers
        public Event[] NotifiedEvents { get; set; }
        #endregion
    }
}