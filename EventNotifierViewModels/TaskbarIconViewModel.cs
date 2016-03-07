using System.Windows;
using System.Windows.Input;
using CB.Model.Common;


namespace EventNotifierViewModels
{
    public class TaskbarIconViewModel: ViewModelBase
    {
        #region Fields
        private ICommand _closeWindowCommand;
        private ICommand _hideWindowCommand;
        private readonly Window _mainWindow;
        private ICommand _showWindowCommand;
        #endregion


        #region  Constructors & Destructor
        public TaskbarIconViewModel()
        {
            _mainWindow = Application.Current.MainWindow;
        }
        #endregion


        #region  Properties & Indexers
        public ICommand CloseWindowCommand
            => GetCommand(ref _closeWindowCommand, _ => _mainWindow?.Close(),
                _ => _mainWindow != null);

        public ICommand HideWindowCommand
            => GetCommand(ref _hideWindowCommand, _ => _mainWindow?.Hide(),
                _ => _mainWindow != null && _mainWindow.IsVisible);

        public ICommand ShowWindowCommand
            => GetCommand(ref _showWindowCommand, _ => _mainWindow?.Show(),
                _ => _mainWindow != null && !_mainWindow.IsVisible);
        #endregion
    }
}