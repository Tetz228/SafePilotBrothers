namespace SafePilotBrothers.Model.Interfaces
{
    /// <summary>
    ///     Интерфейс сейфа с рукоятками.
    /// </summary>
    public interface ISafe
    {
        /// <summary>
        ///     Рукоятки.
        /// </summary>
        public Stick[,] Sticks { get; set; }
    }
}