using LinqToDB;
using LinqToDB.Data;
using SvaraKalkulators.Core.Data.Models.Data;

namespace SvaraKalkulators.Core.Data.DbAccess
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(DataOptions<AppDataConnection> options)
            : base(options.Options)
        {
                
        }

        public ITable<ResultsModel> Results => this.GetTable<ResultsModel>(); 
    }
}
