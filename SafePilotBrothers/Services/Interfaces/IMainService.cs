using Gu.Wpf.DataGrid2D;
using SafePilotBrothers.Model;

namespace SafePilotBrothers.Services.Interfaces
{
    /// <summary>
    ///     Интерфейс взаимодействия с рукоятками.
    /// </summary>
    public interface IMainService
    {
        /// <summary>
        ///     Повернуть рукоятки.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <param name="indexStick">Индексы измененной рукоятки.</param>
        /// <returns>Повернутые рукоятки.</returns>
        public Stick[,] TurnSticks(Stick[,] sticks, RowColumnIndex indexStick);

        /// <summary>
        ///     Проверка всех рукояток на совпадения положения.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Результат на совпадения положения рукояток.</returns>
        public bool IsCheckSticks(Stick[,] sticks);
    }
}