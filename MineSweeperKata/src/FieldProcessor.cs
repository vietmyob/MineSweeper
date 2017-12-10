using System.Collections.Generic;
using System.Linq;
using MineSweeperKata.DTO;

namespace MineSweeperKata
{
    public class FieldProcessor
    {
        public Field Process(string fields)
        {
            var field = new Field();
            var rowAndColumn = GetRowAndColumn(fields);
            var processedFieldValue = CleanseField(fields);
            processedFieldValue = RemoveRowAndColumn(processedFieldValue, rowAndColumn);

            field.NoOfRows = rowAndColumn.First();
            field.NoOfColumns = rowAndColumn.Last();
            field.Value = processedFieldValue;
            return field;
        }

        private static string CleanseField(string fields)
        {
            return fields.Replace("~", "").Replace("\n", "").Replace(" ", "");
        }

        private string RemoveRowAndColumn(string processedFieldValue, IEnumerable<int> rowAndColumn)
        {
            foreach (var i in rowAndColumn)
                processedFieldValue = processedFieldValue.Replace(i.ToString(), "");

            return processedFieldValue;
        }

        private List<int> GetRowAndColumn(string fields)
        {
            var rowAndColumn = new List<int>();
            foreach (var c in fields)
            {
                if (int.TryParse(c.ToString(), out var parsedChar))
                    rowAndColumn.Add(parsedChar);
            }

            return rowAndColumn;
        }
    }
}