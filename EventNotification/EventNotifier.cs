using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;


namespace EventNotification
{
    public class EventNotifier
    {
        #region Fields
        private const double INTERVAL = 60.0 * 1000;
        protected SynchronizationContext _synchronizationContext;
        protected readonly Timer _timer;
        #endregion


        #region  Constructors & Destructor
        public EventNotifier(): this(TimeSpan.FromMilliseconds(INTERVAL)) { }

        public EventNotifier(TimeSpan interval)
        {
            _synchronizationContext = SynchronizationContext.Current;
            _timer = new Timer(interval.TotalMilliseconds);
            _timer.Elapsed += Timer_Elapsed;
            _timer.Start();
        }
        #endregion


        #region  Properties & Indexers
        public ObservableCollection<Event> Events { get; } = new ObservableCollection<Event>();
        #endregion


        #region Events
        public event EventHandler<EventNotificationEventArgs> Notified;
        #endregion


        #region Event Handlers
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var now = DateTime.Now;
            var notifiedEvents = Events.Where(evnt => evnt.Time < now).ToArray();
            if (!notifiedEvents.Any()) return;
            if (_synchronizationContext != null)
            {
                _synchronizationContext.Send(_ => { DoNotificationAction(notifiedEvents); }, null);
            }
            else
            {
                DoNotificationAction(notifiedEvents);
            }
        }
        #endregion


        #region Implementation
        private void DoNotificationAction(Event[] notifiedEvents)
        {
            OnNotified(new EventNotificationEventArgs(notifiedEvents));
            foreach (var evnt in notifiedEvents) Events.Remove(evnt);
        }

        protected virtual void OnNotified(EventNotificationEventArgs e)
        {
            Notified?.Invoke(this, e);
        }
        #endregion
    }
}