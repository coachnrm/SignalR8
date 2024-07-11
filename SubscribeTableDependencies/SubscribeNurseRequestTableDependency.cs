using SignalR8.Hubs;
using SignalR8.Models;
using TableDependency.SqlClient;

namespace SignalR8.SubscribeTableDependencies
{
    public class SubscribeNurseRequestTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<NurseRequest> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeNurseRequestTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }


        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<NurseRequest>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<NurseRequest> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                await dashboardHub.SendNurseRequests();
            }
        }


        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(NurseRequest)} SqlTableDependency error: {e.Error.Message}");
        }


    }
}