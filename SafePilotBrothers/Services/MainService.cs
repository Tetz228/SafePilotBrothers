using SafePilotBrothers.Model;
using SafePilotBrothers.Services.Interfaces;

namespace SafePilotBrothers.Services
{
    /// <summary>
    ///     Сервисы для взаимодействия с рукоятками.
    /// </summary>
    public class MainService : IMainService
    {
        /// <inheritdoc />
        public Stick[,] TurnSticks(int indexColumn, int indexLine, Stick[,] sticks)
        {
            for (int i = 0; i < sticks.Length; i++)
            {
                sticks[indexLine, i].Position = sticks[indexLine, i].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;

                if (sticks[i, indexColumn] == sticks[indexLine, indexColumn])
                {
                    continue;
                }

                sticks[i, indexColumn].Position = sticks[i, indexColumn].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;
            }

            return sticks;
        }

        /// <inheritdoc />
        public bool IsCheckSticks(Stick[,] sticks)
        {
            int countHorizontal = 0;
            int countVertical = 0;

            for (int i = 0; i < sticks.GetLength(0); i++)
            {
                for (int j = 0; j < sticks.GetLength(0); j++)
                {
                    if (sticks[i, j].Position == Position.Horizontal)
                    {
                        countHorizontal++;
                    }
                    else
                    {
                        countVertical++;
                    }
                }
            }

            return countHorizontal == sticks.Length || countHorizontal == sticks.Length;
        }
    }
}