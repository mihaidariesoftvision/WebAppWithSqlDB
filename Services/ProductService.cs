using System.Data;
using System.Data.SqlClient;
using WebAppWithSqlDB.Models;

namespace WebAppWithSqlDB.Services
{
    public class ProductService
    {
        private const string connstring = "tcp:mihaisqlserver.database.windows.net";
        private const string user = "mihai-sa";
        private const string password = "admin2023!";
        private const string db = "mihai-sql-db";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = connstring,
                UserID = user,
                Password = password,
                InitialCatalog = db
            };

            return new SqlConnection(builder.ConnectionString);
        }

        public IEnumerable<Product> GetProducts()
        {
            var conn = GetConnection();
            var productList = new List<Product>();

            string statement = "SELECT ProductId, ProductName, Quantity FROM Products";

            conn.Open();

            var command = new SqlCommand(statement, conn);

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var product = new Product();
                product.ProductId = reader.GetInt32("ProductId");
                product.ProductName = reader.GetString("ProductName");
                product.Quantity = reader.GetInt32("Quantity");
                productList.Add(product);
            }

            conn.Close();

            return productList;
        }

    }
}
