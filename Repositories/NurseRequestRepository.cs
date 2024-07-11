using SignalR8.Data;
using SignalR8.Models;

namespace SignalR8.Repositories
{
    public class NurseRequestRepository
    {
        string connectionString;
        private readonly ApplicationDbContext dbContext;


        public NurseRequestRepository(string connectionString, ApplicationDbContext _dbContext)
        {
            this.connectionString = connectionString;
            this.dbContext = _dbContext;
        }

        public List<NurseRequest> GetNurseRequests()
        {
            var nurseRequestList = dbContext.NurseRequests.ToList();
            foreach (var emp in nurseRequestList)
            {
                dbContext.Entry(emp).Reload();
            }
            //var f = dbContext.Product.ToList();
            return nurseRequestList;
        }
    }
}