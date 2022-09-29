using System.Text.Json.Serialization;

namespace SafePilotBrothers.Model
{
    /// <summary>
    ///     Класс поля.
    /// </summary>
    public class Field
    {
        /// <summary>
        ///     Размер поля.
        /// </summary>
        [JsonPropertyName("SizeField")]
        public string Size { get; set; }
    }
}

