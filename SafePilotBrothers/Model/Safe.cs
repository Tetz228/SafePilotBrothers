using SafePilotBrothers.Model.Interfaces;
using SafePilotBrothers.Utilities;

namespace SafePilotBrothers.Model
{
    /// <summary>
    ///     Класс сейфа.
    /// </summary>
    public class Safe : ISafe
    {
        /// <summary>
        ///     Класс сейфа.
        /// </summary>
        public Safe()
        {
            Sticks = UtilitySafe.RandomSticks();
        }

        /// <inheritdoc />
        public Stick[,] Sticks { get; set; }
    }
}