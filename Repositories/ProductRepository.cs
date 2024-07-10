using SignalR8.Data;
using SignalR8.Models;
using System.Data;
using System.Data.SqlClient;

namespace SignalR8.Repositories
{
    public class ProductRepository
    {
        string connectionString;
        private readonly ApplicationDbContext dbContext;


        public ProductRepository(string connectionString, ApplicationDbContext _dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = _dbContext;
        }

        public List<Product> GetProducts()
        {
            var prodList = dbContext.Product.ToList();
            foreach (var emp in prodList)
            {
                dbContext.Entry(emp).Reload();
            }
            //var f = dbContext.Product.ToList();
            return prodList;
        }
    }
}
