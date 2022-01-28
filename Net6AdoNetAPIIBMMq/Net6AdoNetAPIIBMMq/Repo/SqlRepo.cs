using System.Data.SqlClient;

namespace Net6AdoNetAPIIBMMq.Repo
{
    public class SqlRepo : ISqlRepo
    {
        private readonly IConfiguration _config;
        public SqlRepo(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<string> RunQuery()
        {
            List<string> tables = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(_config.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    String sql = "SELECT name, collation_name FROM sys.databases";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tables.Add(string.Format("{0} {1}", reader.GetString(0), reader.GetString(1)));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {

            }
            return tables;
        }
    }
}
