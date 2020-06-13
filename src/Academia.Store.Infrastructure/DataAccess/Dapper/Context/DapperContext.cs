using System;
using System.Data;
using System.Data.SqlClient;

namespace Academia.Store.Infrastructure.DataAccess.Dapper.Context
{
    public class DapperContext : IDisposable
    {
        public SqlConnection Connection { get; set; }
        public DapperContext()
        {
            Connection = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=Valhalla;Integrated Security=True");
            Connection.Open();
        }
        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
