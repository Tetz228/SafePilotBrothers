using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace SafePilotBrothers.ViewModel
{
    /// <summary>
    ///     Класс ViewModel для окна "VictoryWindow.xaml".
    /// </summary>
    public class VictoryViewModel
    {
        /// <summary>
        ///     Команда подтверждения.
        /// </summary>
        public ICommand Ok
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Application.Current.Shutdown();
                }, true);
            }
        }
    }
}