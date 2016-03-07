using System;
using EventNotifierModels;
using EventNotifierWindow;


namespace EventNotifierViewModels
{
    public class MainWindowViewModel: MainWindowModelViewBase
    {
        #region  Constructors & Destructor
        public MainWindowViewModel() { }

        public MainWindowViewModel(TimeSpan interval): base(interval) { }
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