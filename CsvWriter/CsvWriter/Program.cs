using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader loader = new DataLoader();

            DataTable dt = loader.GetDataFromSQLServer();

            CsvWriter writer = new CsvWriter();

            writer.Write(dt);
        }
    }
}
