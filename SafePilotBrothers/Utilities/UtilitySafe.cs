using System;
using System.IO;
using System.Text.Json;
using SafePilotBrothers.Model;

namespace SafePilotBrothers.Utilities
{
    /// <summary>
    ///     Класс утилиты для сейфа.
    /// </summary>
    public static class UtilitySafe
    {
        /// <summary>
        ///     Заполнение сейфа рукоятками.
        /// </summary>
        public static Stick[,] RandomSticks()
        {
            var random = new Random();
            var size = GetSizeField();
            var sticks = new Stick[size, size];
            
            for (int i = 0; i < sticks.GetLength(0); i++)
            {
                for (int j = 0; j < sticks.GetLength(1); j++)
                {
                    sticks[i, j] = new Stick
                    {
                        Position = (Position)random.Next(0, 2)
                    };
                }
            }
            
            return sticks;
        }

        /// <summary>
        ///     Получить размер поля.
        /// </summary>
        /// <returns>Размер поля.</returns>
        private static int GetSizeField()
        {
            var pathSettings = Directory.GetCurrentDirectory() + @"\Settings\" + "Settings.json";
            using var settingsJson = new FileStream(pathSettings, FileMode.Open);
            var field = JsonSerializer.Deserialize<Field>(settingsJson);

            return int.TryParse(field.Size, out int result) ? result : 4;
        }
    }
}