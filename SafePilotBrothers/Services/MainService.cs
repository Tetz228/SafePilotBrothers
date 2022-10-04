using Gu.Wpf.DataGrid2D;
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
        public Stick[,] TurnSticks(Stick[,] sticks, RowColumnIndex indexStick)
        {
            var newSticks = (Stick[,])sticks.Clone();
                
            for (int i = 0; i < newSticks.GetLength(0); i++)
            {
                newSticks[indexStick.Column, i].Position = newSticks[indexStick.Column, i].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;
                
                if (newSticks[i, indexStick.Row] == newSticks[indexStick.Column, indexStick.Row])
                {
                    continue;
                }
                    
                newSticks[i, indexStick.Row].Position = newSticks[i, indexStick.Row].Position == Position.Horizontal ? Position.Vertical : Position.Horizontal;
            }

            return newSticks;
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

            return countHorizontal == sticks.Length || countVertical == sticks.Length;
        }
    }
}