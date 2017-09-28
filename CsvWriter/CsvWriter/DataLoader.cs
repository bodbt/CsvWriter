using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace CsvWriter
{
    public class DataLoader
    {
        public DataTable GetDataFromSQLServer()
        {
            DataTable dt = new DataTable();

            try
            {
                string strDBCon = ConfigurationManager.ConnectionStrings["Database"].ToString();

                string sql = ReadSQLFromFile();

                using (SqlConnection con = new SqlConnection(strDBCon))
                {
                    con.Open();

                    SqlCommand command = new SqlCommand(sql, con);

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dt);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        /// <summary>
        /// SQL文を読み込む
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>SQL文</returns>
        private string ReadSQLFromFile()
        {
            string sqlFilePath = ConfigurationManager.AppSettings["SQLFile"].ToString();

            if (!File.Exists(sqlFilePath))
            {
                throw new ArgumentException("指定されたSQLファイルが見つかりません。");
            }

            string sql = File.ReadAllText(sqlFilePath, Encoding.GetEncoding("UTF-8"));

            return sql;
        }
    }
}
