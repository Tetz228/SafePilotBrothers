using System.Data;
using SafePilotBrothers.Model;

namespace SafePilotBrothers.Extensions
{
    /// <summary>
    ///     Класс расширения для рукояток.
    /// </summary>
    public static class StickExtensions
    {
        /// <summary>
        ///     Маппинг рукояток в контекст для DataGrid.
        /// </summary>
        /// <param name="sticks">Рукоятки.</param>
        /// <returns>Контекст для DataGrid.</returns>
        public static DataView ToDataView(this Stick[,] sticks)
        {
            var dataTable = new DataTable();
                
            for (int i = 0; i < sticks.GetLength(0); i++)
            {
                dataTable.Columns.Add(null, typeof(string));
            }
            
            for (int i = 0; i < sticks.GetLength(0); i++)
            {
                var newRow = dataTable.NewRow();
     
                for (int j = 0; j < sticks.GetLength(1); j++)
                {
                    if(sticks[i, j].Position == Position.Horizontal)
                    {
                        newRow[j] = "—";
                    }
                    else
                    {
                        newRow[j] = "|";
                    }
                }
     
                dataTable.Rows.Add(newRow);
            }
            
            return dataTable.DefaultView;
        }
    }
}