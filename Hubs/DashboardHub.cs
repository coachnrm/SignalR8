using Microsoft.AspNetCore.SignalR;
using SignalR8.Data;
using SignalR8.Repositories;

namespace SignalR8.Hubs
{
    public class DashboardHub : Hub
    {
        ProductRepository productRepository;
        private readonly ApplicationDbContext dbContext;

        public DashboardHub(IConfiguration configuration, ApplicationDbContext _dbContext)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbContext = _dbContext;
            productRepository = new ProductRepository(connectionString, dbContext);
        }

        public async Task SendProducts()
        {
            var products = productRepository.GetProducts();
            await Clients.All.SendAsync("ReceivedProducts", products);
        }
    }
}
