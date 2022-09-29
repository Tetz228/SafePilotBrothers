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
        /// <param name="indexColumn">Индекс изменяемого столбца.</param>
        /// <param name="indexLine">Индекс изменяемой строки.</param>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Повернутые рукоятки.</returns>
        public Stick[,] TurnSticks(int indexColumn, int indexLine, Stick[,] sticks);

        /// <summary>
        ///     Проверка всех рукояток на совпадения положения.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Результат о положении рукояток.</returns>
        public bool IsCheckSticks(Stick[,] sticks);
    }
}