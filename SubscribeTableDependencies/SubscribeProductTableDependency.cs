using SignalR8.Hubs;
using SignalR8.Models;
using TableDependency.SqlClient;

namespace SignalR8.SubscribeTableDependencies
{
    public class SubscribeProductTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Product> tableDependency;
        DashboardHub dashboardHub;

        public SubscribeProductTableDependency(DashboardHub dashboardHub)
        {
            this.dashboardHub = dashboardHub;
        }


        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Product>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Product> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                await dashboardHub.SendProducts();
            }
        }


        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Product)} SqlTableDependency error: {e.Error.Message}");
        }


    }

    // public class SubscribeProductTableDependency : ISubscribeTableDependency
    // {
    //     SqlTableDependency<NurseRequest> tableDependency;
    //     NurseRequestHub nurseRequestHub;

    //     public SubscribeProductTableDependency(NurseRequestHub nurseRequestHub)
    //     {
    //         this.nurseRequestHub = nurseRequestHub;
    //     }


    //     public void SubscribeTableDependency(string connectionString)
    //     {
    //         tableDependency = new SqlTableDependency<NurseRequest>(connectionString);
    //         tableDependency.OnChanged += TableDependency_OnChanged;
    //         tableDependency.OnError += TableDependency_OnError;
    //         tableDependency.Start();
    //     }

    //     private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<NurseRequest> e)
    //     {
    //         if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
    //         {
    //             await nurseRequestHub.SendNurseRequests();
    //         }
    //     }


    //     private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
    //     {
    //         Console.WriteLine($"{nameof(NurseRequest)} SqlTableDependency error: {e.Error.Message}");
    //     }


    // }
}
