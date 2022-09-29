using System.Data;
using DevExpress.Mvvm;
using SafePilotBrothers.Extensions;
using SafePilotBrothers.Model;
using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Services;
using SafePilotBrothers.Services.Interfaces;

namespace SafePilotBrothers.ViewModel
{
    /// <summary>
    ///     Класс ViewModel для окна "MainWindow.xaml".
    /// </summary>
    public class MainViewModel : BindableBase
    {
        /// <summary>
        ///     Интерфейс для взаимодействия с сейфом.
        /// </summary>
        private readonly ISafe _safe;
        
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
        ///     Контекст для DataGrid.
        /// </summary>
        public DataView Sticks
        {
            get
            {
                return _safe.Sticks.ToDataView();
            }
        }
    }
}