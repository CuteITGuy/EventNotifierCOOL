using System;
using EventNotifierWindow;


namespace EventNotification
{
    public class SimpleEventNotifier: EventNotifier
    {
        #region  Constructors & Destructor
        public SimpleEventNotifier() { }

        public SimpleEventNotifier(TimeSpan interval): base(interval) { }
        #endregion


        #region Override
        protected override void OnNotified(EventNotificationEventArgs e)
        {
            base.OnNotified(e);
            _timer.Stop();
            var notifierWindow = new MainWindow { DataContext = e.NotifiedEvents };
            notifierWindow.ShowDialog();
            _timer.Start();
        }
        #endregion
    }
}