using System;
using System.Globalization;
using System.Windows.Data;
using SafePilotBrothers.Model;

namespace SafePilotBrothers.Converters
{
    /// <summary>
    ///     Класс конвертирования позиций в символы.
    /// </summary>
    public class ConverterPositionsToSymbols: IValueConverter
    {
        /// <summary>
        ///     Конвертирование.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Тип целевого свойства привязки.</param>
        /// <param name="parameter">Используемый параметр преобразователя.</param>
        /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var position = (Position)value;

            switch (position)
            {
                case Position.Horizontal:
                {
                    return "—";
                }
                case Position.Vertical:
                {
                    return "|";
                }
                default:
                    return "";
            }
        }

        /// <summary>
        ///     Обратное конвертирование.
        /// </summary>
        /// <param name="value">Значение.</param>
        /// <param name="targetType">Тип целевого свойства привязки.</param>
        /// <param name="parameter">Используемый параметр преобразователя.</param>
        /// <param name="culture">Язык и региональные параметры, используемые в преобразователе.</param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var position = value.ToString();

            switch (position)
            {
                case "—":
                {
                    return Position.Horizontal;
                }
                case "|":
                {
                    return Position.Vertical;
                }
                default:
                    return Position.Horizontal;
            }
        }
    }
}