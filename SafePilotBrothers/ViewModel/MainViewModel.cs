using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using DevExpress.Mvvm;
using Gu.Wpf.DataGrid2D;
using SafePilotBrothers.Model;
using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Services;
using SafePilotBrothers.Services.Interfaces;
using SafePilotBrothers.View;

namespace SafePilotBrothers.ViewModel
{
    /// <summary>
    ///     Класс ViewModel для окна "MainWindow.xaml".
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        ///     Интерфейс для взаимодействия с сейфом.
        /// </summary>
        private ISafe _safe;
        
        /// <summary>
        ///     Интерфейс для взаимодействия главным сервисом.
        /// </summary>
        private readonly IMainService _mainService;
        
        /// <summary>
        ///     Класс ViewModel для окна "MainWindow.xaml".
        /// </summary>
        public MainViewModel()
        {
            _safe = new Safe();
            _mainService = new MainService();
        }
        
        /// <summary>
        ///     Рукоятки.
        /// </summary>
        public Stick[,] Sticks
        {
            get
            {
                return _safe.Sticks;
            }
            set
            {
                _safe.Sticks = value;
                
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Поле рукояток в одном положении.
        /// </summary>
        private bool _isCheckSticks;
        
        /// <summary>
        ///     Рукоятки в одном положении.
        /// </summary>
        private bool IsCheckSticks
        {
            get
            {
                return _isCheckSticks;
            }
            set
            {
                _isCheckSticks = value;
                
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        ///     Поле индексов выбранной рукоятки.
        /// </summary>
        private RowColumnIndex _indexStick;
        
        /// <summary>
        ///     Индексы выбранной рукоятки.
        /// </summary>
        public RowColumnIndex IndexStick
        {
            get
            {
                return _indexStick;
            }
            set
            {
                _indexStick = value;
                
                OnPropertyChanged();
            }
        }
        
        /// <summary>
        ///     Событие при изменении свойства.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        
        /// <summary>
        ///     Уведомление при изменении свойств.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            SetNewValueProperties(propertyName);
        }

        /// <summary>
        ///     Установка новых значений свойствам. 
        /// </summary>
        /// <param name="propertyName">Имя свойства.</param>
        private void SetNewValueProperties(string propertyName)
        {
            switch (propertyName)
            {
                case nameof(IndexStick):
                {
                    Sticks = _mainService.TurnSticks(Sticks, _indexStick);
                    IsCheckSticks = _mainService.IsCheckSticks(Sticks);
                    
                    break;
                }
                case nameof(IsCheckSticks):
                {
                    if(IsCheckSticks)
                    {
                        OpenVictoryWindow.Execute(IsCheckSticks);
                    }
                    
                    break;
                }
            }
        }
        /// <summary>
        ///     Команда открытия окна настроек.
        /// </summary>
        public ICommand OpenSettingsWindow => new DelegateCommand(() =>
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.ShowDialog();
        },true);
        
        /// <summary>
        ///     Команда открытия окна победы.
        /// </summary>
        private ICommand OpenVictoryWindow => new DelegateCommand(() =>
        {
            var victoryWindow = new VictoryWindow();
            victoryWindow.ShowDialog();
        },true);
    }
}