using Microsoft.AspNetCore.SignalR;
using SignalR8.Data;
using SignalR8.Repositories;

namespace SignalR8.Hubs
{
    public class NurseRequestHub : Hub
    {
        NurseRequestRepository nurseRequestRepository;
        private readonly ApplicationDbContext dbContext;

        public NurseRequestHub(IConfiguration configuration, ApplicationDbContext _dbContext)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            dbContext = _dbContext;
            nurseRequestRepository = new NurseRequestRepository(connectionString, dbContext);
        }

        public async Task SendNurseRequests()
        {
            var nurseRequests = nurseRequestRepository.GetNurseRequests();
            await Clients.All.SendAsync("ReceivedNurseRequests", nurseRequests);
        }
    }
}

