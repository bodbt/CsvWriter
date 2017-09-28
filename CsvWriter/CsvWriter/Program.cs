using System;
using System.Data;
using System.Threading;

namespace CsvWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DataLoader loader = new DataLoader();
                DataTable dt = loader.GetDataFromSQLServer();

                CsvWriter writer = new CsvWriter();
                writer.Write(dt);

                Environment.Exit(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Thread.Sleep(3000);
                Environment.Exit(1);
            }
        }
    }
}
