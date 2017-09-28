using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvWriter
{
    public class CsvWriter
    {
        public void Write(DataTable dt)
        {
            string outputPath = ConfigurationManager.AppSettings["outputDIR"].ToString();
            string outputFileName = ConfigurationManager.AppSettings["outputFileName"].ToString();

            string path = Path.Combine(outputPath, $"{outputFileName}.csv");

            StringBuilder sb = new StringBuilder();

            IEnumerable<string> columnNames = dt.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName);
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in dt.Rows)
            {
                IEnumerable<string> fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"");
                sb.AppendLine(string.Join(",", fields));
            }

            File.WriteAllText(path, sb.ToString(), Encoding.GetEncoding("UTF-8"));
        }
    }
}
